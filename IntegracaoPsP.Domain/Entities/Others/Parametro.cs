using System;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Others
{
    public class Parametro
    {
        [Required]
        [Key]
        public int ParametroId { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(200)]
        public string Valor { get; set; }
        public bool StAtivo { get; set; }
        public DateTime Data { get; set; }

        [StringLength(30)]
        public string Usuario { get; set; }
        public Parametro()
        {
            Data = DateTime.Now;
            StAtivo = true;
        }

    }
}
