using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
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
    public class DoctorSchedulesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorScheduleService _doctorScheduleService;

        public DoctorSchedulesController(IMapper mapper, IDoctorScheduleService doctorScheduleService)
        {
            _mapper = mapper;
            _doctorScheduleService = doctorScheduleService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDoctorScheduleById(int id)
        {
            return Ok(await _doctorScheduleService.GetDoctorScheduleById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorSchedules()
        {
            return Ok(await _doctorScheduleService.GetAllDoctorSchedules());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorSchedule([FromBody] DoctorScheduleCreateModel model)
        {
            var result = await _doctorScheduleService.CreateDoctorSchedule(_mapper.Map<DoctorScheduleDTO>(model));
            return CreatedAtAction(nameof(GetDoctorScheduleById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDoctorSchedule(int id, [FromBody] DoctorScheduleUpdateModel model)
        {
            await _doctorScheduleService.UpdateDoctorSchedule(id, _mapper.Map<DoctorScheduleDTO>(model));
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDoctorSchedule(int id)
        {
            await _doctorScheduleService.DeleteDoctorSchedule(id);
            return NoContent();
        }

        [HttpGet]
        [Route("doctor/{doctorId}")]
        public async Task<IActionResult> GetAllDoctorScheduleeByDoctorId(int doctorId)
        {
            return Ok(await _doctorScheduleService.GetAllDoctorSchedulesByDoctorId(doctorId));
        }
    }
}
