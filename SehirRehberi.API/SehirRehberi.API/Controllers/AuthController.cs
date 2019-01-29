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
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;
        private IMapper _mapper;

		private IAppRepository _appRepository;

		public AuthController(IAuthRepository authRepository, IConfiguration configuration, IMapper mapper, IAppRepository appRepository)
        {
            _authRepository = authRepository;
            _configuration = configuration;
            _mapper = mapper;

			_appRepository = appRepository;
		}

		[HttpGet("KisilerReset")]
		public List<Kisiler> KisilerReset()
		{
			this.DeleteAll();

			List<Kisiler> donus = new List<Kisiler>();

			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "admin@xmail.com", KisiTipi = "ADM", UserName = "admin", Password = "admin" }, true).Item2);

			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogrenci1@xmail.com", KisiTipi = "STU", UserName = "ogrenci1", Password = "ogrenci1" }, true).Item2);
			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogrenci2@xmail.com", KisiTipi = "STU", UserName = "ogrenci2", Password = "ogrenci2" }, true).Item2);
			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogrenci3@xmail.com", KisiTipi = "STU", UserName = "ogrenci3", Password = "ogrenci3" }, true).Item2);
			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogrenci4@xmail.com", KisiTipi = "STU", UserName = "ogrenci4", Password = "ogrenci4" }, true).Item2);
			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogrenci5@xmail.com", KisiTipi = "STU", UserName = "ogrenci5", Password = "ogrenci5" }, true).Item2);

			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogretmen1@xmail.com", KisiTipi = "TEA", UserName = "ogretmen1", Password = "ogretmen1" }, true).Item2);
			donus.Add(this.KISIYARAT(new KisiRegisterDto { Email = "ogretmen2@xmail.com", KisiTipi = "TEA", UserName = "ogretmen2", Password = "ogretmen2" }, true).Item2);



			//var datas = _appRepository.GetDersler();
			//foreach (var data in datas)
			//	_appRepository.Delete(data);

			//var res = _appRepository.SaveAll();
			//if (res.OK)
			{
				_appRepository.Add(new Dersler { Title = "Türkçe 1" });
				_appRepository.Add(new Dersler { Title = "Matematik 2" });
				_appRepository.Add(new Dersler { Title = "Fizik 2" });
				_appRepository.Add(new Dersler { Title = "Edebiyat 4" });
				_appRepository.Add(new Dersler { Title = "Sosyal Bilimler 1" });
				_appRepository.Add(new Dersler { Title = "Bilgisayar 5" });
				_appRepository.Add(new Dersler { Title = "Tarih 1" });
				_appRepository.SaveAll();
			}

			return donus;
		}

		private Tuple<int, Kisiler> KISIYARAT(KisiRegisterDto userForRegisterDto, bool EMconfirm)
		{
			var userToCreate = new Kisiler
			{
				KisiTipi = userForRegisterDto.KisiTipi,
				Email = userForRegisterDto.Email,
				Username = userForRegisterDto.UserName
			};
			var createdUser = _authRepository.KisiRegister(userToCreate, userForRegisterDto.Password);
			createdUser.RegisterDate = DateTime.Now;
			createdUser.RegisterDateIP = "1.1.1.1";
			createdUser.Username = _ControllersHelper.GetUsernameFromEmail(userToCreate.Email);
			int sonuc = _authRepository.UpdateToKisi(createdUser);

			if (sonuc > 0 && EMconfirm)
				this.EmailConfirm(createdUser);

			return new Tuple<int, Kisiler>(sonuc, createdUser);
		}

		[HttpPost("KisiRegister")]
        public ActionResult KisiRegister([FromBody] KisiRegisterDto userForRegisterDto)
        {
            if ( _authRepository.IsKisiUsernameExists(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("error", "Username already exists");
            }
            if ( _authRepository.IsKisiEmailExists(userForRegisterDto.Email))
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

			Tuple<int, Kisiler> kisiyarat = KISIYARAT(userForRegisterDto, false);
			int sonuc = kisiyarat.Item1;
			var createdUser = kisiyarat.Item2;

			if (sonuc > 0)
			{
				// evet user(kisi) yaratıldı. fakat KisiTipi ne göre ilişkili 1:1 alanları oluşturmadık. 
				 this.EmailConfirm(createdUser);
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
        public ActionResult KisiLogin([FromBody] KisiLoginDto userForLoginDto)
        {
            //

            var user =  _authRepository.KisiLogin(userForLoginDto.Email, userForLoginDto.Password);

            if (user == null) // emailine göre bulamadıysak
            {
                // bir de email olarak gelen bilgiyi username olarak aratalım
                var Kisi =  _authRepository.GetKisilerByUsername(username : userForLoginDto.Email);
                if (Kisi != null)
                {
                    user =  _authRepository.KisiLogin(Kisi.Email, userForLoginDto.Password);
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
            var track =  _authRepository.AddToLoginTracker(LT);
			// burada LoginTracker add yap

			//
			user.IsAnyLogin =  _authRepository.IsAnylogin(user.IdE);
			user.LastLoginDate =  _authRepository.GetLastlogin(user.IdE);
			int sonuc =  _authRepository.UpdateToKisi(user);
			//

			//// aslında EmailConfirm olayında gerçekleşmesi gereken durumu buraya geçici yazıyorum
			//// bir kere çalışması gerekiyor
			// this.EmailConfirm(user); // bunu buradan KisiRegister içine aldım
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
		public ActionResult EmailConfirm([FromBody] Kisiler user)
		{
			if (user.KisiTipi == "TEA")
			{
				if (! _authRepository.KisiOgretmenlerIsExist(user.IdE))
					 _authRepository.AddToKisiOgretmenler(new KisiOgretmenler { OgretmenIdE = user.IdE, UzmanlikAlanlari = "pedagoji, eğitim" });
			}
			else if (user.KisiTipi == "STU")
			{
				if (! _authRepository.KisiOgrencilerIsExist(user.IdE))
					 _authRepository.AddToKisiOgrenciler(new KisiOgrenciler { OgrenciIdE = user.IdE, IlgiAlanlari = "fizik, matematik, uzay" });
			}
			else if (user.KisiTipi == "ADM")
			{
				if (! _authRepository.KisiAdminlerIsExist(user.IdE))
					 _authRepository.AddToKisiAdminler(new KisiAdminler { AdminIdE = user.IdE, YetkiSeviye = 1 });
			}
			return new OkResult();
		}

		[HttpGet("KisilerList")]
		public IActionResult KisilerList()
		{
			var gelen = _authRepository.KisilerList();
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

            var data = _authRepository.KisilerList(); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<List<GetKisiDto>>(data);

            return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("Kisiler/{id}")]
        public IActionResult Get(int id)
        {
            //System.Threading.Thread.Sleep(10000);
            var data = _authRepository.GetKisilerById(id); ////////////////////////////////////////

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
            var olddata = _authRepository.GetKisilerById(id);

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
            var data = _authRepository.GetKisilerById(id);
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
        public IActionResult DeleteAll()
        {
            var datas =  _authRepository.KisilerList();

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