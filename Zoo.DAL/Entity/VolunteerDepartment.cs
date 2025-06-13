using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class VolunteerDepartment
    {
        public int Id { get; set; } 
        public string DepartmentName { get; set; } = string.Empty; 

       
        public ICollection<Volunteer>? Volunteers { get; set; }
    }
}
