using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class ConteinerCheio
    {
        [Required]
        [Key]
        public int ConteinerCheioId { get; set; }
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
        [StringLength(30)]
        public string NumeroBoletim { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoEmissao { get; set; }

        [Required]
        [StringLength(4)]
        public string Emitente { get; set; }
        [Required]
        [StringLength(8)]
        public string DataEmissao { get; set; }
        [Required]
        [StringLength(11)]
        public string SiglaConteiner { get; set; }
        [Required]
        [StringLength(2)]
        public string Tamanho { get; set; }
        [Required]
        [StringLength(2)]
        public string TipoBasico { get; set; }
        [Required]
        [StringLength(4)]
        public string Isocode { get; set; }
        [Required]
        [StringLength(8)]
        public string Tara { get; set; }
        [Required]
        [StringLength(15)]
        public string LacreOrigem1 { get; set; }
        [StringLength(15)]
        public string LacreOrigem2 { get; set; }
        [StringLength(15)]
        public string LacreOrigem3 { get; set; }
        [StringLength(15)]
        public string LacreOrigem4 { get; set; }
        [Required]
        [StringLength(12)]
        public string PesoBruto { get; set; }
        [Required]
        [StringLength(2)]
        public string RegimeMovimentacao { get; set; }

        [StringLength(7)]
        public string CodigoDestinoouOrigem { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
