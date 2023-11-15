namespace ControleDeChamado.Models
{
    public class ChamadoEditar
    {
        /*public int IdChamado { get; set; }*/
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public int ClassificacaoId { get; set; }

        public int SolicitanteId { get; set; }
       /* public Funcionario Solicitante { get; set; }*/
        public int ExecutanteId { get; set; }
        /*public Funcionario Executante { get; set; }*/

    }
}
