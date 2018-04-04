using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Frete
    {
        [Required]
        [Key]
        public int FretelId { get; set; }

        [StringLength(3)]
        public string Identificador { get; set; }
        
        [StringLength(8)]
        public string CNPJBase { get; set; }
        [StringLength(4)]
        public string CNPJFilial { get; set; }
        [StringLength(2)]
        public string CNPJControle { get; set; }
        [StringLength(10)]
        public string NumeroViagem { get; set; }
        [StringLength(30)]
        public string NumeroBoletim { get; set; }
        [StringLength(5)]
        public string PortoEmissao { get; set; }
        [StringLength(4)]
        public string Emitente { get; set; }
        [StringLength(8)]
        public string DataEmissao { get; set; }

        [StringLength(30)]
        public string DescricaoFrete { get; set; }
        [StringLength(5)]
        public string Moeda { get; set; }
        [StringLength(12)]
        public string Valor { get; set; }
        [StringLength(1)]
        public string PrePago { get; set; }
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
