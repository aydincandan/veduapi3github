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

// O g r e t m e n l e rController.cs IS master
namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OgrencilerController : BaseKisiController
	{
        //private IAppRepository _appRepository;
        //private IMapper _mapper;

        public OgrencilerController(IAppRepository appRepository, IMapper mapper) : base()
		{
            _appRepository = appRepository;
            _mapper = mapper;
        }

        #region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        [HttpPost]
        [Route("add")]
        public override IActionResult Add([FromBody] dynamic newdata)
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

        #region RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        [HttpGet]
        [Route("")]
        public override IActionResult GetOgrenciler()
        {
			var data = _appRepository.GetOgrenciler();
            var dataToReturn = _mapper.Map<List<GetOgrenciDto>>(data);
			return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("{id}")]
        public override IActionResult GetOgrencilerById(int id)
        {
            var data = _appRepository.GetOgrencilerById(id); ////////////////////////////////////////
            var dataToReturn = _mapper.Map<GetOgrenciDto>(data);
            if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));
            return Ok(_ControllersHelper.fixarray(dataToReturn));
        }
		#endregion

		#region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
		[HttpPut]
		[Route("update/{id}")]
		public override IActionResult Update(int id, [FromBody] dynamic newdata)
		{
			var olddata = _appRepository.GetOgrencilerById(id);

			if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

			if (true)
			{
				var varmi = olddata.Kisiler.Telefonlari.Exists(p => p.Telefonu == (string)newdata.telefon1);
				if (varmi == false)
				{
					foreach (var item in olddata.Kisiler.Telefonlari) { item.newcurrent = false; } // öncekilerin geçersizliği
																								   // yoksa olddata.Kisiler.Telefonlari ' na elenecek
					olddata.Kisiler.Telefonlari.Add(new KisiTelefonlar() { newcurrent = true, Telefonu = newdata.telefon1, UlkeKodu = "TR" });
				}
				olddata.Kisiler.Adi = newdata.Adi;
				olddata.Kisiler.Soyadi = newdata.Soyadi;
				olddata.Kisiler.TCkimlik = newdata.TCkimlik;
				olddata.Kisiler.Username = newdata.Username;
				olddata.IlgiAlanlari = newdata.IlgiAlanlari;
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
		public override IActionResult Delete(int id)
        {
            var data = _appRepository.GetOgrencilerById(id);
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
        public override IActionResult DeleteAll()
        {
            var datas = _appRepository.GetOgrenciler();

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
        public override IActionResult DeleteRange(int startId, int offsetId)
        {
            return BadRequest("TEST: " + startId + "," + offsetId); // ok,succ
        }
        #endregion



    }
}