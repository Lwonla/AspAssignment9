using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class UnitEntitiesController : Controller
    {
        private readonly DataContext _context;

        public UnitEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: UnitEntities/Search
        public async Task<IActionResult> Index(string unitCategory, string searchString)
        {
            if (_context.UnitEntity == null)
            {
                return Problem("Entity set 'DataContext.UnitEntity'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.UnitEntity
                                            orderby m.Category
                                            select m.Category;
            var unites = from m in _context.UnitEntity
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                unites = unites.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(unitCategory))
            {
                unites = unites.Where(x => x.Category == unitCategory);
            }

            var unitCategoryVM = new UnitCategoryViewModel
            {
                Categories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Units = await unites.ToListAsync()
            };

            return View(unitCategoryVM);
        }



        // GET: UnitEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnitEntity == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.UnitEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitEntity == null)
            {
                return NotFound();
            }

            return View(unitEntity);
        }

        // GET: UnitEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Ingress,ImageUrl,Price,Category")] UnitEntity unitEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitEntity);
        }

        // GET: UnitEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnitEntity == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.UnitEntity.FindAsync(id);
            if (unitEntity == null)
            {
                return NotFound();
            }
            return View(unitEntity);
        }

        // POST: UnitEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Ingress,ImageUrl,Price,Category")] UnitEntity unitEntity)
        {
            if (id != unitEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitEntityExists(unitEntity.Id))
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
            return View(unitEntity);
        }

        // GET: UnitEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnitEntity == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.UnitEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitEntity == null)
            {
                return NotFound();
            }

            return View(unitEntity);
        }

        // POST: UnitEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnitEntity == null)
            {
                return Problem("Entity set 'DataContext.UnitEntity'  is null.");
            }
            var unitEntity = await _context.UnitEntity.FindAsync(id);
            if (unitEntity != null)
            {
                _context.UnitEntity.Remove(unitEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitEntityExists(int id)
        {
          return (_context.UnitEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
