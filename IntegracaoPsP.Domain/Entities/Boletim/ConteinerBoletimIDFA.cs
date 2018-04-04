using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class ConteinerBoletimIDFA
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
        public string QteConteinerCheioDescarregado { get; set; }
        [Required]
        [StringLength(5)]
        public string QteConteinerCheioManifesto { get; set; }
        [Required]
        [StringLength(5)]
        public string QteConteinerCheioComManifestoDescarregado  { get; set; }
        [Required]
        [StringLength(5)]
        public string QteConteinervazioDescarregado { get; set; }
        [Required]
        [StringLength(5)]
        public string QteConteinerCheioEmbarcado { get; set; }
        [Required]
        [StringLength(6)]
        public string QteConteinerCheioBalEmbarcado { get; set; }

        [Required]
        [StringLength(6)]
        public string QteConteinerCheiocPCIDescarregado { get; set; }

        [Required]
        [StringLength(6)]
        public string QteConteinerVazioEmbarcado { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }



       
    }
}
