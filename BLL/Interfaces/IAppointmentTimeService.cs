using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAppointmentTimeService
    {
        Task<AppointmentFreeTimeDTO> GetFreeHours(DateTime date, int id);
    }
}
