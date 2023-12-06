using Microsoft.EntityFrameworkCore;
using Gerenciador.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Gerenciador.Data

{
    public class AppDbContext : IdentityDbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }
    }
}
