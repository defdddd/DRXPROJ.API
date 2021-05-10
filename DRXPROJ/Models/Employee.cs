using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string CostCenter { get; set; }
        public string ManagersName { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
