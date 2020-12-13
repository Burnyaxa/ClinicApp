using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Entity to DTO
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dto => dto.DoctorFirstName, opt => opt.MapFrom(ent => ent.Doctor.FirstName))
                .ForMember(dto => dto.DoctorLastName, opt => opt.MapFrom(ent => ent.Doctor.LastName))
                .ForMember(dto => dto.DoctorPatronymic, opt => opt.MapFrom(ent => ent.Doctor.Patronymic))
                .ForMember(dto => dto.DoctorSpecialty, opt => opt.MapFrom(ent => ent.Doctor.Specialty))
                .ForMember(dto => dto.PatientFirstName, opt => opt.MapFrom(ent => ent.Patient.FirstName))
                .ForMember(dto => dto.PatientLastName, opt => opt.MapFrom(ent => ent.Patient.LastName))
                .ForMember(dto => dto.PatientPatronymic, opt => opt.MapFrom(ent => ent.Patient.Patronymic))
                .ForMember(dto => dto.PatientDateOfBirth, opt => opt.MapFrom(ent => ent.Patient.BirthDate));

            CreateMap<Visit, VisitDTO>()
                .ForMember(dto => dto.DoctorFirstName, opt => opt.MapFrom(ent => ent.Doctor.FirstName))
                .ForMember(dto => dto.DoctorLastName, opt => opt.MapFrom(ent => ent.Doctor.LastName))
                .ForMember(dto => dto.DoctorPatronymic, opt => opt.MapFrom(ent => ent.Doctor.Patronymic))
                .ForMember(dto => dto.DoctorSpecialty, opt => opt.MapFrom(ent => ent.Doctor.Specialty))
                .ForMember(dto => dto.PatientFirstName, opt => opt.MapFrom(ent => ent.Patient.FirstName))
                .ForMember(dto => dto.PatientLastName, opt => opt.MapFrom(ent => ent.Patient.LastName))
                .ForMember(dto => dto.PatientPatronymic, opt => opt.MapFrom(ent => ent.Patient.Patronymic))
                .ForMember(dto => dto.PatientDateOfBirth, opt => opt.MapFrom(ent => ent.Patient.BirthDate));

            CreateMap<DoctorSchedule, DoctorScheduleDTO>()
                .ForMember(dto => dto.DoctorFirstName, opt => opt.MapFrom(ent => ent.Doctor.FirstName))
                .ForMember(dto => dto.DoctorLastName, opt => opt.MapFrom(ent => ent.Doctor.LastName))
                .ForMember(dto => dto.DoctorPatronymic, opt => opt.MapFrom(ent => ent.Doctor.Patronymic))
                .ForMember(dto => dto.DoctorSpecialty, opt => opt.MapFrom(ent => ent.Doctor.Specialty));

            CreateMap<Doctor, DoctorDTO>();
            CreateMap<Patient, PatientDTO>();


        }
    }
}
