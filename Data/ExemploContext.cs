using ControleDeChamado.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeChamado.Data
{
    public class ExemploContext : DbContext
    {

        public ExemploContext(
            DbContextOptions<ExemploContext> options) : base(options) { }

        public DbSet<Chamado> Chamados { get; set; }
        /*public DbSet<ChamadoCreate> ChamadoCreate{ get; set; }*/
        public DbSet<Classificacao> Classificacao { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<TipoFuncionario> TipoFuncionarios { get; set; }      
    }
}
