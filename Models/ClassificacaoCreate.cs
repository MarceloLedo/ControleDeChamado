using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ControleDeChamado.Models
{
    public class ClassificacaoCreate
    {
        public int IdClassificacao { get; set; }
        public string NomeClassificacao { get; set; }
        
    }
}
