using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BLL.DTOs.Volunteers
{
    public class VolunteerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public int? AnimalId { get; set; }
        public int DepartmentId { get; set; }


        public string? AnimalName { get; set; }            
        public string DepartmentName { get; set; } = "";
    }
}
