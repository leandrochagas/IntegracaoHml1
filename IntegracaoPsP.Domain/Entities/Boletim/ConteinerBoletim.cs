using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class ConteinerBoletim
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
        [StringLength(5)]
        public string NumeroBoletim { get; set; }

        [Required]
        [StringLength(11)]
        public string Sigla { get; set; }
        [Required]
        [StringLength(2)]
        public string Tamanho { get; set; }
        [Required]
        [StringLength(2)]
        public string TipoBasico { get; set; }

        [StringLength(3)]
        public string Avaria { get; set; }

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
        [StringLength(20)]
        public string TipoOperacao { get; set; }

        [Required]
        [StringLength(5)]
        public string Situacao { get; set; }
        [Required]
        [StringLength(7)]
        public string DestinoOuOrigem { get; set; }

        [StringLength(6)]
        public string HoraOperacao { get; set; }

        [StringLength(5)]
        public string CodPagamentoOgmo { get; set; }

        [Required]
        [StringLength(4)]
        public string Isocode { get; set; }

        [StringLength(1)]
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

        [StringLength(12)]
        public string Tara { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }


    }
}
