using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BLL.DTOs.Cages
{
    public class CageReadDto
    {
        public int Id { get; set; }
        public int AnimalTypeId { get; set; }
        public string AnimalTypeName { get; set; } = "";
    }
}
