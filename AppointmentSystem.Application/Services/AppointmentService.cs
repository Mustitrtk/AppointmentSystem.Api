using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSystem.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync() =>
            await _appointmentRepository.GetAllAsync();

        public async Task<Appointment?> GetAppointmentByIdAsync(string id) =>
            await _appointmentRepository.GetByIdAsync(id);

        public async Task CreateAppointmentAsync(Appointment appointment) =>
            await _appointmentRepository.CreateAsync(appointment);

        public async Task<bool> UpdateAppointmentAsync(string id, Appointment appointment) =>
            await _appointmentRepository.UpdateAsync(id, appointment);

        public async Task<bool> DeleteAppointmentAsync(string id) =>
            await _appointmentRepository.DeleteAsync(id);
    }
}
