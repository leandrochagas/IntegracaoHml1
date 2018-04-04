using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class GranelBoletimIDFA
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
        [StringLength(12)]
        public string PesoDescarregado { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoManifestado { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoDescarregadoComManifesto { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoDescarregadoComPCI { get; set; }

        [Required]
        [StringLength(12)]
        public string PesoEmbarcado { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }

    public class GranelItemBoletimIDFA
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


        [StringLength(30)]
        public string NumeroBoletim { get; set; }

     
        [StringLength(5)]
        public string PortoEmissao { get; set; }

      
        [StringLength(4)]
        public string Emitente { get; set; }

       
        [StringLength(8)]
        public string DataEmissao { get; set; }

       
        [StringLength(5)]
        public string PortoDestinoFinal { get; set; }

        [Required]
        [StringLength(8)]
        public string Mercadoria { get; set; }

        [Required]
        [StringLength(12)]
        public string Peso { get; set; }

        [Required]
        [StringLength(1)]
        public string FaltaOuAcrescimo { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }


    }
}
