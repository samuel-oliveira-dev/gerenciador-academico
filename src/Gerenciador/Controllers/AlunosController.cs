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

        public async Task<IActionResult> Edit(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Nome,Email,Id,EmailConfirmacao,DataNascimento")]Aluno aluno)
        {

           
            
            if(ModelState.IsValid)
            {
                ModelState.Remove("EmailConfirmacao");
                _context.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            } else 
            { 
                return View(aluno); 
            }
        }

        [HttpPost("excluir/{Id}"), ActionName("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            if(aluno != null)
            {
                _context.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
