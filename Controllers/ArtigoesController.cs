using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artigo_Application.Data;
using Artigo_Application.Models;

namespace Artigo_Application.Controllers
{
    public class ArtigoesController : Controller
    {
        private readonly Artigo_ApplicationContext _context;

        public ArtigoesController(Artigo_ApplicationContext context)
        {
            _context = context;
        }

        // GET: Artigoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artigo.ToListAsync());
        }

        // GET: Artigoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .FirstOrDefaultAsync(m => m.id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // GET: Artigoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artigoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Título,Autor,Editora,Conteúdo")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artigo);
        }

        // GET: Artigoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }
            return View(artigo);
        }

        // POST: Artigoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Título,Autor,Editora,Conteúdo")] Artigo artigo)
        {
            if (id != artigo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtigoExists(artigo.id))
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
            return View(artigo);
        }

        // GET: Artigoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artigo = await _context.Artigo
                .FirstOrDefaultAsync(m => m.id == id);
            if (artigo == null)
            {
                return NotFound();
            }

            return View(artigo);
        }

        // POST: Artigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artigo = await _context.Artigo.FindAsync(id);
            _context.Artigo.Remove(artigo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtigoExists(int id)
        {
            return _context.Artigo.Any(e => e.id == id);
        }
    }
}
