using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class AnimalType
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public string AnimalTypeName { get; set; } = string.Empty; // AnimalType VARCHAR(30) NOT NULL (змінено назву для уникнення конфлікту)

        // Навігаційна властивість для зв'язку з клітками (один тип тварин може бути пов'язаний з багатьма клітками)
        public ICollection<Cage>? Cages { get; set; }
        // Навігаційна властивість для зв'язку з тваринами (один тип тварин може мати багато тварин)
        public ICollection<Animal>? Animals { get; set; }
    }
}
