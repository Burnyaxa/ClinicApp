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
    public class VisitService : IVisitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VisitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VisitDTO> CreateVisit(VisitDTO visitDTO)
        {
            var visit = _mapper.Map<Visit>(visitDTO);
            var result = _unitOfWork.VisitRepository.Insert(visit);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VisitDTO>(result);
        }

        public async Task DeleteVisit(int id)
        {
            var visit = await _unitOfWork.VisitRepository.GetByIdAsync(id);
            if (visit == null)
            {
                throw new EntityNotFoundException(nameof(visit), id);
            }

            _unitOfWork.VisitRepository.Delete(visit);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<VisitDTO>> GetAllVisits()
        {
            var visits = await _unitOfWork.VisitRepository.GetAllAsync();
            if (visits == null)
            {
                throw new EntityNotFoundException(nameof(visits), 0);
            }

            return _mapper.Map<IEnumerable<Visit>, IEnumerable<VisitDTO>>(await _unitOfWork.VisitRepository.GetAllAsync());
        }

        public async Task<IEnumerable<VisitDTO>> GetAllVisitsByDoctorId(int id)
        {
            var doctor = await _unitOfWork.DoctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                throw new EntityNotFoundException(nameof(doctor), id);
            }

            var visits = await _unitOfWork.VisitRepository.GetAllAsync(x => x.DoctorId == id);
            if (visits == null)
            {
                throw new EntityNotFoundException(nameof(visits), 0);
            }
            return _mapper.Map<IEnumerable<Visit>, IEnumerable<VisitDTO>>(visits);
        }

        public async Task<IEnumerable<VisitDTO>> GetAllVisitsByPatientId(int id)
        {
            var patient = await _unitOfWork.PatientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new EntityNotFoundException(nameof(patient), id);
            }

            var visits = await _unitOfWork.VisitRepository.GetAllAsync(x => x.PatientId == id);
            if (visits == null)
            {
                throw new EntityNotFoundException(nameof(visits), id);
            }

            return _mapper.Map<IEnumerable<Visit>, IEnumerable<VisitDTO>>(visits);
        }

        public async Task<VisitDTO> GetVisitById(int id)
        {
            var visit = await _unitOfWork.VisitRepository.GetByIdAsync(id);
            if (visit == null)
            {
                throw new EntityNotFoundException(nameof(visit), id);
            }

            var visitDTO = _mapper.Map<VisitDTO>(visit);
            return visitDTO;
        }

        public async Task<VisitDTO> UpdateVisit(int id, VisitDTO visitDTO)
        {
            var visit = await _unitOfWork.VisitRepository.GetByIdAsync(id);
            if (visit == null)
            {
                throw new EntityNotFoundException(nameof(visit), id);
            }

            visit.Date = visitDTO.Date;
            visit.DoctorId = visitDTO.DoctorId;
            visit.PatientId = visitDTO.PatientId;
            visit.Diagnosis = visitDTO.Diagnosis;
            visit.Note = visitDTO.Note;

            var result = _unitOfWork.VisitRepository.Update(visit);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VisitDTO>(result);
        }
    }
}
