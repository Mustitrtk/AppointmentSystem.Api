using AppointmentSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(string id);
        Task CreateAppointmentAsync(Appointment appointment);
        Task<bool> UpdateAppointmentAsync(string id, Appointment appointment);
        Task<bool> DeleteAppointmentAsync(string id);
    }
}
