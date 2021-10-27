using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estoque.MVC.Data;
using Estoque.MVC.Models;

namespace Estoque.MVC.Controllers
{
    public class RetiradasController : Controller
    {
        private readonly EstoqueMVCContext _context;

        public RetiradasController(EstoqueMVCContext context)
        {
            _context = context;
        }

        // GET: Retiradas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retirada.ToListAsync());
        }

        // GET: Retiradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirada = await _context.Retirada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retirada == null)
            {
                return NotFound();
            }

            return View(retirada);
        }

        // GET: Retiradas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retiradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEpi,IdFuncionario,DataRetirada,Validade")] Retirada retirada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retirada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retirada);
        }

        // GET: Retiradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirada = await _context.Retirada.FindAsync(id);
            if (retirada == null)
            {
                return NotFound();
            }
            return View(retirada);
        }

        // POST: Retiradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEpi,IdFuncionario,DataRetirada,Validade")] Retirada retirada)
        {
            if (id != retirada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retirada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetiradaExists(retirada.Id))
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
            return View(retirada);
        }

        // GET: Retiradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retirada = await _context.Retirada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retirada == null)
            {
                return NotFound();
            }

            return View(retirada);
        }

        // POST: Retiradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retirada = await _context.Retirada.FindAsync(id);
            _context.Retirada.Remove(retirada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetiradaExists(int id)
        {
            return _context.Retirada.Any(e => e.Id == id);
        }
    }
}
