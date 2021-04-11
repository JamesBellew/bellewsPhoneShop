using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bellewsPhoneShop.Data;
using bellewsPhoneShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bellewsPhoneShop.Controllers
{
    public class PhoneController : Controller
    {

        private readonly IPhoneRepository _phoneRepository;
        private readonly AuthDbContext _context;

        public PhoneController(IPhoneRepository phoneRepository, AuthDbContext context)
        {
            _context = context;
            _phoneRepository = phoneRepository;

        }

      
        public IActionResult List()
        {
            PhoneListViewModel phonesListViewModel = new PhoneListViewModel();
            phonesListViewModel.Phones = _phoneRepository.List();
            return View(phonesListViewModel);

        }

        public IActionResult Index()
        {
            PhoneListViewModel phonesListViewModel = new PhoneListViewModel();
            phonesListViewModel.Phones = _phoneRepository.List();
            return View(phonesListViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,make,year,price,os")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
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

            var phone = await _context.Phones

                .FirstOrDefaultAsync(m => m.id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }
        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


       



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }









        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,make,year,price,os")] Phone phone)
        {
            if (id != phone.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.id))
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
            return View(phone);
        }


        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.id == id);
        }
    }
}
