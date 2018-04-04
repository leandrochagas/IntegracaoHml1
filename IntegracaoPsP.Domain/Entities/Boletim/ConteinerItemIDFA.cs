
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace IntegracaoPsP.Domain.Entities.Boletim
{

    //TESTE DE VALIDADOR CONDITIONAL
    public class ConteinerItemIDFA
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
        [RequireWhenCategory]
        public string NumeroBoletim { get; set; }

        [RequireWhenCategory]
        [StringLength(5)]
        public string Portoemissao { get; set; }

        [RequireWhenCategory]
        [StringLength(4)]
        public string Emitente { get; set; }

        [RequireWhenCategory]
        [StringLength(8)]
        public string DataEmissao { get; set; }

        [RequireWhenCategory]
        [StringLength(5)]
        public string PortoDestinoFinal { get; set; }

        [Required]
        [StringLength(11)]
        public string IdConteiner { get; set; }

        [Required]
        [StringLength(1)]
        public string FaltaOuAcrescimo { get; set; }

        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }


        public class RequireWhenCategoryAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var attribute = (ConteinerItemIDFA)validationContext.ObjectInstance;
                if (attribute.FaltaOuAcrescimo != "F")
                {
                    return ValidationResult.Success;
                }
                else
                {
                    var valorcampo = value as string;
                    return string.IsNullOrEmpty(valorcampo) ? new ValidationResult("Value é requerido quando o tipo for falta") : ValidationResult.Success;
                }

            }
        }
    }
}
