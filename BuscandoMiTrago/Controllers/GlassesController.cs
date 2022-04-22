﻿using System;
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
    public class GlassesController : Controller
    {
        private readonly BuscandoMiTragoDbContext _context;

        public GlassesController(BuscandoMiTragoDbContext context)
        {
            _context = context;
        }

        // GET: Glasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Glass.ToListAsync());
        }

        // GET: Glasses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glass
                .FirstOrDefaultAsync(m => m.StrGlass == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // GET: Glasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Glasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrGlass")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(glass);
        }

        // GET: Glasses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glass.FindAsync(id);
            if (glass == null)
            {
                return NotFound();
            }
            return View(glass);
        }

        // POST: Glasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrGlass")] Glass glass)
        {
            if (id != glass.StrGlass)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassExists(glass.StrGlass))
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
            return View(glass);
        }

        // GET: Glasses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glass = await _context.Glass
                .FirstOrDefaultAsync(m => m.StrGlass == id);
            if (glass == null)
            {
                return NotFound();
            }

            return View(glass);
        }

        // POST: Glasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var glass = await _context.Glass.FindAsync(id);
            _context.Glass.Remove(glass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassExists(string id)
        {
            return _context.Glass.Any(e => e.StrGlass == id);
        }
    }
}
