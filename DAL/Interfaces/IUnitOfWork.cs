using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Appointment> AppointmentRepository { get; }
        IRepository<Doctor> DoctorRepository { get; }
        IRepository<DoctorSchedule> DoctorScheduleRepository { get; }
        IRepository<Patient> PatientRepository { get; }
        IRepository<Visit> VisitRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
