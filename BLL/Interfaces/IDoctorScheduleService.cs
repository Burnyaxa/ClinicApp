using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDoctorScheduleService
    {
        Task<IEnumerable<DoctorScheduleDTO>> GetAllDoctorSchedules();
        Task<DoctorScheduleDTO> GetDoctorScheduleById(int id);
        Task<IEnumerable<DoctorScheduleDTO>> GetAllDoctorSchedulesByDoctorId(int id);
        Task<DoctorScheduleDTO> CreateDoctorSchedule(DoctorScheduleDTO doctorSchedule);
        Task<DoctorScheduleDTO> UpdateDoctorSchedule(int id, DoctorScheduleDTO doctorSchedule);
        Task DeleteDoctorSchedule(int id);
    }
}
