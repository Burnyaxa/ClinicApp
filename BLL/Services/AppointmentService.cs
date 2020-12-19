using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentDTO)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDTO);
            var result = _unitOfWork.AppointmentRepository.Insert(appointment);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AppointmentDTO>(result);
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            _unitOfWork.AppointmentRepository.Delete(appointment);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointments()
        {
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(await _unitOfWork.AppointmentRepository.GetAllAsync());
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorId(int id)
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync(x => x.DoctorId == id);
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPatientId(int id)
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync(x => x.PatientId == id);
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            var appointmentDTO = _mapper.Map<AppointmentDTO>(appointment);
            return appointmentDTO;
        }

        public async Task<AppointmentDTO> UpdateAppointment(int id, AppointmentDTO appointmentDTO)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);

            appointment.Date = appointmentDTO.Date;
            appointment.DoctorId = appointmentDTO.DoctorId;
            appointment.PatientId = appointmentDTO.PatientId;
            appointment.Status = appointmentDTO.Status;

            var result = _unitOfWork.AppointmentRepository.Update(appointment);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AppointmentDTO>(result);
        }
    }
}
