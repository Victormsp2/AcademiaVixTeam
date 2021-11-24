using AcademiaVixTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcademiaVixTeam.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Codigo,Nome,NomeFantasia,Cnpj")] EmpresaModel empresaModel)
        {
            return View("Index");
        }


    }

}
