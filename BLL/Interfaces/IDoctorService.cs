using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>> GetAllDoctors();
        Task<DoctorDTO> GetDoctorById(int id);
        Task<DoctorDTO> CreateDoctor(DoctorDTO doctor);
        Task<DoctorDTO> UpdateDoctor(int id, DoctorDTO doctor);
        Task DeleteDoctor(int id);
    }
}
