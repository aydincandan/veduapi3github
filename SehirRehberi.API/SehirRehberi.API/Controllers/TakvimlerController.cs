using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Models;


namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TakvimlerController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public TakvimlerController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        #region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        [HttpPost]
        [Route("add")]
        [Route("create")]
        [Route("ekle")]
        public IActionResult Add([FromBody] Takvimler newdata)
        {
            if (newdata == null) return Ok(_ControllersHelper.notfound("data is null"));

            _appRepository.Add(newdata); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(newdata);
            else
                return BadRequest("başarısız?! " + res.ERR);
        }
        #endregion

        #region RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        [HttpGet]
        [Route("getall")]
        [Route("all")]
        [Route("list")]
        [Route("")]
        public IActionResult Gets()
        {
            // System.Threading.Thread.Sleep(10000);

            var data = _appRepository.GetTakvimler(); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<List<Takvimler>>(data); // CityForListDto
            return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("get/{id}")]
        [Route("{id}")] // /123
        [Route("d/{id}")] // /d/123
        [Route("detail/{id}")] // /detail/123
        [Route("d")] // /d?Id=123
        [Route("detail")] // /detail?Id=123
        public IActionResult Get(int id)
        {
            var data = _appRepository.GetTakvimlerById(id); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<Takvimler>(data); // CityForDetailDto

            if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));

            return Ok(_ControllersHelper.fixarray(dataToReturn));
        }
        #endregion

        #region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
        [HttpPut("{id}")]
        [Route("edit/{id}")]
        [Route("update/{id}")]
        public IActionResult Update(int id, [FromBody]Takvimler newdata)
        {
            var olddata = _appRepository.GetTakvimlerById(id);

            if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

         // _ControllersHelper.PrepareUpdate(typeof(ClsTakvim), olddata, newdata);
            _ControllersHelper.PrepareUpdate(newdata.GetType(), olddata, newdata);
            // ikiside olur

            _appRepository.Update(olddata); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(olddata);
            else
                return BadRequest(id + " başarısız?! " + res.ERR);
        }
        #endregion

        #region DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        [HttpDelete] // Route koymadan bu şekilde silme işlemi riskli  HttpDelete("{id}")
        [Route("delete/{id}")] // böyle daha açık
        public IActionResult Delete(int id)
        {
            var data = _appRepository.GetTakvimlerById(id);
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
        public IActionResult DeleteAll()
        {
            var datas = _appRepository.GetTakvimler();

            foreach (var data in datas)
                _appRepository.Delete(data); ////////////////////////////////////////

			var res = _appRepository.SaveAll();
			if (res.OK)
				return Ok(datas);
            else
                return BadRequest("deleteall başarısız?! "+ res.ERR);
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