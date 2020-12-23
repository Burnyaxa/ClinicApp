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
    public class VisitsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVisitService _visitService;

        public VisitsController(IMapper mapper, IVisitService visitService)
        {
            _mapper = mapper;
            _visitService = visitService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            return Ok(await _visitService.GetVisitById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisits()
        {
            return Ok(await _visitService.GetAllVisits());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] VisitCreateModel model)
        {
            var result = await _visitService.CreateVisit(_mapper.Map<VisitDTO>(model));
            return CreatedAtAction(nameof(GetVisitById), new
            {
                id = result.Id
            }, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVisit(int id, [FromBody] VisitUpdateModel model)
        {
            await _visitService.UpdateVisit(id, _mapper.Map<VisitDTO>(model));
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            await _visitService.DeleteVisit(id);
            return NoContent();
        }
        [Route("{doctorId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllVisitsByDoctorId(int doctorId)
        {
            return Ok(await _visitService.GetAllVisitsByDoctorId(doctorId));
        }
        [Route("{patientId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllVisitsByPatientId(int patientId)
        {
            return Ok(await _visitService.GetAllVisitsByPatientId(patientId));
        }
    }
}
