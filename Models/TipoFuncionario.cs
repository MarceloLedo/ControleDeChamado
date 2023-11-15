using System.ComponentModel.DataAnnotations;

namespace ControleDeChamado.Models
{
    public class TipoFuncionario
    {
        [Key]
        public int IdTipo { get; set; }
        [Required]
        public string NomeTipo { get; set; }
    }
}
