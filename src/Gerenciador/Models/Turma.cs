using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gerenciador.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O {0} é obrigatório")]
        [Display(Name ="Nome da Disciplina")]
        [StringLength(200, ErrorMessage="O nome da disciplina deve conter ao menos {1} caracteres")]
        public string? NomeDisciplina { get; set; }

        [ForeignKey("IdProfessor")]
        public Professor? Professor {  get; set; } 
       
    }
}
