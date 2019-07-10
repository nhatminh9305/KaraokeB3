using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using B3.Models;

namespace Karaoke.Controllers
{
    public class NewModelsController : Controller
    {
        private readonly DatabaseContext _context;

        public NewModelsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: NewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: NewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newModel = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newModel == null)
            {
                return NotFound();
            }

            return View(newModel);
        }

        // GET: NewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image,Type,Status,CreatedBy,EditedBy,PublishDate,CreatedTime,UpdatedTime")] NewModel newModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newModel);
        }

        // GET: NewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newModel = await _context.News.FindAsync(id);
            if (newModel == null)
            {
                return NotFound();
            }
            return View(newModel);
        }

        // POST: NewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Image,Type,Status,CreatedBy,EditedBy,PublishDate,CreatedTime,UpdatedTime")] NewModel newModel)
        {
            if (id != newModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewModelExists(newModel.Id))
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
            return View(newModel);
        }

        // GET: NewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newModel = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newModel == null)
            {
                return NotFound();
            }

            return View(newModel);
        }

        // POST: NewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newModel = await _context.News.FindAsync(id);
            _context.News.Remove(newModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewModelExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
