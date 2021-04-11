using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class Case
    {
        public int caseId { get; set; }
        public String caseName { get; set; }
        public double casePrice { get; set; }

        public String caseColor { get; set; }
    }
}
