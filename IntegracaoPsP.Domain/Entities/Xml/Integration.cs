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

        [RequireWhenCategory]
        [StringLength(8000)]
        
        public string XmlRecebido { get; set; }

        [StringLength(8000)]
        public string XmlAlterado { get; set; }

        [StringLength(8000)]
        public string TxtRecebido { get; set; }

        [StringLength(8000)]
        public string TxtAlterado { get; set; }

        public string Situacao { get; set; }

        [StringLength(60)]
        public string NomeArquivo { get; set; }
        public DateTime? DtProcessamento { get; set; }
        public DateTime? DtRetorno { get; set; }
        public int QtdeRegistros { get; set; }

        public class RequireWhenCategoryAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var attribute = (Integration)validationContext.ObjectInstance;
                if (attribute.Entidade != "Boletim" && attribute.Entidade !="Manifesto")
                {
                    return ValidationResult.Success;
                }
                else
                {
                    var valorcampo = value as string;
                    return string.IsNullOrEmpty(valorcampo) ? new ValidationResult("Value é requerido quando o tipo for Xml") : ValidationResult.Success;
                }

            }
        }

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

    public class IntegrationHistoric
    {
        [Key]
        [Required]
        public int IntegrationHistoricId { get; set; }
        [StringLength(60)]
        public string NomeArquivo { get; set; }
        public string Entidade { get; set; }
        public DateTime DataEnvio { get; set; }
        [StringLength(20)]
        public string Ip { get; set; }
        public int QtdeRegistros { get; set; }
      



    }
}
