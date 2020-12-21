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
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PatientDTO> CreatePatient(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            var result = _unitOfWork.PatientRepository.Insert(patient);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PatientDTO>(result);
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), id);
            }

            _unitOfWork.PatientRepository.Delete(patient);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            var patients = await _unitOfWork.PatientRepository.GetAllAsync();
            if (patients == null)
            {
                throw new EntityNotFoundException(nameof(patients), 0);
            }

            return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientDTO>>(await _unitOfWork.PatientRepository.GetAllAsync());
        }

        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), id);
            }

            var patientDTO = _mapper.Map<PatientDTO>(patient);
            return patientDTO;
        }

        public async Task<PatientDTO> UpdatePatient(int id, PatientDTO patientDTO)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), id);
            }

            patient.BirthDate = patientDTO.BirthDate;
            patient.FirstName = patientDTO.FirstName;
            patient.LastName = patientDTO.LastName;
            patient.Patronymic = patientDTO.Patronymic;
            patient.PhoneNumber = patientDTO.PhoneNumber;

            var result = _unitOfWork.PatientRepository.Update(patient);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PatientDTO>(result);
        }
    }
}
