using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoPsP.Domain.Entities.Boletim
{
    public class TraillerBoletim
    {

        [Required]
        [StringLength(3)]
        public string Identificador { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro202 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro203 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro204 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro205 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro206 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro207 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro208 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro209 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro210 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro211 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro212 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeRegistro213 { get; set; }
        [Required]
        [StringLength(6)]
        public string QuantidadeTotalRegistro { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
