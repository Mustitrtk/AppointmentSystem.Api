using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppointmentSystem.Core.Entities
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("FullName")]
        public string FullName { get; set; } = null!;

        [BsonElement("Description")]
        public string? Description { get; set; }

        [BsonElement("AppointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
