using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Models;

// IceriklerController.cs IS master(SablonlarController.cs)
namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Icerikler")]
    public class IceriklerController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public IceriklerController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        #region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        [HttpPost]
        [Route("add")]
        [Route("create")]
        [Route("ekle")]
        public ActionResult Add([FromBody]ClsIcerik newdata)
        {
            if (newdata == null) return Ok(_ControllersHelper.notfound("data is null"));

            _appRepository.Add(newdata); ////////////////////////////////////////

            if (_appRepository.SaveAll())
                return Ok(newdata);
            else
                return BadRequest("başarısız?!");
        }
        #endregion

        #region RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        [HttpGet]
        [Route("gets/{ktKod}")]
        [Route("list/{ktKod}")]
        [Route("{ktKod}")]
        public ActionResult Gets(string ktKod)
        {
            // System.Threading.Thread.Sleep(10000);

            var data = _appRepository.GetIcerikler(ktKod); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<List<ClsIcerik>>(data); // CityForListDto
            return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("get/{ktKod}/{id}")]
        [Route("{ktKod}/{id}")]
        public ActionResult Get(string ktKod, int id)
        {
            var data = _appRepository.GetIcerikById(ktKod, id); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<ClsIcerik>(data); // CityForDetailDto

            if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));

            return Ok(_ControllersHelper.fixarray(dataToReturn));
        }
        #endregion

        #region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
        [HttpPut]
        [Route("update/{ktKod}/{id}")]
        [Route("{ktKod}/{id}")]
        public ActionResult Update(string ktKod, int id, [FromBody]Kisiler newdata)
        {
            var olddata = _appRepository.GetIcerikById(ktKod, id);

            if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

            // _ControllersHelper.PrepareUpdate(typeof(ClsIcerik), olddata, newdata);
            _ControllersHelper.PrepareUpdate(newdata.GetType(), olddata, newdata);
            // ikiside olur

            _appRepository.Update(olddata); ////////////////////////////////////////

            if (_appRepository.SaveAll())
                return Ok(olddata);
            else
                return BadRequest(id + " başarısız?!");
        }
        #endregion

        #region DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
        [HttpDelete] // Route koymadan bu şekilde silme işlemi riskli  HttpDelete("{id}")
        [Route("delete/{ktKod}/{id}")] // böyle daha açık
        [Route("{ktKod}/{id}")]
        public ActionResult Delete(string ktKod, int id)
        {
            var data = _appRepository.GetIcerikById(ktKod, id);
            if (data == null) return Ok(_ControllersHelper.notfound(info: id));

            _appRepository.Delete(data); ////////////////////////////////////////

            if (_appRepository.SaveAll())
                return Ok(data);
            else
                return BadRequest(id + " başarısız?!");
        }
        [HttpDelete]
        [Route("deleteall")]
        public ActionResult DeleteAll()
        {
            var datas = _appRepository.GetIcerikler(null);

            foreach (var data in datas)
                _appRepository.Delete(data); ////////////////////////////////////////

            if (_appRepository.SaveAll())
                return Ok(datas);
            else
                return BadRequest("deleteall başarısız?!");
        }
        [HttpDelete]
        [Route("deleterange({startId},{offsetId})")]
        public ActionResult DeleteRange(int startId, int offsetId)
        {
            return BadRequest("TEST: " + startId + "," + offsetId); // ok,succ
        }
        #endregion



    }
}