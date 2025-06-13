using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class AnimalCage
    {
        public int CageId { get; set; } 
        public int AnimalId { get; set; }
        public Cage Cage { get; set; } = null!;
        public Animal Animal { get; set; } = null!;
    }
}
