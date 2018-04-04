using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoPsP.Domain.Entities.Others
{
    public class ModeloXsd
    {
        [Key]
        public int ModeloXsdId { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeArquivo { get; set; }

        [Required]
        [StringLength(10)]
        public string Versao { get; set; }

        [Required]
        [StringLength(8000)]
        public string Modelo { get; set; }
        public bool StAtivo { get; set; }

        public DateTime Data { get; set; }


        [StringLength(30)]
        public string Usuario { get; set; }

    }
}
