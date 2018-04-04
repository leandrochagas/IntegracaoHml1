using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Manifesto
{
    public class Boletim
    {
        [Required]
        [Key]
        public int BoletimId { get; set; }
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
        [StringLength(30)]
        public string NumeroBoletim { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoEmissao { get; set; }
        [Required]
        [StringLength(4)]
        public string Emitente { get; set; }
        [Required]
        [StringLength(8)]
        public string DataEmissao { get; set; }
        [Required]
        [StringLength(1)]
        public string TipoBoletim { get; set; }
       
        [StringLength(60)]
        public string Observacao { get; set; }
        [Required]
        [StringLength(60)]
        public string Shipper { get; set; }
        [Required]
        [StringLength(60)]
        public string Consignee { get; set; }
        
        [StringLength(60)]
        public string Notify { get; set; }
        
        [StringLength(60)]
        public string Nvocc { get; set; }
       
        [StringLength(5)]
        public string PortodeTransbordo { get; set; }
        [Required]
        [StringLength(5)]
        public string PortodeDestinoFinal { get; set; }
        [Required]
        [StringLength(20)]
        public string CE { get; set; }
        
        [StringLength(10)]
        public string TransitoPara { get; set; }
        [Required]
        [StringLength(20)]
        public string Corrente { get; set; }
        [Required]
        [StringLength(14)]
        public string CNPJShipper { get; set; }
        [Required]
        [StringLength(14)]
        public string CNPJConsigner { get; set; }
       
        [StringLength(14)]
        public string CNPJNotify { get; set; }
       
        [StringLength(14)]
        public string CNPJNvocc { get; set; }
        [Required]
        [StringLength(5)]
        public string UltimoPortoEscala { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }

    public class BoletimMaster
    {
        [Required]
        [Key]
        public int BoletimMasterId { get; set; }
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
        [StringLength(30)]
        public string NumeroBoletim { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoEmissao { get; set; }
        [Required]
        [StringLength(4)]
        public string Emitente { get; set; }
        [Required]
        [StringLength(8)]
        public string DataEmissao { get; set; }
        [Required]
        [StringLength(30)]
        public string NumeroBoletimMaster { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoEmissaoMaster { get; set; }//Bl ou master
        [Required]
        [StringLength(4)]
        public string EmitenteMaster { get; set; }//Bl ou master
        [Required]
        [StringLength(8)]
        public string DataEmissaoMaster { get; set; }//Bl ou master
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; } 

    }

    public class BoletimDescricao
    {

        [Required]
        [Key]
        public int BoletimDescricaoId { get; set; }
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
        [StringLength(30)]
        public string NumeroBoletim { get; set; }
        [Required]
        [StringLength(5)]
        public string PortoEmissao { get; set; }
        [Required]
        [StringLength(4)]
        public string Emitente { get; set; }
        [Required]
        [StringLength(8)]
        public string DataEmissao { get; set; }
   
        [StringLength(11)]
        public string Item { get; set; }
        [Required]
        [StringLength(1)]
        public string Origem { get; set; }
        [Required]
        [StringLength(70)]
        public string Descritivo { get; set; }
        [Required]
        [StringLength(6)]
        public string Sequencial { get; set; }
    }
}
