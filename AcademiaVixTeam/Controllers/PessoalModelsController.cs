using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademiaVixTeam.Data;
using AcademiaVixTeam.Business;
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

            if (ModelState.IsValid)
            {
                if (PessoalBusiness.ValidaQuantidadeFilhos(pessoalModel.QuantidadeFilhos))
                {
                    ModelState.AddModelError("Regra de Negócio", " O Numero de filhos deve ser maoir do que zero");
                    return View(pessoalModel);
                }
                if (PessoalBusiness.ValidaDataNascimento(pessoalModel.DataNascimento))
                {
                    ModelState.AddModelError("Regra de Negócio", " O ano de nascimento deve ser a partir de 1990");
                    return View(pessoalModel);
                }
                if (PessoalBusiness.ValidaSalario(pessoalModel.Salario))
                {
                    ModelState.AddModelError("Regra de Negócio", " O salario deve ser maior que R$1300,00 e menor que R$ 12000,00");
                    return View(pessoalModel);
                }

                var pessoalEmail = _context.PessoalModel.Where(x => x.Email.Equals(pessoalModel.Email) && x.Codigo != pessoalModel.Codigo);
                if (pessoalEmail.Count() > 0)
                {
                    ModelState.AddModelError("Regra de Negócio", " E-mail já cadastrado");
                    return View(pessoalModel);
                }
                _context.AddAsync(pessoalModel);
                _context.SaveChangesAsync();
                return View(pessoalModel);
            }
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
            else
            {
                var regrasEdicaoNaoAtendidas = true;
                var mensagemRegras = string.Empty;
                if (PessoalBusiness.ValidaEditarPessoalInativa(pessoalModel.Situacao))
                {

                    ModelState.AddModelError("Regra de Negócio", "Não é permitido editar usuario Inativo");
                    return View(pessoalModel);

                }
                else
                {
                    return View(pessoalModel);
                }
            }
            return View(pessoalModel);
        }

        // POST: PessoalModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,NomeCompleto,Email,DataNascimento,QuantidadeFilhos,Salario,Situacao")] PessoalModel pessoalModel)
        {
            if (id != pessoalModel.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (PessoalBusiness.ValidaEditarPessoalInativa(pessoalModel.Situacao))
                {
                    ModelState.AddModelError("Regra de Negócio", "Não é permitido editar usuario Inativo");
                    return View(pessoalModel);
                }
                if (PessoalBusiness.ValidaQuantidadeFilhos(pessoalModel.QuantidadeFilhos))
                {
                    ModelState.AddModelError("Regra de Negócio", " O Numero de filhos deve ser maoir do que zero");
                    return View(pessoalModel);
                }
                if (PessoalBusiness.ValidaDataNascimento(pessoalModel.DataNascimento))
                {
                    ModelState.AddModelError("Regra de Negócio", " O ano de nascimento deve ser a partir de 1990");
                    return View(pessoalModel);
                }
                if (PessoalBusiness.ValidaSalario(pessoalModel.Salario))
                {
                    ModelState.AddModelError("Regra de Negócio", " O salario deve ser maior que R$1300,00 e menor que R$ 7000,00");
                    return View(pessoalModel);
                }

                var pessoalEmail = _context.PessoalModel.Where(x => x.Email.Equals(pessoalModel.Email) && x.Codigo != pessoalModel.Codigo);
                if (pessoalEmail.Count() > 0)
                {
                    ModelState.AddModelError("Regra de Negócio", " E-mail já cadastrado");
                    return View(pessoalModel);
                }

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
            else
            {
                if (ModelState.IsValid)
                {
                    if (PessoalBusiness.ValidaExclusaoPessoalAtiva(pessoalModel.Situacao))
                    {
                        ModelState.AddModelError("Regra de Negócio", " Não é permitido excluir usuario Ativo");
                        return View(pessoalModel);
                    }
                }
            }
            return View(pessoalModel);
        }

        // POST: PessoalModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var pessoalModel = await _context.PessoalModel.FindAsync(id);
            if (ModelState.IsValid)
            {
                if (PessoalBusiness.ValidaExclusaoPessoalAtiva(pessoalModel.Situacao))
                {
                    ModelState.AddModelError("Regra de Negócio", " Não é permitido excluir usuario Ativo");
                    return View(pessoalModel);
                }
            }
            _context.PessoalModel.Remove(pessoalModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoalModelExists(int id)
        {
            return _context.PessoalModel.Any(e => e.Codigo == id);
        }

        // GET: PessoalModels/AlterarStatus

        [HttpGet]
        public async Task<IActionResult> AlterarStatus(int id)
        {
            var pessoalModel = await _context.PessoalModel.FindAsync(id);
            if (pessoalModel.Situacao == "Ativo")
            {
                pessoalModel.Situacao = "Inativo";
            }
            else
            {
                pessoalModel.Situacao = "Ativo";
            }
            _context.Update(pessoalModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

