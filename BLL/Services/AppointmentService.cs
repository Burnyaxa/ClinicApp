using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
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
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(appointmentDTO.DoctorId);
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(appointmentDTO.PatientId);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), appointmentDTO.DoctorId);
            }
            if(patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), appointmentDTO.PatientId);
            }
            var appointment = _mapper.Map<Appointment>(appointmentDTO);
            var result = _unitOfWork.AppointmentRepository.Insert(appointment);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AppointmentDTO>(result);
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if(appointment == null)
            {
                throw new EntityNotFoundException(nameof(appointment), id);
            }
            _unitOfWork.AppointmentRepository.Delete(appointment);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointments()
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync();
            if(appointments == null)
            {
                throw new EntityNotFoundException(nameof(appointments), 0);
            }
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorId(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if(doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync(x => x.DoctorId == id);
            if(appointments == null)
            {
                throw new EntityNotFoundException(nameof(appointments), id);
            }
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPatientId(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), id);
            }
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync(x => x.PatientId == id);
            if (appointments == null)
            {
                throw new EntityNotFoundException(nameof(appointments), id);
            }
            return _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<AppointmentDTO> GetAppointmentById(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if(appointment == null)
            {
                throw new EntityNotFoundException(nameof(appointment), id);
            }
            var appointmentDTO = _mapper.Map<AppointmentDTO>(appointment);
            return appointmentDTO;
        }

        public async Task<AppointmentDTO> UpdateAppointment(int id, AppointmentDTO appointmentDTO)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                throw new EntityNotFoundException(nameof(appointment), id);
            }

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
