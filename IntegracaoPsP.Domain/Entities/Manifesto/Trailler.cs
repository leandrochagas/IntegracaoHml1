using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Trailler
    {
        [Required]
        [Key]
        public int TraillerId { get; set; }

        [Required]
        [StringLength(3)]
        public string Identificador { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro102 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro103 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro104 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro105 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro106 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro107 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro108 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro109 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro110 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro111 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro112 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeTotalRegistro { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
