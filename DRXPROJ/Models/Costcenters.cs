using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.Models
{
    public class Costcenters
    {
        public int Nr { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool DeleteFlag { get; set; } = false;
    }
}
