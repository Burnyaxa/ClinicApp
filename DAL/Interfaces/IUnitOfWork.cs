using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Appointment> Appointments { get; }
        IRepository<Doctor> Doctors { get; }
        IRepository<DoctorSchedule> DoctorSchedules { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Visit> Visits { get; }

        void Save();
        Task SaveAsync();
    }
}
