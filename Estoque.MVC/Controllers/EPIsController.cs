using Estoque.MVC.Data;
using Estoque.MVC.Models;
using Estoque.MVC.Models.InputModels;
using Estoque.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Controllers
{
    public class EPIsController : Controller
    {
        private readonly EPIService _epiService;
        public readonly EstoqueMVCContext _context;

        public EPIsController(EPIService epiService, EstoqueMVCContext context)
        {
            _epiService = epiService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _epiService.BuscarTodosAsync();
            return View(list);
        }


        public async Task<IActionResult> Details(int id)
        {
            var ePI = await _epiService.BuscarPorIdAsync(id);

            if (ePI == null)
            {
                return NotFound();
            }

            return View(ePI);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EPIInputModel model)
        {
            if (ModelState.IsValid)
            {
                var epi = await _epiService.BuscarPorNomeAsync(model.Nome);

                if (epi == null)
                {
                    await _epiService.CriarAsync(new EPI() {Nome = model.Nome, CA = model.CA, Quantidade = 0, Validade = model.Validade, Valor = model.Valor });
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Já existe um cadastro com esse nome!");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ePI = await _epiService.BuscarPorIdAsync(id);

            if (ePI == null)
            {
                return NotFound();
            }

            return View(ePI);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EPIInputModel model)
        {
            if (ModelState.IsValid)
            {
                var epiValidador = await _epiService.BuscarPorNomeAsync(model.Nome);
                var epi = await _epiService.BuscarPorIdAsync(id);

                if (epiValidador == null || epi.Nome == model.Nome)
                {
                    epi.Nome = model.Nome;
                    epi.CA = model.CA;
                    epi.Validade = model.Validade;
                    epi.Valor = model.Valor;
                    await _epiService.AtualizarAsync(epi);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Já existe um epi com esse nome");
            }
            return View(await _epiService.BuscarPorIdAsync(id));
        }

        public async Task<IActionResult> Add(int id)
        {
            EPI epi = await _epiService.BuscarPorIdAsync(id);

            return View(epi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, EPIInputModel model)
        {
            if (ModelState.IsValid)
            {
                var epi = await _epiService.BuscarPorIdAsync(id);
                epi.Valor = model.Valor;
                epi.Quantidade += model.Quantidade;
                await _epiService.AtualizarAsync(epi);
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Não é possível subtrair quantidade");
            return View(await _epiService.BuscarPorIdAsync(id));
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
