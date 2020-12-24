using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(IMapper mapper, ISpecialtyService specialtyService)
        {
            _mapper = mapper;
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialties()
        {
            return Ok(await _specialtyService.GetAllSpectialties());
        }
    }
}
