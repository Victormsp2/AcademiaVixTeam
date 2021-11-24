using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademiaVixTeam.Data;
using AcademiaVixTeam.Models;

namespace AcademiaVixTeam.Controllers
{
    public class PessoalModelsController : Controller
    {
        private readonly AcademiaVixTeamContext _context;

        public PessoalModelsController(AcademiaVixTeamContext context)
        {
            _context = context;
        }

        // GET: PessoalModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PessoalModel.ToListAsync());
        }

        // GET: PessoalModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoalModel = await _context.PessoalModel
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (pessoalModel == null)
            {
                return NotFound();
            }

            return View(pessoalModel);
        }

        // GET: PessoalModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoalModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,NomeCompleto,Email,DataNascimento,QuantidadeFilhos,Salario")] PessoalModel pessoalModel)
        {
                pessoalModel.Situacao = "Ativo";
                _context.Add(pessoalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: PessoalModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoalModel = await _context.PessoalModel.FindAsync(id);
            if (pessoalModel == null)
            {
                return NotFound();
            }
            return View(pessoalModel);
        }

        // POST: PessoalModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,NomeCompleto,Email,DataNascimento,QuantidadeFilhos,Salario")] PessoalModel pessoalModel)
        {
            if (id != pessoalModel.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoalModelExists(pessoalModel.Codigo))
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
            return View(pessoalModel);
        }

        // GET: PessoalModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoalModel = await _context.PessoalModel
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (pessoalModel == null)
            {
                return NotFound();
            }

            return View(pessoalModel);
        }

        // POST: PessoalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoalModel = await _context.PessoalModel.FindAsync(id);
            _context.PessoalModel.Remove(pessoalModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoalModelExists(int id)
        {
            return _context.PessoalModel.Any(e => e.Codigo == id);
        }
    }
}
