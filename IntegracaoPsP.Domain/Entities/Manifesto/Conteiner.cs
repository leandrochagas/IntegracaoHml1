using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Conteiner
    {
        [Required]
        [Key]
        public int ConteinerId { get; set; }
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
        [StringLength(11)]
        public string Sigla { get; set; }
        [Required]
        [StringLength(2)]
        public string Tamanho { get; set; }
        [Required]
        [StringLength(2)]
        public string TipoBasico { get; set; }
        
        [StringLength(4)]
        public string Isocode { get; set; }
        [Required]
        [StringLength(8)]
        public string Tara { get; set; }
        [Required]
        [StringLength(8)]
        public string Operacao { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }

    }
}
