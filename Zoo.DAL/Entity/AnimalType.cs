using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class AnimalType
    {
        public int Id { get; set; } 
        public string AnimalTypeName { get; set; } = string.Empty;

        public ICollection<Cage>? Cages { get; set; }
      
        public ICollection<Animal>? Animals { get; set; }
    }
}
