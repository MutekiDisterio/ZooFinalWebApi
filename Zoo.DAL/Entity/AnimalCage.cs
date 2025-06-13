using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    // Це сутність для з'єднувальної таблиці Many-to-Many
    public class AnimalCage
    {
        public int CageId { get; set; } // Primary Key частина
        public int AnimalId { get; set; } // Primary Key частина

        // Навігаційні властивості
        public Cage Cage { get; set; } = null!;
        public Animal Animal { get; set; } = null!;
    }
}
