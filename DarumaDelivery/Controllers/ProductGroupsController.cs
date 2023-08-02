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
    [Authorize(Roles = "Admin, Manager")]
    public class ProductGroupsController : Controller
    {
        private readonly DarumaDeliveryDB _context;

        public ProductGroupsController(DarumaDeliveryDB context)
        {
            _context = context;
        }

        // GET: ProductGroups
        public async Task<IActionResult> Index()
        {
              return _context.ProductGroup != null ? 
                          View(await _context.ProductGroup.ToListAsync()) :
                          Problem("Entity set 'DarumaDeliveryDB.ProductGroup'  is null.");
        }

        // GET: ProductGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductGroup == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup
                .FirstOrDefaultAsync(m => m.ProductGroupID == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: ProductGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductGroupID,ProductID,ProductGroupTitle,ProductGroupDescription")] ProductGroup productGroup)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(productGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productGroup);
        }

        // GET: ProductGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductGroup == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }
            return View(productGroup);
        }

        // POST: ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductGroupID,ProductID,ProductGroupTitle,ProductGroupDescription")] ProductGroup productGroup)
        {
            if (id != productGroup.ProductGroupID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(productGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductGroupExists(productGroup.ProductGroupID))
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
            return View(productGroup);
        }

        // GET: ProductGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductGroup == null)
            {
                return NotFound();
            }

            var productGroup = await _context.ProductGroup
                .FirstOrDefaultAsync(m => m.ProductGroupID == id);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductGroup == null)
            {
                return Problem("Entity set 'DarumaDeliveryDB.ProductGroup'  is null.");
            }
            var productGroup = await _context.ProductGroup.FindAsync(id);
            if (productGroup != null)
            {
                _context.ProductGroup.Remove(productGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductGroupExists(int id)
        {
          return (_context.ProductGroup?.Any(e => e.ProductGroupID == id)).GetValueOrDefault();
        }
    }
}
