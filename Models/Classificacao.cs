using System.ComponentModel.DataAnnotations;

namespace ControleDeChamado.Models
{
    public class Classificacao
    {

        [Key]
        public int IdClassificacao { get; set; }
        [Required]
        public string NomeClassificacao { get; set; }
        public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();   
    }
}
