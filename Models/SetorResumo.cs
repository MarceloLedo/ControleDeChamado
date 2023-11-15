using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace ControleDeChamado.Models
{
    public class SetorResumo
    {
        public int IdSetor { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Ramal { get; set; }
        public bool Status { get; set; }

    }
}
