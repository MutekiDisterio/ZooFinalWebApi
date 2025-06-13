using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Animal
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public string Name { get; set; } = string.Empty; // VARCHAR(30) NOT NULL
        public DateOnly BirthDate { get; set; } // DATE NOT NULL (використовуємо DateOnly для дати без часу)
        public int? OwnerId { get; set; } // INT, може бути NULL, FOREIGN KEY
        public int AnimalTypeId { get; set; } // INT NOT NULL, FOREIGN KEY

        // Навігаційні властивості
        public Owner? Owner { get; set; } // Опціональна навігаційна властивість до власника
        public AnimalType AnimalType { get; set; } = null!; // Обов'язкова навігаційна властивість до типу тварин

        // Навігаційна властивість для Many-to-Many зв'язку з клітками
        public ICollection<AnimalCage>? AnimalCages { get; set; }
        // Навігаційна властивість для зв'язку з волонтерами (одна тварина може бути закріплена за багатьма волонтерами)
        public ICollection<Volunteer>? Volunteers { get; set; }
    }
}
