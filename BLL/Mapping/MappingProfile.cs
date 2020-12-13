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
            // Entity to DTO
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

            // DTO to Entity
            CreateMap<DoctorDTO, Doctor>()
                .ForMember(ent => ent.FirstName, opt => opt.MapFrom(dto => dto.FirstName))
                .ForMember(ent => ent.LastName, opt => opt.MapFrom(dto => dto.LastName))
                .ForMember(ent => ent.Patronymic, opt => opt.MapFrom(dto => dto.Patronymic))
                .ForMember(ent => ent.PhoneNumber, opt => opt.MapFrom(dto => dto.PhoneNumber))
                .ForMember(ent => ent.Address, opt => opt.MapFrom(dto => dto.Address))
                .ForMember(ent => ent.Specialty, opt => opt.MapFrom(dto => dto.Specialty))
                .ForMember(ent => ent.Cabinet, opt => opt.MapFrom(dto => dto.Cabinet))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PatientDTO, Patient>()
                .ForMember(ent => ent.FirstName, opt => opt.MapFrom(dto => dto.FirstName))
                .ForMember(ent => ent.LastName, opt => opt.MapFrom(dto => dto.LastName))
                .ForMember(ent => ent.Patronymic, opt => opt.MapFrom(dto => dto.Patronymic))
                .ForMember(ent => ent.PhoneNumber, opt => opt.MapFrom(dto => dto.PhoneNumber))
                .ForMember(ent => ent.BirthDate, opt => opt.MapFrom(dto => dto.BirthDate))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<AppointmentDTO, Appointment>()
                .ForMember(ent => ent.PatientId, opt => opt.MapFrom(dto => dto.PatientId))
                .ForMember(ent => ent.DoctorId, opt => opt.MapFrom(dto => dto.DoctorId))
                .ForMember(ent => ent.Date, opt => opt.MapFrom(dto => dto.Date))
                .ForMember(ent => ent.Status, opt => opt.MapFrom(dto => dto.Status))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<VisitDTO, Visit>()
                .ForMember(ent => ent.PatientId, opt => opt.MapFrom(dto => dto.PatientId))
                .ForMember(ent => ent.DoctorId, opt => opt.MapFrom(dto => dto.DoctorId))
                .ForMember(ent => ent.Date, opt => opt.MapFrom(dto => dto.Date))
                .ForMember(ent => ent.Diagnosis, opt => opt.MapFrom(dto => dto.Diagnosis))
                .ForMember(ent => ent.Note, opt => opt.MapFrom(dto => dto.Note))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<DoctorScheduleDTO, DoctorSchedule>()
                .ForMember(ent => ent.DoctorId, opt => opt.MapFrom(dto => dto.DoctorId))
                .ForMember(ent => ent.Day, opt => opt.MapFrom(dto => dto.Day))
                .ForMember(ent => ent.StartTime, opt => opt.MapFrom(dto => dto.StartTime))
                .ForMember(ent => ent.EndTime, opt => opt.MapFrom(dto => dto.EndTime))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
