using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/authAsync")]
    public class AuthControllerAsync : Controller
    {
        private IAuthRepositoryAsync _authRepository;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public AuthControllerAsync(IAuthRepositoryAsync authRepository, IConfiguration configuration, IMapper mapper)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

		[HttpGet("KisiRegister/create")]
		public async void KisiRegisterCreateAsync()  // Task<IActionResult>
		{
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu1", KisiTipi = "STU", Password = "stu1", UserName = "stu1" });
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu2", KisiTipi = "STU", Password = "stu2", UserName = "stu2" });
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu3", KisiTipi = "STU", Password = "stu3", UserName = "stu3" });
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu4", KisiTipi = "STU", Password = "stu4", UserName = "stu4" });
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu5", KisiTipi = "STU", Password = "stu5", UserName = "stu5" });
			await this.KisiRegisterAsync(new KisiRegisterDto() { Email = "stu6", KisiTipi = "STU", Password = "stu6", UserName = "stu6" });
		}

		[HttpPost("KisiRegister")]
        public async Task<IActionResult> KisiRegisterAsync([FromBody] KisiRegisterDto userForRegisterDto)
        {
            if (await _authRepository.IsKisiUsernameExistsAsync(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("error", "Username already exists");
            }
            if (await _authRepository.IsKisiEmailExistsAsync(userForRegisterDto.Email))
            {
				ModelState.AddModelError("error", "Email already exists");
			}

			if (!ModelState.IsValid)
            {
				var HSC = HttpStatusCode.Conflict; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				return StatusCode((int)HSC, new MyRestResponse(HSC, ModelState, userForRegisterDto, "userForRegisterDto")
				{
					Description = "model state(ler) doldurulursa tatmin edici geri dönüşler ulaşabilir.",
				});// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}

			var userToCreate = new Kisiler
            {
                KisiTipi = userForRegisterDto.KisiTipi,
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.UserName
            };

            var createdUser = await _authRepository.KisiRegisterAsync(userToCreate, userForRegisterDto.Password);

																	createdUser.RegisterDate = DateTime.Now;
																	createdUser.RegisterDateIP = "1.1.1.1";
																	createdUser.Username = _ControllersHelper.GetUsernameFromEmail(userToCreate.Email) + createdUser.IdE;
			int sonuc = await _authRepository.UpdateToKisiAsync(createdUser);

			if (sonuc > 0)
			{
				// evet user(kisi) yaratıldı. fakat KisiTipi ne göre ilişkili 1:1 alanları oluşturmadık. 
				await this.EmailConfirmAsync(createdUser);
				// evet şimdi oluşturduk 

				ModelState.AddModelError("error", "user yaratıldı.");
				var HSC = HttpStatusCode.Created; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				return StatusCode((int)HSC, new MyRestResponse(HSC, ModelState, createdUser, "createdUser")
				{
					Description = "user yaratıldı.",
				});// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			else
			{
				ModelState.AddModelError("error", "user yaratılamadı!");
				var HSC = HttpStatusCode.NotModified; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				return StatusCode((int)HSC, new MyRestResponse(HSC, ModelState, createdUser, "createdUser")
				{
					Description = "user yaratılamadı!",
				});// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
		}

		// https://www.restapitutorial.com/httpstatuscodes.html
		// https://restfulapi.net/http-status-codes/
		// https://en.wikipedia.org/wiki/List_of_HTTP_status_codes
		// https://jsonapi.org/

		[HttpPost("KisiLogin")]
        public async Task<ActionResult> KisiLoginAsync([FromBody] KisiLoginDto userForLoginDto)
        {
            //

            var user = await _authRepository.KisiLoginAsync(userForLoginDto.Email, userForLoginDto.Password);

            if (user == null) // emailine göre bulamadıysak
            {
                // bir de email olarak gelen bilgiyi username olarak aratalım
                var Kisi = await _authRepository.GetKisilerByUsernameAsync(username : userForLoginDto.Email);
                if (Kisi != null)
                {
                    user = await _authRepository.KisiLoginAsync(Kisi.Email, userForLoginDto.Password);
                }
            }

            if (user == null) // eğer artık burada da yoksa 
            {
				ModelState.AddModelError("errorMerror", "Kullanıcı(" + userForLoginDto.Email + ") Bulunamadı");

				var HSC = HttpStatusCode.Unauthorized; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				return StatusCode((int)HSC, new MyRestResponse(HSC, ModelState, userForLoginDto, "userForLoginDto")
				{
					Description = "KisiLogin olurken ..."
				});// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				// return BadRequest(ModelState);
			}

			var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdE.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                    , SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // burada LoginTracker add yap            
            var LT = new LoginTracker() { LoginDateIP = "2.2.2.2", KisiIdE = user.IdE };
            var track = await _authRepository.AddToLoginTrackerAsync(LT);
			// burada LoginTracker add yap

			//
			user.IsAnyLogin = await _authRepository.IsAnyloginAsync(user.IdE);
			user.LastLoginDate = await _authRepository.GetLastloginAsync(user.IdE);
			int sonuc = await _authRepository.UpdateToKisiAsync(user);
			//

			//// aslında EmailConfirm olayında gerçekleşmesi gereken durumu buraya geçici yazıyorum
			//// bir kere çalışması gerekiyor
			//await this.EmailConfirm(user); // bunu buradan KisiRegister içine aldım
			//// bir kere çalışması gerekiyor
			//// aslında EmailConfirm olayında gerçekleşmesi gereken durumu buraya geçici yazıyorum

			return Ok(tokenString); // burası böyle kalacak.

			//var HSCo = HttpStatusCode.OK; // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			//return StatusCode((int)HSCo, new MyRestResponse(new HttpResponseMessage(HSCo))
			//{
			//	MyRequestObject = userForLoginDto,
			//	MyObjectLocalName = "userForLoginDto",
			//	MyObjecttypeofName = typeof(KisiLoginDto).Name,
			//	Description = "Kisi Başarılı bir şekilde Login oldu.",
			//});// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		}

		[HttpPost("EmailConfirm")]
		public async Task<ActionResult> EmailConfirmAsync([FromBody] Kisiler user)
		{
			if (user.KisiTipi == "TEA")
			{
				if (!await _authRepository.KisiOgretmenlerIsExistAsync(user.IdE))
					await _authRepository.AddToKisiOgretmenlerAsync(new KisiOgretmenler { OgretmenIdE = user.IdE, UzmanlikAlanlari = "pedagoji, eğitim" });
			}
			else if (user.KisiTipi == "STU")
			{
				if (!await _authRepository.KisiOgrencilerIsExistAsync(user.IdE))
					await _authRepository.AddToKisiOgrencilerAsync(new KisiOgrenciler { OgrenciIdE = user.IdE, IlgiAlanlari = "fizik, matematik, uzay" });
			}
			else if (user.KisiTipi == "ADM")
			{
				if (!await _authRepository.KisiAdminlerIsExistAsync(user.IdE))
					await _authRepository.AddToKisiAdminlerAsync(new KisiAdminler { AdminIdE = user.IdE, YetkiSeviye = 1 });
			}
			return new OkResult();
		}

		[HttpGet("KisilerList")]
		public async Task<IActionResult> KisilerListAsync()
		{
			var gelen = await Task.Run(() => _authRepository.KisilerListAsync());
			return Ok(gelen);
		}

		#region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
		[HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Kisiler newdata)
        {
            if (newdata == null) return Ok(_ControllersHelper.notfound("data is null"));

            _authRepository.Add(newdata); ////////////////////////////////////////

			var res = _authRepository.SaveAll();
			if (res.OK)
			{
				return Ok(newdata);
                //return CreatedAtRoute("Detail", new { identifier }, newdata);
            }
            else
                return BadRequest("başarısız?! " + res.ERR);
        }
        #endregion

        #region RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        [HttpGet]
        [Route("Kisiler")]
        public IActionResult Gets()
        {
            // System.Threading.Thread.Sleep(10000);

            var data = _authRepository.KisilerListAsync(); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<List<GetKisiDto>>(data);

            return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("Kisiler/{id}")]
        public IActionResult Get(int id)
        {
            //System.Threading.Thread.Sleep(10000);
            var data = _authRepository.GetKisilerByIdAsync(id); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<GetKisiDto>(data);

            if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));

            return Ok(_ControllersHelper.fixarray(dataToReturn));
        }
        #endregion

        #region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
        [HttpPut]
        [Route("Kisiler/update/{id}")]
        public IActionResult Update(int id, [FromBody] Kisiler newdata)
        {
            var olddata = _authRepository.GetKisilerByIdAsync(id);

            if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

            // _ControllersHelper.PrepareUpdate(typeof(ClsKisi), olddata, newdata);
            _ControllersHelper.PrepareUpdate(newdata.GetType(), olddata, newdata);
            // ikiside olur

            _authRepository.Update(olddata); ////////////////////////////////////////

			var res = _authRepository.SaveAll();
			if (res.OK)
				return Ok(olddata);
            else
                return BadRequest(id + " başarısız?! " + res.ERR);
        }
        #endregion

        #region DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        [HttpDelete]
        [Route("Kisiler/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _authRepository.GetKisilerByIdAsync(id);
            if (data == null) return Ok(_ControllersHelper.notfound(info: id));

            _authRepository.Delete(data); ////////////////////////////////////////

			var res = _authRepository.SaveAll();
			if (res.OK)
				return Ok(data);
            else
                return BadRequest(id + " başarısız?! " + res.ERR);
        }

        [HttpDelete]
        [Route("deleteall")]
        public async Task<IActionResult> DeleteAll()
        {
            var datas = await _authRepository.KisilerListAsync();

            foreach (var data in datas)
                _authRepository.Delete(data); ////////////////////////////////////////

			var res = _authRepository.SaveAll();
			if (res.OK)
				return Ok(datas);
            else
                return BadRequest("deleteall başarısız?! " + res.ERR);
        }

        [HttpDelete]
        [Route("deleterange({startId},{offsetId})")]
        public IActionResult DeleteRange(int startId, int offsetId)
        {
            return BadRequest("TEST: " + startId + "," + offsetId); // ok,succ
        }
        #endregion

    }
}