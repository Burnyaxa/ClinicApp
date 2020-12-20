using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointments();
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByDoctorId(int id);
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPatientId(int id);
        Task<AppointmentDTO> GetAppointmentById(int id);
        Task<AppointmentDTO> CreateAppointment(AppointmentDTO appointment);
        Task<AppointmentDTO> UpdateAppointment(int id, AppointmentDTO appointment);
        Task DeleteAppointment(int id);
    }
}
