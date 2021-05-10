using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.Models
{
    public class AssetEmployee
    {
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int CstcNr { get; set; }
        public DateTime EndOfLife { get; set; }
    }
}
