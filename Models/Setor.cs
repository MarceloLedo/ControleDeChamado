using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace ControleDeChamado.Models
{
    public class Setor
    {
        [Key]
        public int IdSetor { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Funcao { get; set; }
        public string Ramal { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<Funcionario> Funcionarios { get; } = new List<Funcionario>(); 


    }
}
