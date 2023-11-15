namespace ControleDeChamado.Models
{
    public class FuncionarioResumo
    {
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public string Usuario { get; set; }
        public int TipoFuncionarioId { get; set; }
        public bool Status { get; set; } 
        public int SetorId { get; set; }
        public string SetorNome { get; set; }
    }
}
