using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bellewsPhoneShop.Data;
using bellewsPhoneShop.Models;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace bellewsPhoneShop.Controllers
{
    public class ChargersController : Controller
    {
       
        private readonly IChargerRepository _chargerRepository;
        private readonly AuthDbContext _context;


        public ChargersController(IChargerRepository chargerRepository,AuthDbContext context)
        {
            _context = context;
            _chargerRepository = chargerRepository;
        }

        // GET: Chargers
        public async Task<IActionResult> Index()
        {
            ChargerListViewModel chargersListViewModel = new ChargerListViewModel();
            chargersListViewModel.Chargers = _chargerRepository.List();
            return View(chargersListViewModel);
        }

        // GET: Chargers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Chargers
                .FirstOrDefaultAsync(m => m.chargerId == id);
            if (charger == null)
            {
                return NotFound();
            }

            return View(charger);
        }


        public IActionResult List()
        {
            ChargerListViewModel chargersListViewModel = new ChargerListViewModel();
            chargersListViewModel.Chargers = _chargerRepository.List();
            return View(chargersListViewModel);

        }


        [Authorize]
        // GET: Chargers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chargers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("chargerId,chargerName,chargerPort,chargerPrice")] Charger charger)
        {
            if (ModelState.IsValid)
               
            {
                if (validateLength(charger.chargerPort) == true)
                {
                    _context.Add(charger);
                    await _context.SaveChangesAsync();
                    return View(charger);
                }
                else
                {
                    return View(charger);
                }
                  
            }
            return View(charger);
        }

        [Authorize]
        // GET: Chargers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Chargers.FindAsync(id);
            if (charger == null)
            {
                return NotFound();
            }
            return View(charger);
        }

        // POST: Chargers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("chargerId,chargerName,chargerPort,chargerPrice")] Charger charger)
        {
            if (id != charger.chargerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargerExists(charger.chargerId))
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
            return View(charger);
        }

        [Authorize]
        // GET: Chargers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charger = await _context.Chargers
                .FirstOrDefaultAsync(m => m.chargerId == id);
            if (charger == null)
            {
                return NotFound();
            }

            return View(charger);
        }

        // POST: Chargers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charger = await _context.Chargers.FindAsync(id);
            _context.Chargers.Remove(charger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool validateLength(string name)
        {
            Boolean flag = true;
            if (name.Length < 3)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }

            return flag;
        }
      
        private bool ChargerExists(int id)
        {
            return _context.Chargers.Any(e => e.chargerId == id);
        }
    }
}
