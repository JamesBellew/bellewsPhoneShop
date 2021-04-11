using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bellewsPhoneShop.Data;
using bellewsPhoneShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bellewsPhoneShop.Controllers
{
    public class CaseController : Controller
    {

        private readonly ICaseRepository _caseRepository;
        private readonly AuthDbContext _context;

        public CaseController(ICaseRepository caseRepository, AuthDbContext context)
        {
            _context = context;
            _caseRepository = caseRepository;

        }

 

        public IActionResult List()
        {
            CaseListViewModel casesListViewModel = new CaseListViewModel();
            casesListViewModel.Cases = _caseRepository.List();
            return View(casesListViewModel);

        }
        public IActionResult Index()
        {
            var applicationDbContext = _caseRepository.List();
            return View(applicationDbContext.ToList());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases.FindAsync(id);
            if (cases == null)
            {
                return NotFound();
            }
            return View(cases);
        }









        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("caseId,caseName,casePrice,caseColor")] Case cases)
        {
            if (id != cases.caseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(cases.caseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            CaseListViewModel casesListViewModel = new CaseListViewModel();
            casesListViewModel.Cases = _caseRepository.List();
            return View(casesListViewModel);
            
        }


        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("caseName,casePrice,caseColor")] Case cases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cases);
                await _context.SaveChangesAsync();
                return View();
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases

                .FirstOrDefaultAsync(m => m.caseId == id);
            if (cases == null)
            {
                return NotFound();
            }

            return View(cases);
        }
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cases = await _context.Cases.FindAsync(id);
            _context.Cases.Remove(cases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.caseId == id);
        }

    }
    }

