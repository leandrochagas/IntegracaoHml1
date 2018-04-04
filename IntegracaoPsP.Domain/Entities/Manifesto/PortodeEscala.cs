using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class PortodeEscala
    {
        [Required]
        [Key]
        public int PortodeEscalaId { get; set; }
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
        public string CodigoPortodeEscala { get; set; }
        [Required]
        [StringLength(1)]
        public string PrimeiroPorto { get; set; }
        [Required]
        [StringLength(8)]
        public string DataEntrada { get; set; }
        [Required]
        [StringLength(8)]
        public string DataSaida { get; set; }
        
        [StringLength(4)]
        public string Quantidade { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
