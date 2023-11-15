﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;


namespace ControleDeChamado.Models
{
    public class Chamado
    {
        [Key]
        public int IdChamado { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; } = new DateTime();
        public DateTime? DataFinal { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public int ClassificacaoId { get; set; }
        public Classificacao Classificacao { get; set; } = null!;
        public int SolicitanteId { get; set; }
        
        public Funcionario Solicitante { get; set; } = null!;
        [AllowNull]
        public int? ExecutanteId { get; set; }
        [AllowNull]
        public Funcionario? Executante { get; set; }


    }
}
