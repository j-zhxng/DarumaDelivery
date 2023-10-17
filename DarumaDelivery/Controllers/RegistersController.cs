using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarumaDelivery.Areas.Identity.Data;
using DarumaDelivery.Models;
using Microsoft.AspNetCore.Authorization;

namespace DarumaDelivery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistersController : Controller
    {
        private readonly DarumaDeliveryDB _context;

        public RegistersController(DarumaDeliveryDB context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
              return _context.Register != null ? 
                          View(await _context.Register.ToListAsync()) :
                          Problem("Entity set 'DarumaDeliveryDB.Register'  is null.");
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Register == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterID,CustomerID")] Register register)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Register == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterID,CustomerID")] Register register)
        {
            if (id != register.RegisterID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.RegisterID))
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
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Register == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Register == null)
            {
                return Problem("Entity set 'DarumaDeliveryDB.Register'  is null.");
            }
            var register = await _context.Register.FindAsync(id);
            if (register != null)
            {
                _context.Register.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return (_context.Register?.Any(e => e.RegisterID == id)).GetValueOrDefault();
        }
    }
}
