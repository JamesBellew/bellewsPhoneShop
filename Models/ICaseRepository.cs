using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
   public interface ICaseRepository
    {
        IEnumerable<Case> List();
        Case getCaseById(int caseId);
    }
}
