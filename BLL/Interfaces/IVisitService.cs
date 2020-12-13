using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitDTO>> GetAllVisits();
        Task<IEnumerable<VisitDTO>> GetAllVisitsByDoctorId(int id);
        Task<IEnumerable<VisitDTO>> GetAllVisitsByPatientId(int id);
        Task<VisitDTO> GetVisitById(int id);
        Task<VisitDTO> CreateVisit(VisitDTO visit);
        Task<VisitDTO> UpdateVisit(int id, VisitDTO visit);
        Task DeleteVisit(int id);
    }
}
