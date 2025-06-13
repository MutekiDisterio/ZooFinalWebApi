using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class Owner
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; 
        public string? Address { get; set; } 
        public ICollection<Animal>? Animals { get; set; }
    }
}
