using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class CargaGeralIDFA
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
        [StringLength(10)]
        public string QtdeDescarregada { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoDescarregado { get; set; }

        [Required]
        [StringLength(10)]
        public string QtdeManifestada { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoManifestado { get; set; }

        [Required]
        [StringLength(10)]
        public string QtdeDescarregadoComManifesto { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoDescarregadoComManifesto { get; set; }

        [Required]
        [StringLength(10)]
        public string QtdeDescarregadoComPCI { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoDescarregadoComPCI { get; set; }

        [Required]
        [StringLength(10)]
        public string QtdeEmbarcada { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoEmbarcado { get; set; }

        [Required]
        [StringLength(10)]
        public string QtdeTotalEmbarcado { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoTotalEmbarcado { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }

    public class ItemCargaGeralIDFA
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
        [StringLength(30)]
        public string NumeroBoletim { get; set; }

        [StringLength(5)]
        public string PortoEmissao { get; set; }

        [StringLength(4)]
        public string Emitente { get; set; }

        [StringLength(8)]
        public string DataEmissao { get; set; }

        [StringLength(5)]
        public string PortodeDestinoFinal { get; set; }

        [Required]
        [StringLength(8)]
        public string Mercadoria { get; set; }
        [Required]
        [StringLength(5)]
        public string Quantidade { get; set; }
        [Required]
        [StringLength(12)]
        public string Peso { get; set; }
        [Required]
        [StringLength(8)]
        public string FaltaouAcrescimo { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
