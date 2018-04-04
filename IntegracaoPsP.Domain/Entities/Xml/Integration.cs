using System;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Xml
{
    public class Integration
    {
        [Key]
        [Required]
        public int IntegrationId { get; set; }

        [Required]
        [StringLength(30)]
        public string Entidade { get; set; }
        [Required]
        public DateTime DtEntrada { get; set; }

        [Required]
        [StringLength(8000)]
        
        public string XmlRecebido { get; set; }

        [StringLength(8000)]
        public string XmlAlterado { get; set; }

        public string Situacao { get; set; }

        [StringLength(60)]
        public string NomeArquivo { get; set; }
        public DateTime? DtProcessamento { get; set; }
        public DateTime? DtRetorno { get; set; }

    }


    public class IntegrationHistoryErro
    {
        [Key]
        [Required]
        public int IntegrationHistoryErroId { get; set; }
        public Integration Integration { get; set; }
        public int IntegrationId { get; set; }
        [Required]
        public DateTime DtEntrada { get; set; }

        [Required]
        [StringLength(30)]
        public string TpErro { get; set; }

    }
}
