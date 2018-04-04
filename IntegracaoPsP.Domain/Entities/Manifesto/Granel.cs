using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Granel
    {
        [Required]
        [Key]
        public int GranelId { get; set; }
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

        [StringLength(3)]
        public string Item { get; set; }
        [Required]
        [StringLength(8)]
        public string CodigoMercadoria { get; set; }
        [Required]
        [StringLength(12)]
        public string PesoBruto { get; set; }
     
        [StringLength(7)]
        public string DestinoouOrigem { get; set; }
     
        [StringLength(3)]
        public string CodigoIMO { get; set; }
    
        [StringLength(4)]
        public string CodigoOnu { get; set; }
      
        [StringLength(20)]
        public string DDE { get; set; }
     
        [StringLength(20)]
        public string RE { get; set; }

        public string Sequencial { get; set; }
    }
}
