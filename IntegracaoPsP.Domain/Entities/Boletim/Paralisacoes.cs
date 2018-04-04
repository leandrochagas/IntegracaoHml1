using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class Paralisacoes
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
        [StringLength(3)]
        public string CodParalisacao { get; set; }
        [Required]
        [StringLength(6)]
        public string HoraInicio { get; set; }

        [Required]
        [StringLength(6)]
        public string HoraFim { get; set; }

     
        [StringLength(60)]
        public string Observacao { get; set; }

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
        [StringLength(1)]
        public string ParalisacaoOgmo { get; set; }
        
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
