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
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorScheduleDTO> CreateDoctorSchedule(DoctorScheduleDTO doctorScheduleDTO)
        {
            var doctorSchedule = _mapper.Map<DoctorSchedule>(doctorScheduleDTO);
            var result = _unitOfWork.DoctorScheduleRepository.Insert(doctorSchedule);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DoctorScheduleDTO>(result);
        }

        public async Task DeleteDoctorSchedule(int id)
        {
            var doctorSchedule = await _unitOfWork.DoctorScheduleRepository.GetByIdAsync(id);
            if(doctorSchedule == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedule), id);
            }
            _unitOfWork.DoctorScheduleRepository.Delete(doctorSchedule);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DoctorScheduleDTO>> GetAllDoctorSchedules()
        {
            var doctorSchedule = await _unitOfWork.DoctorScheduleRepository.GetAllAsync();
            if (doctorSchedule == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedule), 0);
            }
            return _mapper.Map<IEnumerable<DoctorSchedule>, IEnumerable<DoctorScheduleDTO>>(await _unitOfWork.DoctorScheduleRepository.GetAllAsync());
        }

        public async Task<IEnumerable<DoctorScheduleDTO>> GetAllDoctorSchedulesByDoctorId(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }

            var doctorSchedules = await _unitOfWork.DoctorScheduleRepository.GetAllAsync(x => x.DoctorId == id);
            if (doctorSchedules == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedules), id);
            }

            return _mapper.Map<IEnumerable<DoctorSchedule>, IEnumerable<DoctorScheduleDTO>>(doctorSchedules);
        }

        public async Task<DoctorScheduleDTO> GetDoctorScheduleById(int id)
        {
            var doctorSchedule = await _unitOfWork.DoctorScheduleRepository.GetByIdAsync(id);
            if (doctorSchedule == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedule), id);
            }

            var doctorScheduleDTO = _mapper.Map<DoctorScheduleDTO>(doctorSchedule);
            return doctorScheduleDTO;
        }

        public async Task<DoctorScheduleDTO> UpdateDoctorSchedule(int id, DoctorScheduleDTO doctorScheduleDTO)
        {
            var doctorSchedule = await _unitOfWork.DoctorScheduleRepository.GetByIdAsync(id);
            if (doctorSchedule == null)
            {
                throw new EntityNotFoundException(nameof(doctorSchedule), id);
            }

            doctorSchedule.DoctorId = doctorScheduleDTO.DoctorId;
            doctorSchedule.Day = doctorScheduleDTO.Day;
            doctorSchedule.StartTime = doctorScheduleDTO.StartTime;
            doctorSchedule.EndTime = doctorScheduleDTO.EndTime;

            var result = _unitOfWork.DoctorScheduleRepository.Update(doctorSchedule);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DoctorScheduleDTO>(result);
        }
    }
}
