using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.DAL.Entity.HelpModels
{
    public class AnimalQueryParameters : QueryParameters
    {
        public string? Name { get; set; }
        public int? AnimalTypeId { get; set; }
    }
}
