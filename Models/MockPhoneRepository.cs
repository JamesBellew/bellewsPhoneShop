using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bellewsPhoneShop.Data;
using bellewsPhoneShop.Models;

namespace bellewsPhoneShop.Models
{
    public class MockPhoneRepository : IPhoneRepository
    {
        private readonly AuthDbContext _context;

        public MockPhoneRepository(AuthDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Phone> List()
        {
            List<Phone> myPhones = _context.Phones.ToList();
            return myPhones;
        }

        public Phone getPhoneById(int Id)
        {
            Phone myPhone = _context.Phones.FirstOrDefault(b => b.id == Id);
            return myPhone;
        }


    }
}
