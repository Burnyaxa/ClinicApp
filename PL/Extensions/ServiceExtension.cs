using BLL.Interfaces;
using BLL.Services;
using DAL.Data;
using DAL.Interfaces;
using DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PL.Middlewares;

namespace PL.Extensions
{
    public static class ServiceExtension
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentTimeService, AppointmentTimeService>();
            services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ExceptionHandlerMiddleware>();
        }

        public static void AddClinicDb(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ClinicDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
