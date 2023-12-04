using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gerenciador.Models
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("TurmaId")]
        public Turma? Turma { get; set; }

        [Required]
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; }
    }
}
