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
    public class FreeTimeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentTimeService _freeTimeService;

        public FreeTimeController(IMapper mapper, IAppointmentTimeService freeTimeService)
        {
            _mapper = mapper;
            _freeTimeService = freeTimeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFreeTimeByDateAndDoctorId(DateTime date, int doctorId)
        {
            return Ok(await _freeTimeService.GetFreeHours(date, doctorId));
        }
    }

}
