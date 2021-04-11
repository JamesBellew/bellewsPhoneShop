using bellewsPhoneShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class MockChargerRepository : IChargerRepository
    {

        private readonly AuthDbContext _context;

        public MockChargerRepository(AuthDbContext context)
        {
            _context = context;
        }
        public Charger getChargerById(int chargerId)
        {
            Charger myCharger = _context.Chargers.FirstOrDefault(b => b.chargerId == chargerId);
            return myCharger;
        }

        public IEnumerable<Charger> List()
        {
            List<Charger> mychargers = _context.Chargers.ToList();
            return mychargers;
        }
    }
}
