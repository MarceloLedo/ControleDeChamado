using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleDeChamado.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        [Required]
        public string NomeFuncionario { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public bool Status { get; set; } = true;
        public int TipoFuncionarioId { get; set; }
        
        [JsonIgnore]
        public TipoFuncionario FuncionarioTipo { get; set; } = null!;
        public int SetorId { get; set; }    
        
        [JsonIgnore]
        public Setor Setor { get; set; } = null!;
    }
}
