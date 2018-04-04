using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class CargaSoltaBoletim
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
        [Required]
        [StringLength(3)]
        public string Item { get; set; }
        [Required]
        [StringLength(8)]
        public string CodigoMercadoria { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeVolumes { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoBruto { get; set; }
        [Required]
        [StringLength(3)]
        public string CodigoEmbalagem { get; set; }

        [StringLength(3)]
        public string Avaria { get; set; }
        [Required]
        [StringLength(20)]
        public string TipoOperacao { get; set; }
      
        [StringLength(14)]
        public string CNPJExportador { get; set; }
       
        [StringLength(5)]
        public string OrigemOuDestino { get; set; }

        [Required]
        [StringLength(60)]
        public string Marca { get; set; }

        [StringLength(60)]
        public string ContraMarca { get; set; }


        [StringLength(50)]
        public string NumeroIdentificacao { get; set; }

        [Required]
        [StringLength(7)]
        public string CodTerminoDestinoOuOrigem { get; set; }

        [StringLength(6)]
        public string HoraOperacao { get; set; }

        [StringLength(5)]
        public string CodPagamentoOgmo { get; set; }

        [StringLength(5)]
        public string Acordo { get; set; }

        [StringLength(1)]
        public string Estivador { get; set; }
        [StringLength(1)]
        public string Conferente { get; set; }
        [StringLength(1)]
        public string Consertador { get; set; }
        [StringLength(1)]
        public string Sintraport { get; set; }
        [StringLength(1)]
        public string Sindaport { get; set; }
        [StringLength(1)]
        public string SindoGeespe { get; set; }
        [StringLength(1)]
        public string Rodoviarios { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoOrigem { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoDestino { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }

    }



}
