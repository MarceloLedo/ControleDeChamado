using System.Diagnostics.CodeAnalysis;

namespace ControleDeChamado.Models
{
    public class ChamadoResumo
    {
        public int IdChamado { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; } = new DateTime();
        public DateTime? DataFinal { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public string ClassificacaoNome { get; set; }
        
        public string SolicitanteNome { get; set; }
        /* public Funcionario Solicitante { get; set; }*/
        
        public string? ExecutanteNome { get; set; }
        /*public Funcionario Executante { get; set; }*/

    }
}
