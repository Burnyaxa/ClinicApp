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
    public class AppointmentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IMapper mapper, IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            return Ok(await _appointmentService.GetAppointmentById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            return Ok(await _appointmentService.GetAllAppointments());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentCreateModel model)
        {
            var result = await _appointmentService.CreateAppointment(_mapper.Map<AppointmentDTO>(model));
            return CreatedAtAction(nameof(GetAppointmentById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentUpdateModel model)
        {
            await _appointmentService.UpdateAppointment(id, _mapper.Map<AppointmentDTO>(model));
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
        [Route("{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentsByDoctorId(int doctorId)
        {
            return Ok(await _appointmentService.GetAllAppointmentsByDoctorId(doctorId));
        }

        [Route("{doctorId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentsByPatientId(int patientId)
        {
            return Ok(await _appointmentService.GetAllAppointmentsByPatientId(patientId));
        }

    }
}
