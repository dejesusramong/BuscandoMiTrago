using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entidades.DataContext;
using Entidades.Dominio;
using BuscandoMiTrago.Models;
using Entidades.DataContext.Data;

namespace BuscandoMiTrago.Controllers
{
    public class DrinksController : Controller
    {
        private readonly BuscandoMiTragoDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public DrinksController(BuscandoMiTragoDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Drinks
        public async Task<IActionResult> Index(DrinksViewModel model)
        {
            await model.GetDrinks(_context, _serviceProvider);

            ViewData["Category"] = new SelectList(_context.Category, "StrCategory", "StrCategory", model.C);
            ViewData["Glass"] = new SelectList(_context.Glass, "StrGlass", "StrGlass", model.G);
            ViewData["Ingredient"] = new SelectList(_context.Ingredient, "StrIngredient1", "StrIngredient1", model.I);
            ViewData["Alcoholic"] = new SelectList(_context.Alcoholic, "StrAlcoholic", "StrAlcoholic", model.A);
            return View(model);
        }

        // GET: Drinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Alcoholic)
                .Include(d => d.Category)
                .Include(d => d.Glass)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.IdDrink == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // GET: Drinks/Create
        public IActionResult Create()
        {
            ViewData["StrAlcoholic"] = new SelectList(_context.Alcoholic, "StrAlcoholic", "StrAlcoholic");
            ViewData["StrCategory"] = new SelectList(_context.Category, "StrCategory", "StrCategory");
            ViewData["StrGlass"] = new SelectList(_context.Glass, "StrGlass", "StrGlass");
            ViewData["StrIngredient"] = new SelectList(_context.Ingredient, "StrIngredient1", "StrIngredient1");
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDrink,StrDrink,StrDescription,StrCategory,StrGlass,StrIngredient,StrAlcoholic")] Drink drink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StrAlcoholic"] = new SelectList(_context.Alcoholic, "StrAlcoholic", "StrAlcoholic", drink.StrAlcoholic);
            ViewData["StrCategory"] = new SelectList(_context.Category, "StrCategory", "StrCategory", drink.StrCategory);
            ViewData["StrGlass"] = new SelectList(_context.Glass, "StrGlass", "StrGlass", drink.StrGlass);
            ViewData["StrIngredient"] = new SelectList(_context.Ingredient, "StrIngredient1", "StrIngredient1", drink.StrIngredient);
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            ViewData["StrAlcoholic"] = new SelectList(_context.Alcoholic, "StrAlcoholic", "StrAlcoholic", drink.StrAlcoholic);
            ViewData["StrCategory"] = new SelectList(_context.Category, "StrCategory", "StrCategory", drink.StrCategory);
            ViewData["StrGlass"] = new SelectList(_context.Glass, "StrGlass", "StrGlass", drink.StrGlass);
            ViewData["StrIngredient"] = new SelectList(_context.Ingredient, "StrIngredient1", "StrIngredient1", drink.StrIngredient);
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDrink,StrDrink,StrDescription,StrCategory,StrGlass,StrIngredient,StrAlcoholic")] Drink drink)
        {
            if (id != drink.IdDrink)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.IdDrink))
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
            ViewData["StrAlcoholic"] = new SelectList(_context.Alcoholic, "StrAlcoholic", "StrAlcoholic", drink.StrAlcoholic);
            ViewData["StrCategory"] = new SelectList(_context.Category, "StrCategory", "StrCategory", drink.StrCategory);
            ViewData["StrGlass"] = new SelectList(_context.Glass, "StrGlass", "StrGlass", drink.StrGlass);
            ViewData["StrIngredient"] = new SelectList(_context.Ingredient, "StrIngredient1", "StrIngredient1", drink.StrIngredient);
            return View(drink);
        }

        // GET: Drinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink
                .Include(d => d.Alcoholic)
                .Include(d => d.Category)
                .Include(d => d.Glass)
                .Include(d => d.Ingredient)
                .FirstOrDefaultAsync(m => m.IdDrink == id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drink = await _context.Drink.FindAsync(id);
            _context.Drink.Remove(drink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int id)
        {
            return _context.Drink.Any(e => e.IdDrink == id);
        }
    }
}
