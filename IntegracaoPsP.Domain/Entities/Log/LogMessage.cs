using System;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoPsP.Domain.Entities.Log
{
    public class LogMessage
    {
        public int Id { get; set; }
        public int Linha { get; set; }
        [StringLength(40)]
        public string NomeArquivo { get; set; }
        public  string NomeEntidade { get; set; }
        public DateTime Data { get; set; }
        [StringLength(4000)]
        public string Message { get; set; }
        [StringLength(4000)]
        public string MessageSystem { get; set; }
    }
}
