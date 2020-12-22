using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Mapping;
using PL.Models;

namespace PL.Mapping
{
    public class AppMappingProfile : MappingProfile
    {
        public AppMappingProfile()
        {
            CreateMap<PatientCreateModel, PatientDTO>();
            CreateMap<PatientUpdateModel, PatientDTO>();
            CreateMap<DoctorCreateModel, DoctorDTO>();
            CreateMap<DoctorUpdateModel, DoctorDTO>();
            CreateMap<VisitCreateModel, VisitDTO>();
            CreateMap<VisitUpdateModel, VisitDTO>();
            CreateMap<DoctorScheduleCreateModel, DoctorScheduleDTO>();
            CreateMap<DoctorScheduleUpdateModel, DoctorScheduleDTO>();
            CreateMap<AppointmentCreateModel, AppointmentDTO>();
            CreateMap<AppointmentUpdateModel, AppointmentDTO>();
            CreateMap<AppointmentFreeTimeModel, AppointmentDTO>();
        }
    }
}
