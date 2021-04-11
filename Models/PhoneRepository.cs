using bellewsPhoneShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly AuthDbContext _appDbContext;

        public Phone getPhoneById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phone> List()
        {

            List<Phone> myPhones = _appDbContext.Phones.ToList();
            return myPhones;

        }
    }
}
