using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BLL.DTOs.Animals
{
    public class AnimalUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? OwnerId { get; set; }
        public int? AnimalTypeId { get; set; }
    }
}
