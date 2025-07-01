using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AppointmentSystem.Infrastructure
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IMongoCollection<Appointment> _appointments;
        public AppointmentRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoDbClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDbDatabase = mongoDbClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _appointments = mongoDbDatabase.GetCollection<Appointment>("Appointments");

        }
        public async Task CreateAsync(Appointment appointment) => await _appointments.InsertOneAsync(appointment);

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _appointments.DeleteOneAsync(x=>x.Id ==id);
            return result.IsAcknowledged&&result.DeletedCount>0;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() => await _appointments.Find(_ => true).ToListAsync();

        public async Task<Appointment?> GetByIdAsync(string id) => await _appointments.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(string id, Appointment appointment)
        {
            var result = await _appointments.ReplaceOneAsync(x=>x.Id==id,appointment);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
