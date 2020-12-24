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
            CreateMap<DoctorScheduleCreateModel, DoctorScheduleDTO>()
                .ForMember(dto => dto.StartTime,
                opt => opt.MapFrom(
                    model => TimeSpan.FromHours(
                        Convert.ToInt32(
                    model.StartTime.Split(':', StringSplitOptions.None)[0]))
                .Add(TimeSpan.FromMinutes(
                    Convert.ToInt32(
                        model.StartTime.Split(':', StringSplitOptions.None)[1])))))
                .ForMember(dto => dto.EndTime,
                opt => opt.MapFrom(
                    model => TimeSpan.FromHours(
                        Convert.ToInt32(
                    model.EndTime.Split(':', StringSplitOptions.None)[0]))
                .Add(TimeSpan.FromMinutes(
                    Convert.ToInt32(
                        model.EndTime.Split(':', StringSplitOptions.None)[1])))));
            CreateMap<DoctorScheduleUpdateModel, DoctorScheduleDTO>()
                 .ForMember(dto => dto.StartTime,
                opt => opt.MapFrom(
                    model => TimeSpan.FromHours(
                        Convert.ToInt32(
                    model.StartTime.Split(':', StringSplitOptions.None)[0]))
                .Add(TimeSpan.FromMinutes(
                    Convert.ToInt32(
                        model.StartTime.Split(':', StringSplitOptions.None)[1])))))
                .ForMember(dto => dto.EndTime,
                opt => opt.MapFrom(
                    model => TimeSpan.FromHours(
                        Convert.ToInt32(
                    model.EndTime.Split(':', StringSplitOptions.None)[0]))
                .Add(TimeSpan.FromMinutes(
                    Convert.ToInt32(
                        model.EndTime.Split(':', StringSplitOptions.None)[1])))));
            CreateMap<AppointmentCreateModel, AppointmentDTO>();
            CreateMap<AppointmentUpdateModel, AppointmentDTO>();
            CreateMap<AppointmentFreeTimeModel, AppointmentDTO>();
        }
    }
}
