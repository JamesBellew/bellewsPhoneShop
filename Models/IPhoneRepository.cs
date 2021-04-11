using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
   public interface IPhoneRepository
    {
        IEnumerable<Phone> List();
        Phone getPhoneById(int Id);
    }
}
