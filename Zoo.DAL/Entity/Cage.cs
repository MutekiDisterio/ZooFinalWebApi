using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Cage
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public int AnimalTypeId { get; set; } // INT NOT NULL, FOREIGN KEY

        // Навігаційна властивість до типу тварин
        public AnimalType AnimalType { get; set; } = null!; // Обов'язкова навігаційна властивість

        // Навігаційна властивість для Many-to-Many зв'язку з тваринами
        public ICollection<AnimalCage>? AnimalCages { get; set; }
    }
}
