using AppointmentSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(string id);
        Task CreateAsync(Appointment appointment);
        Task<bool> UpdateAsync(string id, Appointment appointment);
        Task<bool> DeleteAsync(string id);
    }
}
