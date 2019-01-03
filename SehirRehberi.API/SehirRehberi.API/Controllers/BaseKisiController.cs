using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

// B a s e K i s iController.cs IS master
namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseKisiController : Controller
    {
        public IAppRepository _appRepository;
		public IMapper _mapper;

        public BaseKisiController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

		public BaseKisiController() { }

		#region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
		[HttpPost]
        [Route("add")]
        public virtual IActionResult Add([FromBody] dynamic newdata)
        {
            if (newdata == null) return Ok(_ControllersHelper.notfound("data is null"));

            _appRepository.Add(newdata); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
			{
				return Ok(newdata);
                //return CreatedAtRoute("Detail", new { identifier }, newdata);
            }
            else
                return BadRequest("başarısız?! " + res.ERR);
        }
		#endregion

		// https://docs.microsoft.com/tr-tr/aspnet/core/web-api/action-return-types?view=aspnetcore-2.2
		#region RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
		[HttpGet]
		[Route("kisiler")]
		public virtual IActionResult GetKisiler()
		{
			var data = _appRepository.GetKisiler();
			var dataToReturn = _mapper.Map<List<GetKisiDto>>(data);
			return Ok(dataToReturn);
		}
		[HttpGet]
		[Route("kisiler/{id}")]
		public virtual IActionResult GetKisilerById(int id)
		{
			var data = _appRepository.GetKisilerById(id);
			var dataToReturn = _mapper.Map<GetKisiDto>(data);
			if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));
			return Ok(_ControllersHelper.fixarray(dataToReturn));
		}

		[HttpGet]
		[Route("ogrenciler")]
		public virtual IActionResult GetOgrenciler()
		{
			// System.Threading.Thread.Sleep(10000);
			var data = _appRepository.GetOgrenciler();
			var dataToReturn = _mapper.Map<List<GetOgrenciDto>>(data);
			return Ok(dataToReturn);
		}
		[HttpGet]
		[Route("ogrenciler/{id}")]
		public virtual IActionResult GetOgrencilerById(int id)
		{
			var data = _appRepository.GetOgrencilerById(id);
			var dataToReturn = _mapper.Map<GetOgrenciDto>(data);
			if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));
			return Ok(_ControllersHelper.fixarray(dataToReturn));
		}

		[HttpGet]
		[Route("ogretmenler")]
		public virtual IActionResult GetOgretmenler()
		{
			var data = _appRepository.GetOgretmenler();
			var dataToReturn = _mapper.Map<List<GetOgretmenDto>>(data);
			return Ok(dataToReturn);
		}
		[HttpGet]
		[Route("ogretmenler/{id}")]
		public virtual IActionResult GetOgretmenlerById(int id)
		{
			var data = _appRepository.GetOgretmenlerById(id);
			var dataToReturn = _mapper.Map<GetOgretmenDto>(data);
			if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));
			return Ok(_ControllersHelper.fixarray(dataToReturn));
		}

		[HttpGet]
		[Route("adminler")]
		public virtual IActionResult GetAdminler()
		{
			var data = _appRepository.GetAdminler();
			var dataToReturn = _mapper.Map<List<GetAdminDto>>(data);
			return Ok(dataToReturn);
		}
		[HttpGet]
		[Route("adminler/{id}")]
		public virtual IActionResult GetAdminlerById(int id)
		{
			var data = _appRepository.GetAdminlerById(id);
			var dataToReturn = _mapper.Map<GetAdminDto>(data);
			if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));
			return Ok(_ControllersHelper.fixarray(dataToReturn));
		}
		#endregion

		#region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
		[HttpPut]
        [Route("update/{id}")]
        public virtual IActionResult Update(int id, [FromBody] dynamic newdata)
        {
            var olddata = _appRepository.GetKisilerById(id);

            if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

            if (true)
            {
				var varmi = olddata.Telefonlari.Exists(p => p.Telefonu == (string)newdata.telefon1);
				if (varmi == false)
                {
                    foreach (var item in olddata.Telefonlari) { item.newcurrent = false; } // öncekilerin geçersizliği
                    // yoksa olddata.Kisiler.Telefonlari ' na elenecek
                    olddata.Telefonlari.Add(new KisiTelefonlar() { newcurrent = true, Telefonu = newdata.telefon1, UlkeKodu = "TR" });
                }
                olddata.Adi = newdata.Adi;
                olddata.Soyadi = newdata.Soyadi;
                olddata.TCkimlik = newdata.TCkimlik;
                olddata.Username = newdata.Username;
                //olddata.UzmanlikAlanlari = newdata.UzmanlikAlanlari;
            }
            else
            {
                // _ControllersHelper.PrepareUpdate(typeof(ClsKisi), olddata, newdata);
                // [alt sınıfların içine girerek geliştirilmesi gerekiyor] _ControllersHelper.PrepareUpdate(newdata.GetType(), olddata, newdata);
                // ikiside olur
            }

            _appRepository.Update(olddata); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(olddata);
            else
                return BadRequest(id + " başarısız?! " + res.ERR);
        }
        #endregion

        #region DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        [HttpDelete]
        [Route("delete/{id}")]
        public virtual IActionResult Delete(int id)
        {
            var data = _appRepository.GetKisilerById(id);
            if (data == null) return Ok(_ControllersHelper.notfound(info: id));

            _appRepository.Delete(data); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(data);
            else
                return BadRequest(id + " başarısız?! " + res.ERR);
        }

        [HttpDelete]
        [Route("deleteall")]
        public virtual IActionResult DeleteAll()
        {
            var datas = _appRepository.GetKisiler();

            foreach (var data in datas)
                _appRepository.Delete(data); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(datas);
            else
                return BadRequest("deleteall başarısız?! " + res.ERR);
        }

        [HttpDelete]
        [Route("deleterange({startId},{offsetId})")]
        public virtual IActionResult DeleteRange(int startId, int offsetId)
        {
            return BadRequest("TEST: " + startId + "," + offsetId); // ok,succ
        }
        #endregion



    }
}