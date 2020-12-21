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
    public class PatientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientsController(IMapper mapper, IPatientService patientService)
        {
            _mapper = mapper;
            _patientService = patientService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            return Ok(await _patientService.GetPatientById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            return Ok(await _patientService.GetAllPatients());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateModel model)
        {
            var result = await _patientService.CreatePatient(_mapper.Map<PatientDTO>(model));
            return CreatedAtAction(nameof(GetPatientById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] PatientUpdateModel model)
        {
            await _patientService.UpdatePatient(id, _mapper.Map<PatientDTO>(model));
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
