using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades.DataContext;
using Entidades.Dominio;

namespace BuscandoMiTrago.Controllers
{
    public class AlcoholicsController : Controller
    {
        private readonly BuscandoMiTragoDbContext _context;

        public AlcoholicsController(BuscandoMiTragoDbContext context)
        {
            _context = context;
        }

        // GET: Alcoholics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alcoholic.ToListAsync());
        }

        // GET: Alcoholics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcoholic = await _context.Alcoholic
                .FirstOrDefaultAsync(m => m.StrAlcoholic == id);
            if (alcoholic == null)
            {
                return NotFound();
            }

            return View(alcoholic);
        }

        // GET: Alcoholics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcoholics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrAlcoholic")] Alcoholic alcoholic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alcoholic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcoholic);
        }

        // GET: Alcoholics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcoholic = await _context.Alcoholic.FindAsync(id);
            if (alcoholic == null)
            {
                return NotFound();
            }
            return View(alcoholic);
        }

        // POST: Alcoholics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrAlcoholic")] Alcoholic alcoholic)
        {
            if (id != alcoholic.StrAlcoholic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcoholic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcoholicExists(alcoholic.StrAlcoholic))
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
            return View(alcoholic);
        }

        // GET: Alcoholics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcoholic = await _context.Alcoholic
                .FirstOrDefaultAsync(m => m.StrAlcoholic == id);
            if (alcoholic == null)
            {
                return NotFound();
            }

            return View(alcoholic);
        }

        // POST: Alcoholics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var alcoholic = await _context.Alcoholic.FindAsync(id);
            _context.Alcoholic.Remove(alcoholic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcoholicExists(string id)
        {
            return _context.Alcoholic.Any(e => e.StrAlcoholic == id);
        }
    }
}
