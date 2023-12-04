using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Gerenciador.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage ="O campo {0} precisa ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage ="O campo {0} está em um formato inválido")]
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento {  get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage ="O campo {0} precisa ter no máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "O campo {0} se encontra em um formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Compare("Email", ErrorMessage = "Os emails não são iguais")]
        [NotMapped]
        [Display(Name = "Confirme o Email")]
        public string EmailConfirmacao { get; set; }
    }
}
