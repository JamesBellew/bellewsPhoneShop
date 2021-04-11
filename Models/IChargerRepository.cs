using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public interface IChargerRepository
    {
        IEnumerable<Charger> List();
        Charger getChargerById(int chargerId);
    }
}
