using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BLL.Exceptions;

namespace BLL.Services
{
    public class AppointmentTimeService : IAppointmentTimeService
    {
        private readonly TimeSpan _appointmentDuration = TimeSpan.FromMinutes(30);
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentTimeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentFreeTimeDTO> GetFreeHours(DateTime date, int id)
        {
            List<TimeSpan> freeTime = new List<TimeSpan>();
            Doctor doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id, "Schedules,Appointments");
            if(doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }
            IEnumerable<DoctorScheduleDTO> doctorSchedulesDTO = _mapper.Map<IEnumerable<DoctorSchedule>, IEnumerable<DoctorScheduleDTO>>(doctor.Schedules);
            IEnumerable<AppointmentDTO> appointmentsDTO = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(doctor.Appointments);
            string day = date.DayOfWeek.ToString();

            DoctorScheduleDTO doctorSchedule = doctorSchedulesDTO.Where(x => x.Day.ToString() == day).FirstOrDefault();
            if(doctorSchedule == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedule), id);
            }
            var appointments = appointmentsDTO.Where(x => (x.Date.Year == date.Year) && (x.Date.Month == date.Month) && (x.Date.Day == date.Day));
            
            for(TimeSpan current = doctorSchedule.StartTime; current < doctorSchedule.EndTime.Subtract(_appointmentDuration); current = current.Add(_appointmentDuration))
            {
                if(appointments == null)
                {
                    freeTime.Add(current);
                }
                else if(!appointments.Any(x => x.Date.Hour == current.Hours && x.Date.Minute == current.Minutes))
                {
                    freeTime.Add(current);
                }
            }

            return new AppointmentFreeTimeDTO { Date = date, DoctorId = id, FreeTime = freeTime };
        }
    }
}
