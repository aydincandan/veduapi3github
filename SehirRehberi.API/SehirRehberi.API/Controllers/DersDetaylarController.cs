using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Models;

// DersDetaylarController.cs IS master(SablonlarController.cs)
namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/DersDetaylar")]
    public class DersDetaylarController : Controller
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public DersDetaylarController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        #region CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        [HttpPost]
        [Route("add")]
        [Route("create")]
        [Route("ekle")]
        public ActionResult Add([FromBody]ClsDersDetay newdata)
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
        [Route("getall")]
        [Route("all")]
        [Route("list")]
        [Route("")]
        public ActionResult Gets()
        {
            // System.Threading.Thread.Sleep(10000);

            var data = _appRepository.GetDersDetaylar(); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<List<ClsDersDetay>>(data); // CityForListDto
            return Ok(dataToReturn);
        }

        [HttpGet]
        [Route("get/{id}")]
        [Route("{id}")] // /123
        [Route("d/{id}")] // /d/123
        [Route("detail/{id}")] // /detail/123
        [Route("d")] // /d?Id=123
        [Route("detail")] // /detail?Id=123
        public ActionResult Get(ClsDers id)
        {
            var data = _appRepository.GetDersDetayById(id); ////////////////////////////////////////

            var dataToReturn = _mapper.Map<ClsDersDetay>(data); // CityForDetailDto

            if (dataToReturn == null) return Ok(_ControllersHelper.notfound(info: id));

            return Ok(_ControllersHelper.fixarray(dataToReturn));
        }
        #endregion

        #region UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
        [HttpPut("{id}")]
        [Route("edit/{id}")]
        [Route("update/{id}")]
        public ActionResult Update(ClsDers id, [FromBody]ClsDersDetay newdata)
        {
            var olddata = _appRepository.GetDersDetayById(id);

            if (olddata == null) return Ok(_ControllersHelper.notfound(info: id));

            // _ControllersHelper.PrepareUpdate(typeof(ClsDersDetay), olddata, newdata);
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
        [Route("delete/{id}")] // böyle daha açık
        public ActionResult Delete(ClsDers id)
        {
            var data = _appRepository.GetDersDetayById(id);
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
            var datas = _appRepository.GetDersDetaylar();

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