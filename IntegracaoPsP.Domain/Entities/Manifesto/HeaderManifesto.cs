using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
 
    public class HeaderManifesto
    {

        [Required]
        [Key]
        public int HeaderManifestoId { get; set; }
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
        [StringLength(60)]
        public string NomeEmpresa { get; set; }
        [Required]
        [StringLength(10)]
        public string NumeroViagem { get; set; }
        [Required]
        [StringLength(10)]
        public string NumeroViagemAgencia { get; set; }
        [Required]
        [StringLength(8)]
        public string DataGravacaoArquivo { get; set; }
        [Required]
        [StringLength(6)]
        public string HoraArquivo { get; set; }
        [StringLength(8)]
        public string CNPJBaseDestinatario { get; set; }

        [StringLength(4)]
        public string CNPJFilialDestinatario { get; set; }
        [StringLength(2)]
        public string CNPJControleDestinatario { get; set; }

        [StringLength(60)]
        public string NomeDestinatario { get; set; }

        [StringLength(8)]
        public string LloydRegister { get; set; }

        [Required]
        [StringLength(1)]
        public string TipoArquivo { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
