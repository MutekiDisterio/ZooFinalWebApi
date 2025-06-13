using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity
{
    public class VolunteerDepartment
    {
        public int Id { get; set; } // SERIAL PRIMARY KEY
        public string DepartmentName { get; set; } = string.Empty; // VARCHAR(30) NOT NULL

        // Навігаційна властивість для зв'язку з волонтерами
        public ICollection<Volunteer>? Volunteers { get; set; }
    }
}
