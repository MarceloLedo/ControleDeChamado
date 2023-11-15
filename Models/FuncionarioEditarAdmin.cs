namespace ControleDeChamado.Models
{
    public class FuncionarioEditarAdmin
    {
        public string NomeFuncionario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; } 
        public int TipoFuncionarioId { get; set; }
        public int SetorId { get; set; }
    }
}
