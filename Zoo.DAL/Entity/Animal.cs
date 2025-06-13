using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Animal
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public DateTime BirthDate { get; set; } 
        public int? OwnerId { get; set; } 
        public int AnimalTypeId { get; set; } 

        public Owner? Owner { get; set; } 
        public AnimalType AnimalType { get; set; } = null!; 

        public ICollection<AnimalCage>? AnimalCages { get; set; }
        public ICollection<Volunteer>? Volunteers { get; set; }
    }
}
