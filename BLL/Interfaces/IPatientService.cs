using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatients();
        Task<PatientDTO> GetPatientById(int id);
        Task<PatientDTO> CreatePatient(PatientDTO patient);
        Task<PatientDTO> UpdatePatient(int id, PatientDTO patient);
        Task DeletePatient(int id);
    }
}
