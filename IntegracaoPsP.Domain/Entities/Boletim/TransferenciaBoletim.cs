using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class TransferenciaBoletim
    {
        [Required]
        [StringLength(3)]
        public string Identificador { get; set; }
        [Required]
        [StringLength(8)]
        public string CNPJBase { get; set; }
        [Required]
        [StringLength(4)]
        public string CNPJFilial { get; set; }
        [Required]
        [StringLength(2)]
        public string CNPJControle { get; set; }
        
        [Required]
        [StringLength(10)]
        public string NumeroViagem { get; set; }
        [Required]
        [StringLength(5)]
        public string NumeroBoletim { get; set; }

        [Required]
        [StringLength(5)]
        public string LocalOperacao { get; set; }
        [Required]
        [StringLength(1)]
        public string AoLargo { get; set; }
        [Required]
        [StringLength(15)]
        public string TipoNavegacao { get; set; }
        [Required]
        [StringLength(8)]
        public string DataInicial { get; set; }
        [Required]
        [StringLength(8)]
        public string DataFinal { get; set; }
        [Required]
        [StringLength(2)]
        public string PeriodoTrabalho { get; set; }
        [Required]
        [StringLength(2)]
        public string Terno { get; set; }

        [StringLength(10)]
        public string Porao { get; set; }
        [Required]
        [StringLength(6)]
        public string PrimeiraLingada { get; set; }

        [Required]
        [StringLength(6)]
        public string UltimaLingada { get; set; }

        [Required]
        [StringLength(1)]
        public string TerminoOperacao { get; set; }
        [Required]
        [StringLength(15)]
        public string TipoOperacao { get; set; }
        [Required]
        [StringLength(8)]
        public string CodEquipamentoUtilizado { get; set; }
        [Required]
        [StringLength(8)]
        public string CodAparelhodeTerra1 { get; set; }
       
        [StringLength(8)]
        public string CodAparelhodeTerra2 { get; set; }


        [StringLength(8)]
        public string CodAparelhodeTerra3 { get; set; }

        [StringLength(8)]
        public string CodAparelhodeTerra4 { get; set; }


        [StringLength(9)]
        public string MatriculaReferencia1 { get; set; }


        [StringLength(9)]
        public string MatriculaReferencia2 { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
