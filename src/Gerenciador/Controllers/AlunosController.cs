using Gerenciador.Models;
using Microsoft.AspNetCore.Mvc;
using Gerenciador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Gerenciador.Controllers
{
    public class AlunosController(AppDbContext context) : Controller
    {

        readonly AppDbContext _context = context;

        //[Authorize]
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
        public async Task<IActionResult> Create([Bind("Nome,Email,EmailConfirmacao,DataNascimento,ImagemUpload")]Aluno aluno)
        {
            
            if(ModelState.IsValid)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if(!await UploadArquivo(aluno.ImagemUpload, imgPrefixo))
                {
                    return View(aluno);
                }

                aluno.ImagemNome = imgPrefixo + aluno.ImagemUpload.FileName;
                _context.Add(aluno);
                await _context.SaveChangesAsync();
            } else
            {
                return View(aluno);
            }


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

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if(arquivo.Length <= 0)
            {
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);
            if(System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
