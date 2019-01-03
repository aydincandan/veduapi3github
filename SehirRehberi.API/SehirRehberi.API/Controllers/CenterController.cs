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
    public class CenterController : BaseKisiController
	{
        //private IAppRepository _appRepository;
        //private IMapper _mapper;

        public CenterController(IAppRepository appRepository, IMapper mapper) : base()
		{
            _appRepository = appRepository;
            _mapper = mapper;
        }

	}
}