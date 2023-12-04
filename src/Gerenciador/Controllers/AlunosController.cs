using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Gerenciador.Data;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Controllers
{
    public class AlunosController(AppDbContext context) : Controller
    {

        readonly AppDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Alunos.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,EmailConfirmacao,DataNascimento")]Aluno aluno)
        {
            
            if(ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
            } else
            {
                return View(aluno);
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
