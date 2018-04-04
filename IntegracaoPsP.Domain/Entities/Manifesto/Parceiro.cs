using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Parceiro
    {
        [Required]
        [Key]
        public int ParceiroId { get; set; }
        [Required]
    
        public int MercadoriaConteinerizadaId { get; set; }

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
        [StringLength(8)]
        public string CNPJBaseParceiro { get; set; }
        [Required]
        [StringLength(4)]
        public string CNPJFilialParceiro { get; set; }
        [Required]
        [StringLength(2)]
        public string CNPJControleParceiro { get; set; }
        [Required]
        [StringLength(60)]
        public string NomeParceiro { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }

    }
}
