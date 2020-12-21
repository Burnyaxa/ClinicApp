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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DoctorDTO> CreateDoctor(DoctorDTO doctorDTO)
        {
            var doctor = _mapper.Map<Doctor>(doctorDTO);
            var result = _unitOfWork.DoctorRepository.Insert(doctor);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DoctorDTO>(result);
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }

            _unitOfWork.DoctorRepository.Delete(doctor);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctors()
        {
            var doctors = await _unitOfWork.DoctorRepository.GetAllAsync();
             if (doctors == null)
            {
                throw new EntityNotFoundException(nameof(doctors), 0);
            }
            return _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }

            var doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            return doctorDTO;
        }

        public async Task<DoctorDTO> UpdateDoctor(int id, DoctorDTO doctorDTO)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }

            doctor.PhoneNumber = doctorDTO.PhoneNumber;
            doctor.FirstName = doctorDTO.FirstName;
            doctor.LastName = doctorDTO.LastName;
            doctor.Patronymic = doctorDTO.Patronymic;
            doctor.Specialty = doctorDTO.Specialty;
            doctor.Cabinet = doctorDTO.Cabinet;
            doctor.Address = doctorDTO.Address;
        
            var result = _unitOfWork.DoctorRepository.Update(doctor);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<DoctorDTO>(result);
        }
    }
}
