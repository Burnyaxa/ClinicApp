using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;

        public DoctorsController(IMapper mapper, IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            return Ok(await _doctorService.GetDoctorById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            return Ok(await _doctorService.GetAllDoctors());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorCreateModel model)
        {
            var result = await _doctorService.CreateDoctor(_mapper.Map<DoctorDTO>(model));
            return CreatedAtAction(nameof(GetDoctorById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorUpdateModel model)
        {
            await _doctorService.UpdateDoctor(id, _mapper.Map<DoctorDTO>(model));
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}
