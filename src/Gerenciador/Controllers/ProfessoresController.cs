using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Gerenciador.Data;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Controllers
{
    public class ProfessoresController : Controller
    {

        readonly AppDbContext _context;

        public ProfessoresController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            if(await _context.Professores.ToListAsync() is null)
            {
                return RedirectToAction("Create");
            } else
            {
                return View(await _context.Professores.ToListAsync());
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,EmailConfirmacao,DataNascimento")] Professor professor)
        {

            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
            }
            else
            {
                return View(professor);
            }
            //lógica para responder POST


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }
    }
}
