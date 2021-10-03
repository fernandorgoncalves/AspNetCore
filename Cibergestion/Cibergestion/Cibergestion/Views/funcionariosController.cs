using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cibergestion.Controllers;
using Cibergestion.Data;

namespace Cibergestion.Views
{
    public class funcionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public funcionariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.funcionarios.ToListAsync());
        }

        // GET: funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.funcionarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,telefone,tipo")] funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarios);
        }

        // GET: funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            return View(funcionarios);
        }

        // POST: funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,telefone,tipo")] funcionarios funcionarios)
        {
            if (id != funcionarios.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!funcionariosExists(funcionarios.id))
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
            return View(funcionarios);
        }

        // GET: funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.funcionarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // POST: funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context.funcionarios.FindAsync(id);
            _context.funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool funcionariosExists(int id)
        {
            return _context.funcionarios.Any(e => e.id == id);
        }
    }
}
