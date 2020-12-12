using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool disposed = false;

        IRepository<Appointment> _appointmentRepository;
        IRepository<Doctor> _doctorRepository;
        IRepository<DoctorSchedule> _doctorScheduleRepository;
        IRepository<Patient> _patientRepository;
        IRepository<Visit> _visitRepository;

        public UnitOfWork(ClinicDbContext context)
        {
            _context = context;
        }

        public IRepository<Appointment> AppointmentRepository => _appointmentRepository ??= new Repository<Appointment>(_context);
        public IRepository<Doctor> DoctorRepository => _doctorRepository ??= new Repository<Doctor>(_context);
        public IRepository<DoctorSchedule> DoctorScheduleRepository => _doctorScheduleRepository ??= new Repository<DoctorSchedule>(_context);
        public IRepository<Patient> PatientRepository => _patientRepository ??= new Repository<Patient>(_context);
        public IRepository<Visit> VisitRepository => _visitRepository ??= new Repository<Visit>(_context);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
