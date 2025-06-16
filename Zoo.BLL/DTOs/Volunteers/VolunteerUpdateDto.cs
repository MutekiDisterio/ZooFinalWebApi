using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BLL.DTOs.Volunteers
{
    public class VolunteerUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? AnimalId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
