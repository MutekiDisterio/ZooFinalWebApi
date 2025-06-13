using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Cage
    {
        public int Id { get; set; } 
        public int AnimalTypeId { get; set; } 

        public AnimalType AnimalType { get; set; } = null!; 

        public ICollection<AnimalCage>? AnimalCages { get; set; }
    }
}
