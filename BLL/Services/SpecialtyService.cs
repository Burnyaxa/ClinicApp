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
using System.Linq;
namespace BLL.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SpecialtyDTO> GetAllSpectialties()
        {
            var doctors = await _unitOfWork.DoctorRepository.GetAllAsync();
            if(doctors == null)
            {
                throw new EntityNotFoundException(nameof(doctors), 0);
            }

            var doctorsDTO = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorDTO>>(doctors);
            List<string> specialties = doctorsDTO.Select(x => x.Specialty).Distinct().ToList();
            return new SpecialtyDTO { specialties = specialties };
        }
    }
}
