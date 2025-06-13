using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Owner
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public string Name { get; set; } = string.Empty; // VARCHAR(50) NOT NULL
        public string PhoneNumber { get; set; } = string.Empty; // VARCHAR(15) NOT NULL
        public string? Address { get; set; } // VARCHAR(50) - може бути NULL

        // Навігаційна властивість для зв'язку з тваринами (один власник може мати багато тварин)
        public ICollection<Animal>? Animals { get; set; }
    }
}
