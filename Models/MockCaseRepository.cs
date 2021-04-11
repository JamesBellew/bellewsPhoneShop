using bellewsPhoneShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class MockCaseRepository : ICaseRepository
    {

        private readonly AuthDbContext _context;

        public MockCaseRepository(AuthDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Case> List()
        {
            List<Case> allCases = _context.Cases.ToList();
            return allCases;
        }
        public Case getCaseById(int caseId)
        {
            Case myCase = _context.Cases.FirstOrDefault(b => b.caseId == caseId);
            return myCase;
        }

      
    }
}
