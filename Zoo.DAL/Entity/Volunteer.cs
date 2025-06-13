using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Volunteer
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public string Name { get; set; } = string.Empty; // VARCHAR(50) NOT NULL
        public string PhoneNumber { get; set; } = string.Empty; // VARCHAR(15) NOT NULL
        public string? Address { get; set; } // VARCHAR(50)

        public int? AnimalId { get; set; } // INT, може бути NULL, FOREIGN KEY
        public int DepartmentId { get; set; } // INT NOT NULL, FOREIGN KEY

        // Навігаційні властивості
        public Animal? Animal { get; set; } // Опціональна навігаційна властивість до тварини
        public VolunteerDepartment Department { get; set; } = null!; // Обов'язкова навігаційна властивість до відділу
    }
}
