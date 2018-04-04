using IntegracaoPsP.Domain.Entities.Log;
using IntegracaoPsP.Domain.Entities.Manifesto;
using IntegracaoPsP.Domain.Entities.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using IntegracaoPsP.Web.Models;
using IntegracaoPsP.Domain.Entities.Validacao;
using IntegracaoPsP.Domain.Entities.Boletim;
using System.Xml.Schema;
using System.Xml;
using System.Text.RegularExpressions;

namespace IntegracaoPsP.Service.Functions
{


    public class Utils
    {

        public SqlConnection ConexaoDb()
        {
            SqlConnection objsqlConn;
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            objsqlConn = new SqlConnection(cs);
            return objsqlConn;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        public int CargaeDescargaBoletim { get; private set; }

        #region Constantes de endereços de busca de arquivos

        //string CaminhoBusca = ConfigurationManager.AppSettings["BuscaArquivos"];
        //string CaminhoValido = ConfigurationManager.AppSettings["ArquivosValidos"];
        //string CaminhoErro = ConfigurationManager.AppSettings["ArquivosInvalidos"];
        //string modeloXsd = ConfigurationManager.AppSettings["Modelosxsd"];
        #endregion
        enum DocumentsManifest
        {
            Header = 101,
            Parceiro = 102,
            Conteiner = 103,
            PortosdeEscala = 104,
            Boletim = 105,
            BoletimMaster = 106,
            Frete = 107,
            CargaSolta = 108,
            ConteinerCheio = 109,
            Granel = 110,
            MercadoriaConteinerizada = 111,
            BoletimDescricao = 112,
            Trailler = 199,
            Erro = 999
        };
     
        public List<Data> ReadTxt(string caminho)
        {
            int numeroLinha = 0;
            var list = new List<Data>();
            var fileStream = new FileStream(caminho, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    numeroLinha = numeroLinha + 1;
                    list.Add(new Data(numeroLinha, line));
                }
            }
            return list;
        }


        #region Validate arquivos texto Manifesto
        public HeaderManifesto ValidateHeader(Data linha)
        {
            HeaderManifesto obj = new HeaderManifesto();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NomeEmpresa = linha.StringData.Substring(17, 60).Trim();
                obj.NumeroViagem = linha.StringData.Substring(77, 10).Trim();
                obj.NumeroViagemAgencia = linha.StringData.Substring(87, 10).Trim();
                obj.DataGravacaoArquivo = linha.StringData.Substring(97, 8).Trim();
                obj.HoraArquivo = linha.StringData.Substring(105, 6).Trim();

                if (linha.StringData.Substring(111, 8) != "")//campos não obrigatorios
                {
                    obj.CNPJBaseDestinatario = linha.StringData.Substring(111, 8).Trim();
                    obj.CNPJFilialDestinatario = linha.StringData.Substring(119, 4).Trim();
                    obj.CNPJControleDestinatario = linha.StringData.Substring(123, 2).Trim();
                    obj.NomeDestinatario = linha.StringData.Substring(125, 60).Trim();
                }

                obj.LloydRegister = linha.StringData.Substring(185, 8).Trim();
                obj.TipoArquivo = linha.StringData.Substring(193, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(194, 1).Trim();

            }
            catch
            {
                obj = new HeaderManifesto();
            }
            //finally
            //{

            //    if (obj == null)
            //    {
            //        obj = new HeaderManifesto().Trim();
            //    }
            //}

            return obj;
        }

        public Parceiro ValidateParceiros(Data linha)
        {
            Parceiro obj = new Parceiro();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.CNPJBaseParceiro = linha.StringData.Substring(27, 8).Trim();
                obj.CNPJFilialParceiro = linha.StringData.Substring(35, 4).Trim();
                obj.CNPJControleParceiro = linha.StringData.Substring(39, 2).Trim();
                obj.NomeParceiro = linha.StringData.Substring(41, 60).Trim();
                obj.Sequencial = linha.StringData.Substring(101, 6).Trim();

            }
            catch
            {
                obj = new Parceiro();
            }
           

            return obj;
        }

        public Conteiner ValidateConteiner(Data linha)
        {
            Conteiner obj = new Conteiner();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.Sigla = linha.StringData.Substring(27, 11).Trim();
                obj.Tamanho = linha.StringData.Substring(38, 2).Trim();
                obj.TipoBasico = linha.StringData.Substring(40, 2).Trim();
                obj.Isocode = linha.StringData.Substring(42, 4).Trim();
                obj.Tara = linha.StringData.Substring(46, 8).Trim();
                obj.Operacao = linha.StringData.Substring(54, 8).Trim();
                obj.Sequencial = linha.StringData.Substring(62, 6).Trim();

            }
            catch
            {
                obj = new Conteiner();
            }


            return obj;
        }

        public PortodeEscala ValidatePortodeEscala(Data linha)
        {
            PortodeEscala obj = new PortodeEscala();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.CodigoPortodeEscala = linha.StringData.Substring(27, 5).Trim();
                obj.PrimeiroPorto = linha.StringData.Substring(32, 1).Trim();
                obj.DataEntrada = linha.StringData.Substring(33, 8).Trim();
                obj.DataSaida = linha.StringData.Substring(41, 8).Trim();
                obj.Quantidade = linha.StringData.Substring(49, 4).Trim();
                obj.Sequencial = linha.StringData.Substring(53, 6).Trim();

            }
            catch
            {
                obj = new PortodeEscala();
            }


            return obj;
        }

        public Boletim ValidateBoletim(Data linha)
        {
            Boletim obj = new Boletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.TipoBoletim = linha.StringData.Substring(74, 1).Trim();
                obj.Observacao = linha.StringData.Substring(75, 60).Trim();
                obj.Shipper = linha.StringData.Substring(135, 60).Trim();
                obj.Consignee = linha.StringData.Substring(195, 60).Trim();
                obj.Notify = linha.StringData.Substring(255, 60).Trim();
                obj.Nvocc = linha.StringData.Substring(315, 60).Trim();
                obj.PortodeTransbordo = linha.StringData.Substring(375, 5).Trim();
                obj.PortodeDestinoFinal = linha.StringData.Substring(380, 5).Trim();
                obj.CE = linha.StringData.Substring(385, 20).Trim();
                obj.TransitoPara = linha.StringData.Substring(405, 10).Trim();
                obj.Corrente = linha.StringData.Substring(415, 20).Trim();
                obj.CNPJShipper = linha.StringData.Substring(435, 14).Trim();
                obj.CNPJConsigner = linha.StringData.Substring(449, 14).Trim();
                obj.CNPJNotify = linha.StringData.Substring(465, 14).Trim();
                obj.CNPJNvocc = linha.StringData.Substring(477, 14).Trim();
                obj.UltimoPortoEscala = linha.StringData.Substring(491, 5).Trim();
                obj.Sequencial = linha.StringData.Substring(496, 6).Trim();

            }
            catch
            {
                obj = new Boletim();
            }


            return obj;
        }

        public BoletimMaster ValidateBoletimMaster(Data linha)
        {
            BoletimMaster obj = new BoletimMaster();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.NumeroBoletimMaster = linha.StringData.Substring(74, 30).Trim();
                obj.PortoEmissaoMaster = linha.StringData.Substring(104, 5).Trim();
                obj.EmitenteMaster = linha.StringData.Substring(109, 4).Trim();
                obj.DataEmissaoMaster = linha.StringData.Substring(113, 8).Trim();
                obj.Sequencial = linha.StringData.Substring(121, 6).Trim();

            }
            catch
            {
                obj = new BoletimMaster();
            }


            return obj;
        }

        public Frete ValidateFrete(Data linha)
        {
            Frete obj = new Frete();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.DescricaoFrete = linha.StringData.Substring(74, 30).Trim();
                obj.Moeda = linha.StringData.Substring(104, 5).Trim();
                obj.Valor = linha.StringData.Substring(109, 12).Trim();
                obj.PrePago = linha.StringData.Substring(121, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(122, 6).Trim();

            }
            catch
            {
                obj = new Frete();
            }


            return obj;
        }

        public CargaSolta ValidateCargaSolta(Data linha)
        {
            CargaSolta obj = new CargaSolta();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.Item = linha.StringData.Substring(74, 3).Trim();
                obj.CodigoMercadoria = linha.StringData.Substring(77, 8).Trim();
                obj.QuantidadeVolumes = linha.StringData.Substring(85, 6).Trim();
                obj.PesoBruto = linha.StringData.Substring(91, 12).Trim();
                obj.CodigoEmbalagem = linha.StringData.Substring(103, 10).Trim();
                obj.Marca = linha.StringData.Substring(113, 60).Trim();
                obj.ContraMarca = linha.StringData.Substring(173, 60).Trim();
                obj.Destino = linha.StringData.Substring(233, 60).Trim();
                obj.CodigoImo = linha.StringData.Substring(240, 3).Trim();
                obj.CodigoOnu = linha.StringData.Substring(243, 4).Trim();
                obj.DDE = linha.StringData.Substring(247, 20).Trim();
                obj.RE = linha.StringData.Substring(267, 20).Trim();
                obj.Sequencial = linha.StringData.Substring(287, 6).Trim();

            }
            catch
            {
                obj = new CargaSolta();
            }


            return obj;
        }

        public ConteinerCheio ValidateConteinerCheio(Data linha)
        {
            ConteinerCheio obj = new ConteinerCheio();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.SiglaConteiner = linha.StringData.Substring(74, 11).Trim();
                obj.Tamanho = linha.StringData.Substring(85, 2).Trim();
                obj.TipoBasico = linha.StringData.Substring(87, 2).Trim();
                obj.Isocode = linha.StringData.Substring(89, 4).Trim();
                obj.Tara = linha.StringData.Substring(93, 8).Trim();
                obj.LacreOrigem1 = linha.StringData.Substring(101, 15).Trim();
                obj.LacreOrigem2 = linha.StringData.Substring(116, 15).Trim();
                obj.LacreOrigem3 = linha.StringData.Substring(131, 15).Trim();
                obj.LacreOrigem4 = linha.StringData.Substring(146, 15).Trim();
                obj.PesoBruto = linha.StringData.Substring(161, 12).Trim();
                obj.RegimeMovimentacao = linha.StringData.Substring(173, 2).Trim();
                obj.CodigoDestinoouOrigem = linha.StringData.Substring(175, 7).Trim();
                obj.Sequencial = linha.StringData.Substring(182, 6).Trim();

            }
            catch
            {
                obj = new ConteinerCheio();
            }


            return obj;
        }

        public Granel ValidateGranel(Data linha)
        {
            Granel obj = new Granel();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.Item = linha.StringData.Substring(74, 3).Trim();
                obj.CodigoMercadoria = linha.StringData.Substring(77, 8).Trim();
                obj.PesoBruto = linha.StringData.Substring(85, 12).Trim();
                obj.DestinoouOrigem = linha.StringData.Substring(97, 7).Trim();
                obj.CodigoIMO = linha.StringData.Substring(104, 3).Trim();
                obj.CodigoOnu = linha.StringData.Substring(107, 4).Trim();
                obj.DDE = linha.StringData.Substring(111, 20).Trim();
                obj.RE = linha.StringData.Substring(131, 20).Trim();
                obj.Sequencial = linha.StringData.Substring(151, 6).Trim();

            }
            catch
            {
                obj = new Granel();
            }


            return obj;
        }

        public MercadoriaConteinerizada ValidateMercadoriaConteinerizada(Data linha)
        {
            MercadoriaConteinerizada obj = new MercadoriaConteinerizada();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.Item = linha.StringData.Substring(74, 3).Trim();
                obj.CodigoMercadoria = linha.StringData.Substring(77, 8).Trim();
                obj.QuantidadeVolume = linha.StringData.Substring(85, 6).Trim();
                obj.PesoBruto = linha.StringData.Substring(91, 12).Trim();
                obj.CodigoEmbalagem = linha.StringData.Substring(103, 10).Trim();
                obj.Marca = linha.StringData.Substring(113, 60).Trim();
                obj.ContraMarca = linha.StringData.Substring(173, 60).Trim();
                obj.DestinoouOrigem = linha.StringData.Substring(233, 60).Trim();
                obj.SiglaConteiner = linha.StringData.Substring(240, 11).Trim();
                obj.CodigoIMO = linha.StringData.Substring(251, 3).Trim();
                obj.CodigoOnu = linha.StringData.Substring(254, 4).Trim();
                obj.DDE = linha.StringData.Substring(258, 20).Trim();
                obj.RE = linha.StringData.Substring(278, 20).Trim();
                obj.Sequencial = linha.StringData.Substring(298, 6).Trim();

            }
            catch
            {
                obj = new MercadoriaConteinerizada();
            }


            return obj;
        }

        public BoletimDescricao ValidateBoletimDescricao(Data linha)
        {
            BoletimDescricao obj = new BoletimDescricao();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.Item = linha.StringData.Substring(74, 11).Trim();
                obj.Origem = linha.StringData.Substring(85, 1).Trim();
                obj.Descritivo = linha.StringData.Substring(86, 70).Trim();
                obj.Sequencial = linha.StringData.Substring(156, 6).Trim();

            }
            catch
            {
                obj = new BoletimDescricao();
            }


            return obj;
        }

        public Trailler ValidateTrailler(Data linha, string sequencial)
        {
            Trailler obj = new Trailler();
            try
            {
                obj.Identificador           = linha.StringData.Substring(0, 3).Trim();
                obj.QuantidadeRegistro102   = linha.StringData.Substring(3, 6).Trim();
                obj.QuantidadeRegistro103   = linha.StringData.Substring(9, 6).Trim();
                obj.QuantidadeRegistro104   = linha.StringData.Substring(15, 6).Trim();
                obj.QuantidadeRegistro105   = linha.StringData.Substring(21, 6).Trim();
                obj.QuantidadeRegistro106   = linha.StringData.Substring(27, 6).Trim();
                obj.QuantidadeRegistro107   = linha.StringData.Substring(33, 6).Trim();
                obj.QuantidadeRegistro108   = linha.StringData.Substring(39, 6).Trim();
                obj.QuantidadeRegistro109   = linha.StringData.Substring(45, 6).Trim();
                obj.QuantidadeRegistro110   = linha.StringData.Substring(51, 6).Trim();
                obj.QuantidadeRegistro111   = linha.StringData.Substring(57, 6).Trim();
                obj.QuantidadeRegistro112   = linha.StringData.Substring(63, 6).Trim();
                obj.QuantidadeTotalRegistro = linha.StringData.Substring(69, 6).Trim();
                obj.Sequencial              = sequencial.Substring(7, 6).Replace(".txt","");

            }
            catch
            {
                obj = new Trailler();
            }


            return obj;
        }


        public List<LogMessage> ValidadorManifesto(string caminho, string nomearquivo)
        {

            var validationResults = new List<ValidationResult>();
            Utils util = new Utils();

            List<Data> lista = util.ReadTxt(caminho);
            List<LogMessage> listaLog = new List<LogMessage>();

         //   if (nomearquivo.Contains("ARCBOL"))
          //  {
                #region Objetos Boletim

                HeaderBoletim objHeaderBoletim = new HeaderBoletim();
             //   TransferenciaBoletim objTransferenciaBoletim = new TransferenciaBoletim();
                TransferenciaBoletim objCargaeDescargaBoletim = new TransferenciaBoletim();
                CargaSoltaBoletim objCargaSoltaBoletim = new CargaSoltaBoletim();
                ConteinerBoletim objConteinerBoletim = new ConteinerBoletim();
                GranelBoletim objGranelBoletim = new GranelBoletim();
                Paralisacoes objParalisacoes = new Paralisacoes();
                ConteinerBoletimIDFA objConteinerBoletimIDFA = new ConteinerBoletimIDFA();
                ConteinerItemIDFA objConteinerItemIDFA = new ConteinerItemIDFA();
                CargaGeralIDFA objCargaGeralIDFA = new CargaGeralIDFA();
                ItemCargaGeralIDFA objItemCargaGeralIDFA = new ItemCargaGeralIDFA();
                GranelBoletimIDFA objGranelBoletimIDFA = new GranelBoletimIDFA();
                GranelItemBoletimIDFA objGranelItemBoletimIDFA = new GranelItemBoletimIDFA();
                TraillerBoletim objTraillerBoletim = new TraillerBoletim();
                #endregion
         //   }
          //  else
           // {
                #region Objetos Manifesto
                HeaderManifesto objHeader = new HeaderManifesto();
                Parceiro objParceiro = new Parceiro();
                Conteiner objConteiner = new Conteiner();
                PortodeEscala objPortodeEscala = new PortodeEscala();
                Boletim objBoletim = new Boletim();
                BoletimMaster objBoletimMaster = new BoletimMaster();
                Frete objFrete = new Frete();
                CargaSolta objCargaSolta = new CargaSolta();
                ConteinerCheio objConteinerCheio = new ConteinerCheio();
                Granel objGranel = new Granel();
                MercadoriaConteinerizada objMercadoriaConteinerizada = new MercadoriaConteinerizada();
                BoletimDescricao objBoletimDescricao = new BoletimDescricao();
                Trailler objTrailler = new Trailler();
                #endregion
          //  }




            try
            {

                int linha = 0;

                #region Inicializado Listas

                List<Parceiro> listaParceiro = new List<Parceiro>();
                List<Conteiner> listaConteiner = new List<Conteiner>();
                List<ConteinerCheio> listaConteinerCheio = new List<ConteinerCheio>();
                List<PortodeEscala> listaPortodeEscala = new List<PortodeEscala>();
                List<Boletim> listaBoletim = new List<Boletim>();
                List<BoletimMaster> listaBoletimMaster = new List<BoletimMaster>();

                List<Frete> listaFrete = new List<Frete>();
                List<CargaSolta> listaCargaSolta = new List<CargaSolta>();
                List<Granel> listaGranel = new List<Granel>();
                List<MercadoriaConteinerizada> listaMercadoriaConteinerizada = new List<MercadoriaConteinerizada>();
                List<BoletimDescricao> listaBoletimDescricao = new List<BoletimDescricao>();

                List<TransferenciaBoletim> listaCargaeDescargaBoletim = new List<TransferenciaBoletim>();
                List<CargaSoltaBoletim> listaCargaSoltaBoletim = new List<CargaSoltaBoletim>();
                List<ConteinerBoletim> listaConteinerBoletim = new List<ConteinerBoletim>();
                List<GranelBoletim> listaGranelBoletim = new List<GranelBoletim>();
                List<Paralisacoes> listaParalizacoes = new List<Paralisacoes>();
                List<ConteinerBoletimIDFA> listaConteinerBoletimIDFA = new List<ConteinerBoletimIDFA>();
                List<ConteinerItemIDFA> listaConteinerItemIDFA = new List<ConteinerItemIDFA>();
                List<CargaGeralIDFA> listaCargaGeralIDFA = new List<CargaGeralIDFA>();
                List<ItemCargaGeralIDFA> listaItemCargaGeralIDFA = new List<ItemCargaGeralIDFA>();
                List<GranelBoletimIDFA> listaGranelBoletimIDFA = new List<GranelBoletimIDFA>();
                List<GranelItemBoletimIDFA> listaGranelItemBoletimIDFA = new List<GranelItemBoletimIDFA>();
                List<TraillerBoletim> listaTraillerBoletim = new List<TraillerBoletim>();
                #endregion

                foreach (var item in lista)
                {
                    linha = linha + 1;
                    switch (item.StringData.Substring(0, 3))
                    {
                        #region manifesto
                        case "101":
                            {
                                objHeader = util.ValidateHeader(item);
                                var contextHeader = new ValidationContext(objHeader, serviceProvider: null, items: null);

                                #region Add Erros Header
                                if (Validator.TryValidateObject(objHeader, contextHeader, validationResults, true) == false)
                                {
                                    //erro de validação

                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextHeader.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    // db.HeadersManifesto.Add(objHeader);
                                }
                                #endregion
                                break;
                            }
                        case "102":
                            {
                                objParceiro = util.ValidateParceiros(item);
                                var contextParceiro = new ValidationContext(objParceiro, serviceProvider: null, items: null);
                                #region Add Erros Parceiros
                                if (Validator.TryValidateObject(objParceiro, contextParceiro, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextParceiro.DisplayName,// "Manifesto Header",
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaParceiro.Add(objParceiro);
                                }
                                #endregion
                                break;
                            }
                        case "103":
                            {
                                objConteiner = util.ValidateConteiner(item);
                                var contextConteiner = new ValidationContext(objConteiner, serviceProvider: null, items: null);
                                #region Add Erros Conteiner
                                if (Validator.TryValidateObject(objConteiner, contextConteiner, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextConteiner.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaConteiner.Add(objConteiner);
                                }
                                #endregion
                                break;
                            }
                        case "104":
                            {
                                objPortodeEscala = util.ValidatePortodeEscala(item);
                                var contextPortodeEscala = new ValidationContext(objPortodeEscala, serviceProvider: null, items: null);
                                #region Add Erros Porto Escala
                                if (Validator.TryValidateObject(objPortodeEscala, contextPortodeEscala, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextPortodeEscala.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaPortodeEscala.Add(objPortodeEscala);
                                }
                                #endregion
                                break;
                            }

                        /*Caso o Tipo de BL (105) Seja “S”–SERVIÇO OU “H”–H-BL será obrigatório o registro 106.*/

                        case "105":
                            {
                                objBoletim = util.ValidateBoletim(item);
                                var contextBoletim = new ValidationContext(objBoletim, serviceProvider: null, items: null);
                                #region Add Erros Boletim
                                if (Validator.TryValidateObject(objBoletim, contextBoletim, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaBoletim.Add(objBoletim);
                                }
                                #endregion
                                break;
                            }

                        case "106":
                            {
                                objBoletimMaster = util.ValidateBoletimMaster(item);
                                var contextBoletimMaster = new ValidationContext(objBoletimMaster, serviceProvider: null, items: null);
                                #region Add Erros BoletimMaster
                                if (Validator.TryValidateObject(objBoletimMaster, contextBoletimMaster, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextBoletimMaster.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaBoletimMaster.Add(objBoletimMaster);
                                }
                                #endregion
                                break;
                            }
                        case "107":
                            {
                                objFrete = util.ValidateFrete(item);
                                var contextFrete = new ValidationContext(objFrete, serviceProvider: null, items: null);
                                #region Add Erros Frete
                                if (Validator.TryValidateObject(objFrete, contextFrete, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextFrete.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaFrete.Add(objFrete);
                                }
                                #endregion
                                break;
                            }

                        /*
                         Tendo registro do tipo 105 será obrigatório no arquivo constar registros do tipo 108 OU 109 OU 110 
                        */
                        case "108":
                            {
                                objCargaSolta = util.ValidateCargaSolta(item);
                                var contextCargaSolta = new ValidationContext(objCargaSolta, serviceProvider: null, items: null);
                                #region Add Erros Carga Solta
                                if (Validator.TryValidateObject(objCargaSolta, contextCargaSolta, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextCargaSolta.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }

                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaCargaSolta.Add(objCargaSolta);
                                }
                                #endregion
                                break;
                            }

                        /*
                        Tendo registro do tipo 105 será obrigatório no arquivo constar registros do tipo 108 OU 109 OU 110 
                        Caso o Tipo de BL (105) Seja “S”–SERVIÇO OU “H”–H-BL será obrigatório o registro 106.
                       */

                        case "109":
                            {
                                objConteinerCheio = util.ValidateConteinerCheio(item);
                                var contextConteinerCheio = new ValidationContext(objConteinerCheio, serviceProvider: null, items: null);
                                #region Add Erros Conteiner Cheio
                                if (Validator.TryValidateObject(objConteinerCheio, contextConteinerCheio, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextConteinerCheio.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaConteinerCheio.Add(objConteinerCheio);
                                }
                                #endregion
                                break;
                            }

                        case "110":
                            {
                                objGranel = util.ValidateGranel(item);
                                var contextGranel = new ValidationContext(objGranel, serviceProvider: null, items: null);
                                #region Add Erros Granel
                                if (Validator.TryValidateObject(objGranel, contextGranel, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextGranel.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaGranel.Add(objGranel);
                                }
                                #endregion
                                break;
                            }


                        /*
                        Tendo registro do tipo 109 será obrigatório no arquivo constar registros do tipo 111 
                        */
                        case "111":
                            {
                                objMercadoriaConteinerizada = util.ValidateMercadoriaConteinerizada(item);
                                var contextMercadoriaConteinerizada = new ValidationContext(objMercadoriaConteinerizada, serviceProvider: null, items: null);
                                #region Add Erros Mercadoria Conteinerizada
                                if (Validator.TryValidateObject(objMercadoriaConteinerizada, contextMercadoriaConteinerizada, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextMercadoriaConteinerizada.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaMercadoriaConteinerizada.Add(objMercadoriaConteinerizada);
                                }
                                #endregion
                                break;
                            }

                        case "112":
                            {
                                objBoletimDescricao = util.ValidateBoletimDescricao(item);
                                var contextBoletimDescricao = new ValidationContext(objBoletimDescricao, serviceProvider: null, items: null);
                                #region Add Erros Descrição Boletim
                                if (Validator.TryValidateObject(objBoletimDescricao, contextBoletimDescricao, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextBoletimDescricao.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaBoletimDescricao.Add(objBoletimDescricao);
                                }
                                #endregion
                                break;
                            }

                        case "199":
                            {
                                objTrailler = util.ValidateTrailler(item, nomearquivo);
                                var contextTrailler = new ValidationContext(objTrailler, serviceProvider: null, items: null);
                                #region Add Erros Descrição Boletim
                                if (Validator.TryValidateObject(objTrailler, contextTrailler, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextTrailler.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo

                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    // db.Traillers.Add(objTrailler);
                                }
                                #endregion

                                break;
                            }

                        #endregion

                        #region  Validação de arquivos de boletim

                        case "201":
                            {
                                objHeaderBoletim = util.ValidateBoletimHeader(item);
                                var contextHeaderBoletim = new ValidationContext(objHeaderBoletim, serviceProvider: null, items: null);
                                #region Add Erros Header
                                if (Validator.TryValidateObject(objHeaderBoletim, contextHeaderBoletim, validationResults, true) == false)
                                {
                                    //erro de validação

                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextHeaderBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    // db.HeadersManifesto.Add(objHeader);
                                }
                                #endregion
                                break;
                            }

                            //Verificar 202 transferencias que n existe no documento
                        case "203": //Boletim
                            {
                                objCargaeDescargaBoletim = util.ValidateCargaeDescargaBoletim(item);
                                var contextCargaeDescarga = new ValidationContext(objCargaeDescargaBoletim, serviceProvider: null, items: null);
                                #region Add Erros Carga e descarga
                                if (Validator.TryValidateObject(objCargaeDescargaBoletim, contextCargaeDescarga, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextCargaeDescarga.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaCargaeDescargaBoletim.Add(objCargaeDescargaBoletim);
                                }
                                #endregion
                                break;
                            }
                        case "204":
                            {
                                objCargaSoltaBoletim = util.ValidateCargaSoltaBoletim(item);
                                var contextCargaSoltaBoletim = new ValidationContext(objCargaSoltaBoletim, serviceProvider: null, items: null);
                                #region Add Erros Carga Solta
                                if (Validator.TryValidateObject(objCargaSoltaBoletim, contextCargaSoltaBoletim, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextCargaSoltaBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaCargaSoltaBoletim.Add(objCargaSoltaBoletim);
                                }
                                #endregion
                                break;
                            }
                        case "205":
                            {
                                objConteinerBoletim = util.ValidateConteinerBoletim(item);
                                var contextConteinerBoletim = new ValidationContext(objConteinerBoletim, serviceProvider: null, items: null);
                                #region Add Erros Conteiner Boletim
                                if (Validator.TryValidateObject(objConteinerBoletim, contextConteinerBoletim, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextConteinerBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaConteinerBoletim.Add(objConteinerBoletim);
                                }
                                #endregion
                                break;
                            }

                      

                        case "206":
                            {
                                objGranelBoletim = util.ValidateGranelBoletim(item);
                                var contextobjGranelBoletim = new ValidationContext(objBoletim, serviceProvider: null, items: null);
                                #region Add Erros Boletim
                                if (Validator.TryValidateObject(objGranelBoletim, contextobjGranelBoletim, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextobjGranelBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaGranelBoletim.Add(objGranelBoletim);
                                }
                                #endregion
                                break;
                            }

                        case "207":
                            {
                                objParalisacoes = util.ValidateParalisacoesBoletim(item);
                                var contexobjParalisacoes = new ValidationContext(objParalisacoes, serviceProvider: null, items: null);
                                #region Add Erros Paralisacoes
                                if (Validator.TryValidateObject(objParalisacoes, contexobjParalisacoes, validationResults, true) == false)
                                {
                                    //erro de Paralisacoes
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contexobjParalisacoes.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaParalizacoes.Add(objParalisacoes);
                                }
                                #endregion
                                break;
                            }
                        case "208":
                            {
                                objConteinerBoletimIDFA = util.ValidateConteinerBoletimIDFA(item);
                                var contextConteinerBoletimIDFA = new ValidationContext(objConteinerBoletimIDFA, serviceProvider: null, items: null);
                                #region Add Erros ConteinerBoletimIDFA
                                if (Validator.TryValidateObject(objConteinerBoletimIDFA, contextConteinerBoletimIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextConteinerBoletimIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaConteinerBoletimIDFA.Add(objConteinerBoletimIDFA);
                                }
                                #endregion
                                break;
                            }

                       
                        case "209":
                            {
                                objConteinerItemIDFA = util.ValidateItemConteinerBoletimIDFA(item);
                                var contextConteinerItemIDFA = new ValidationContext(objConteinerItemIDFA, serviceProvider: null, items: null);
                                #region Add Erros ConteinerItemIDFA
                                if (Validator.TryValidateObject(objConteinerItemIDFA, contextConteinerItemIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextConteinerItemIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }

                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaConteinerItemIDFA.Add(objConteinerItemIDFA);
                                }
                                #endregion
                                break;
                            }

                        case "210":
                            {
                                objCargaGeralIDFA = util.ValidateCargaGeralIDFABoletim(item);
                                var contextCargaGeralIDFA = new ValidationContext(objCargaGeralIDFA, serviceProvider: null, items: null);
                                #region Add Erros Conteiner Cheio
                                if (Validator.TryValidateObject(objCargaGeralIDFA, contextCargaGeralIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextCargaGeralIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaCargaGeralIDFA.Add(objCargaGeralIDFA);
                                }
                                #endregion
                                break;
                            }

                        case "211":
                            {
                                objItemCargaGeralIDFA = util.ValidateItemCargaGeralIDFABoletim(item);
                                var contextItemCargaGeralIDFA = new ValidationContext(objItemCargaGeralIDFA, serviceProvider: null, items: null);
                                #region Add Erros ItemCargaGeralIDFA
                                if (Validator.TryValidateObject(objItemCargaGeralIDFA, contextItemCargaGeralIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextItemCargaGeralIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaItemCargaGeralIDFA.Add(objItemCargaGeralIDFA);
                                }
                                #endregion
                                break;
                            }
                        case "212":
                            {
                                objGranelBoletimIDFA = util.ValidateGranelBoletimIDFA(item);
                                var contextGranelBoletimIDFA = new ValidationContext(objGranelBoletimIDFA, serviceProvider: null, items: null);
                                #region Add Erros Mercadoria Conteinerizada
                                if (Validator.TryValidateObject(objGranelBoletimIDFA, contextGranelBoletimIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextGranelBoletimIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaGranelBoletimIDFA.Add(objGranelBoletimIDFA);
                                }
                                #endregion
                                break;
                            }

                        case "213":
                            {
                                objGranelItemBoletimIDFA = util.ValidateGranelItemBoletimIDFA(item);
                                var contextGranelItemBoletimIDFA = new ValidationContext(objGranelItemBoletimIDFA, serviceProvider: null, items: null);
                                #region Add Erros GranelItemBoletimIDFA
                                if (Validator.TryValidateObject(objGranelItemBoletimIDFA, contextGranelItemBoletimIDFA, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextGranelItemBoletimIDFA.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo
                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    listaGranelItemBoletimIDFA.Add(objGranelItemBoletimIDFA);
                                }
                                #endregion
                                break;
                            }

                        case "299":
                            {
                                objTraillerBoletim = util.ValidateTraillerBoletim(item, nomearquivo);
                                var contextTraillerBoletim = new ValidationContext(objTraillerBoletim, serviceProvider: null, items: null);
                                #region Add Erros Descrição Boletim
                                if (Validator.TryValidateObject(objTraillerBoletim, contextTraillerBoletim, validationResults, true) == false)
                                {
                                    //erro de validação
                                    foreach (var itemLog in validationResults)
                                    {
                                        listaLog.Add(new LogMessage
                                        {
                                            Linha = linha,
                                            NomeEntidade = contextTraillerBoletim.DisplayName,
                                            Message = itemLog.ErrorMessage.ToString(),
                                            MessageSystem = itemLog.ErrorMessage.ToString(),
                                            Data = DateTime.Now,
                                            NomeArquivo = nomearquivo

                                        }
                                       );
                                    }
                                    validationResults.Clear();
                                }
                                else
                                {
                                    // db.Traillers.Add(objTrailler);
                                }
                                #endregion
                                
                                break;
                            }
                        #endregion

                        default:
                            break;
                    }

                }


                #region validações adicionais

                if (!nomearquivo.Contains("ARQBOL"))
                {
                    if (objHeader.Sequencial == null || objTrailler.Sequencial == null)
                    {
                        listaLog.Add(new LogMessage
                        {
                            Linha = linha,
                            NomeEntidade = "Header|Trailler",
                            Message = "Erro validação - Manifesto",
                            MessageSystem = "É obrigatório o arquivo possui um Header(101) e um Trailler(199)",
                            Data = DateTime.Now,
                            NomeArquivo = nomearquivo

                        });

                    }
                    else
                    {

                        #region validação registro 105
                        if (int.Parse(objTrailler.QuantidadeRegistro105) > 0)
                        {
                            if (!(int.Parse(objTrailler.QuantidadeRegistro108) > 0 || int.Parse(objTrailler.QuantidadeRegistro109) > 0 || int.Parse(objTrailler.QuantidadeRegistro110) > 0))
                            {
                                //errado

                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "Boletim",
                                    Message = "Erro validação",
                                    MessageSystem = "serão obrigatórios os registros(108 ou 109 ou 110) para registros do tipo 105",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });
                            }
                        }
                        #endregion

                        #region validação registro do tipo "Serviço"

                        if (objBoletim.TipoBoletim == "S" || objBoletim.TipoBoletim == "H")
                        {
                            if (int.Parse(objTrailler.QuantidadeRegistro106) <= 0)
                            {

                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "BoletimMaster",
                                    Message = "Erro validação",
                                    MessageSystem = "Para o tipo de Boletim S ou N é obrigatório o registro do tipo Boletim Master (106)",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });

                            }

                        }

                        #endregion

                        #region validação registro 109

                        if (int.Parse(objTrailler.QuantidadeRegistro109) > 0)
                        {
                            if (int.Parse(objTrailler.QuantidadeRegistro108) <= 0)
                            {
                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "ConteinerCheio",
                                    Message = "Erro validação",
                                    MessageSystem = "Para o tipo de registro 109 é obrigatório o registro de mercadoria conteinerizada(111)",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });
                            }

                        }
                        #endregion
                    }

                }
                else
                {
                    #region Validações adicionais para boletim

                    if (objHeaderBoletim.Sequencial == null || objTraillerBoletim.Sequencial == null)
                    {
                        listaLog.Add(new LogMessage
                        {
                            Linha = linha,
                            NomeEntidade = "Header|Trailler",
                            Message = "Erro validação - Boletim",
                            MessageSystem = "É obrigatório o arquivo possui um Header(201) e um Trailler(299)",
                            Data = DateTime.Now,
                            NomeArquivo = nomearquivo

                        });

                    }
                    else
                    {

                        #region validação registro 203
                        if (listaCargaeDescargaBoletim.Count > 0)
                        {
                            if (!(listaCargaSoltaBoletim.Count >0 || listaConteinerBoletim.Count > 0 || listaGranelBoletim.Count>0 ))
                            {
                                //errado

                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "CargaeDescargaBoletim",
                                    Message = "Erro validação",
                                    MessageSystem = "serão obrigatórios os registros(204 ou 205 ou 206) para registros do tipo 203",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });
                            }
                        }
                        #endregion
                        #region validação registro 208

                        if (listaConteinerBoletimIDFA.Count > 0)
                        {
                            if (listaConteinerItemIDFA.Count <= 0)
                            {
                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "ConteinerBoletimIDFA",
                                    Message = "Erro validação",
                                    MessageSystem = "É obrigatorio existir ao menos um registro de código 209 para itens que possuam registro do tipo 208",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });

                            }

                        }
                        #endregion
                        #region validação registro 210

                        if (listaCargaGeralIDFA.Count > 0)
                        {
                            if (listaItemCargaGeralIDFA.Count <= 0)
                            {
                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "ConteinerBoletimIDFA",
                                    Message = "Erro validação",
                                    MessageSystem = "É obrigatorio existir ao menos um registro de código 211 para itens que possuam registro do tipo 210",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });

                            }

                        }
                        #endregion
                        #region validação registro 212

                        if (listaGranelBoletimIDFA.Count > 0)
                        {
                            if (listaGranelItemBoletimIDFA.Count <= 0)
                            {
                                listaLog.Add(new LogMessage
                                {
                                    Linha = linha,
                                    NomeEntidade = "ConteinerBoletimIDFA",
                                    Message = "Erro validação",
                                    MessageSystem = "É obrigatorio existir ao menos um registro de código 213 para itens que possuam registro do tipo 212",
                                    Data = DateTime.Now,
                                    NomeArquivo = nomearquivo

                                });

                            }

                        }
                        #endregion
                    }

                    #endregion

                }
                

                #endregion

                if (listaLog.Count <= 0)
                {
                    #region criando xml 

                    List<XElement> xEle = new List<XElement>();

                    foreach (var item in lista)
                    {
                        switch (item.StringData.Substring(0, 3))
                        {
                            case "101":
                                {
                                    xEle.Add(
                                              new XElement("Header",
                                                            new XAttribute("IdentificadorHeader", objHeader.Identificador),
                                                            new XAttribute("CnpjHeader", objHeader.CNPJBase + objHeader.CNPJFilial + objHeader.CNPJControle),
                                                            new XAttribute("NomeEmpresaHeader", objHeader.NomeEmpresa),
                                                            new XAttribute("NumeroViagemHeader", objHeader.NumeroViagem),
                                                            new XAttribute("DataGravacaHeader", objHeader.DataGravacaoArquivo),
                                                            new XAttribute("HoraGravacaoHeader", objHeader.HoraArquivo),
                                                            new XAttribute("CnpjDestinatarioHeader", objHeader.CNPJBaseDestinatario + objHeader.CNPJFilialDestinatario + objHeader.CNPJControleDestinatario),
                                                            new XAttribute("NomeDestinatarioHeader", objHeader.NomeDestinatario),
                                                            new XAttribute("LloydRegisterHeader", objHeader.LloydRegister),
                                                            new XAttribute("TipoArquivoHeader", objHeader.TipoArquivo),
                                                            new XAttribute("SequencialHeader", objHeader.Sequencial)
                                                          )
                                        );
                                    break;
                                }
                            case "102":
                                {

                                    foreach (var itemparceiro in listaParceiro.Where(x => x.Sequencial == item.StringData.Substring(101, 6)))
                                    {
                                        xEle.Add(
                                                    new XElement(
                                                                  "Parceiros",
                                                                    new XAttribute("IdentificadorParceiros", itemparceiro.Identificador),
                                                                    new XAttribute("CnpjEmpresaParceiros", itemparceiro.CNPJBase + itemparceiro.CNPJFilial + itemparceiro.CNPJControle),
                                                                    new XAttribute("NumeroViagemParceiros", itemparceiro.NumeroViagem),
                                                                    new XAttribute("CnpjParceiros", itemparceiro.CNPJBaseParceiro + itemparceiro.CNPJFilialParceiro + itemparceiro.CNPJControleParceiro),
                                                                    new XAttribute("NomeParceiros", itemparceiro.NomeParceiro),
                                                                    new XAttribute("SequencialParceiros", itemparceiro.Sequencial)
                                                                  )
                                                );
                                    }

                                    break;
                                }
                            case "103":
                                {
                                    foreach (var itemconteinervazio in listaConteiner.Where(x => x.Sequencial == item.StringData.Substring(62, 6)))
                                    {
                                        xEle.Add(
                                                     new XElement(
                                                                      "ConteinerVazio",
                                                                         new XAttribute("Identificadorconteinervazio", itemconteinervazio.Identificador),
                                                                         new XAttribute("Cnpjconteinervazio", itemconteinervazio.CNPJBase + itemconteinervazio.CNPJFilial + itemconteinervazio.CNPJControle),
                                                                         new XAttribute("NumeroViagemconteinervazio", itemconteinervazio.NumeroViagem),
                                                                         new XAttribute("Siglaconteinervazio", itemconteinervazio.Sigla),
                                                                         new XAttribute("Tamanhoconteinervazio", itemconteinervazio.Tamanho),
                                                                         new XAttribute("TipoBasicoconteinervazio", itemconteinervazio.TipoBasico),
                                                                         new XAttribute("Isocodeconteinervazio", itemconteinervazio.Isocode),
                                                                         new XAttribute("Taraconteinervazio", itemconteinervazio.Tara),
                                                                         new XAttribute("Operacaoconteinervazio", itemconteinervazio.Operacao),
                                                                         new XAttribute("Sequencialconteinervazio", itemconteinervazio.Sequencial)
                                                                       )
                                               );
                                    }
                                    break;
                                }
                            case "104":
                                {
                                    foreach (var itemPortoEscala in listaPortodeEscala.Where(x => x.Sequencial == item.StringData.Substring(53, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "PortoEscala",
                                                                     new XAttribute("IdentificadorPortoEscala", itemPortoEscala.Identificador),
                                                                     new XAttribute("CnpjPortoEscala", itemPortoEscala.CNPJBase + itemPortoEscala.CNPJFilial + itemPortoEscala.CNPJControle),
                                                                     new XAttribute("CodigoPortoEscalaNumeroViagem", itemPortoEscala.NumeroViagem),
                                                                     new XAttribute("CodigoPortodeEscalaPortoEscala", itemPortoEscala.CodigoPortodeEscala),
                                                                     new XAttribute("PrimeiroPortoPortoEscala", itemPortoEscala.PrimeiroPorto),
                                                                     new XAttribute("DataEntradaPortoEscala", itemPortoEscala.DataEntrada),
                                                                     new XAttribute("DataSaidaPortoEscala", itemPortoEscala.DataSaida),
                                                                     new XAttribute("QuantidadePortoEscala", itemPortoEscala.Quantidade),
                                                                     new XAttribute("SequencialPortoEscala", itemPortoEscala.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "105":
                                {
                                    foreach (var itemBoletim in listaBoletim.Where(x => x.Sequencial == item.StringData.Substring(496, 6)))
                                    {
                                        xEle.Add(
                                             new XElement(
                                                           "Boletim",
                                                            new XAttribute("IdentificadorBoletim", itemBoletim.Identificador),
                                                            new XAttribute("CnpjBoletim", itemBoletim.CNPJBase + itemBoletim.CNPJFilial + itemBoletim.CNPJControle),
                                                            new XAttribute("NumeroViagemBoletim", itemBoletim.NumeroViagem),
                                                            new XAttribute("NumeroBoletimBoletim", itemBoletim.NumeroBoletim),
                                                            new XAttribute("PortoEmissaoBoletim", itemBoletim.PortoEmissao),
                                                            new XAttribute("EmitenteBoletim", itemBoletim.Emitente),
                                                            new XAttribute("DataEmissaoBoletim", itemBoletim.DataEmissao),
                                                            new XAttribute("TipoBoletimBoletim", itemBoletim.TipoBoletim),
                                                            new XAttribute("ObservacaoBoletim", itemBoletim.Observacao),
                                                            new XAttribute("ShipperBoletim", itemBoletim.Shipper),
                                                            new XAttribute("ConsigneeBoletim", itemBoletim.Consignee),
                                                            new XAttribute("NotifyBoletim", itemBoletim.Notify),
                                                            new XAttribute("NvoccBoletim", itemBoletim.Nvocc),
                                                            new XAttribute("PortodeTransbordoBoletim", itemBoletim.PortodeTransbordo),
                                                            new XAttribute("PortodeDestinoFinalBoletim", itemBoletim.PortodeDestinoFinal),
                                                            new XAttribute("CEBoletim", itemBoletim.CE),
                                                            new XAttribute("TransitoParaBoletim", itemBoletim.TransitoPara),
                                                            new XAttribute("CorrenteBoletim", itemBoletim.Corrente),
                                                            new XAttribute("CNPJShipperBoletim", itemBoletim.CNPJShipper),
                                                            new XAttribute("CNPJConsignerBoletim", itemBoletim.CNPJConsigner),
                                                            new XAttribute("CNPJNotifyBoletim", itemBoletim.CNPJNotify),
                                                            new XAttribute("CNPJNvoccBoletim", itemBoletim.CNPJNvocc),
                                                            new XAttribute("UltimoPortoEscalaBoletim", itemBoletim.UltimoPortoEscala),
                                                            new XAttribute("SequencialBoletim", itemBoletim.Sequencial)
                                                                        )
                                               );
                                    }
                                    break;
                                }

                            case "106":
                                {
                                    foreach (var itemBoletimMaster in listaBoletimMaster.Where(x => x.Sequencial == item.StringData.Substring(121, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimMaster",
                                                                     new XAttribute("IdentificadorPortoEscala", itemBoletimMaster.Identificador),
                                                                     new XAttribute("CnpjBoletimMaster", itemBoletimMaster.CNPJBase + itemBoletimMaster.CNPJFilial + itemBoletimMaster.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimMaster", itemBoletimMaster.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimBoletimMaster", itemBoletimMaster.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoBoletimMaster", itemBoletimMaster.PortoEmissao),
                                                                     new XAttribute("EmitenteBoletimMaster", itemBoletimMaster.Emitente),
                                                                     new XAttribute("DataEmissaoBoletimMaster", itemBoletimMaster.DataEmissaoMaster),
                                                                     new XAttribute("SequencialBoletimMaster", itemBoletimMaster.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "107":
                                {
                                    foreach (var itemFrete in listaFrete.Where(x => x.Sequencial == item.StringData.Substring(122, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "Frete",
                                                                     new XAttribute("IdentificadorFrete", itemFrete.Identificador),
                                                                     new XAttribute("CnpjFrete", itemFrete.CNPJBase + itemFrete.CNPJFilial + itemFrete.CNPJControle),
                                                                     new XAttribute("NumeroViagemFrete", itemFrete.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimFrete", itemFrete.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoFrete", itemFrete.PortoEmissao),
                                                                     new XAttribute("EmitenteFrete", itemFrete.Emitente),
                                                                     new XAttribute("DataEmissaoFrete", itemFrete.DataEmissao),
                                                                     new XAttribute("DescricaoFreteFrete", itemFrete.DescricaoFrete),
                                                                     new XAttribute("MoedaFrete", itemFrete.Moeda),
                                                                     new XAttribute("ValorFrete", itemFrete.Valor),
                                                                     new XAttribute("PrePagoFrete", itemFrete.PrePago),
                                                                     new XAttribute("SequencialFrete", itemFrete.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "108":
                                {
                                    foreach (var itemCargaSolta in listaCargaSolta.Where(x => x.Sequencial == item.StringData.Substring(287, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "CargaSolta",
                                                                     new XAttribute("IdentificadorCargaSolta", itemCargaSolta.Identificador),
                                                                     new XAttribute("CnpjCargaSolta", itemCargaSolta.CNPJBase + itemCargaSolta.CNPJFilial + itemCargaSolta.CNPJControle),
                                                                     new XAttribute("NumeroViagemCargaSolta", itemCargaSolta.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimCargaSolta", itemCargaSolta.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoCargaSolta", itemCargaSolta.PortoEmissao),
                                                                     new XAttribute("ItemCargaSolta", itemCargaSolta.Item),
                                                                     new XAttribute("CodigoMercadoriaCargaSolta", itemCargaSolta.CodigoMercadoria),
                                                                     new XAttribute("QuantidadeVolumesCargaSolta", itemCargaSolta.QuantidadeVolumes),
                                                                     new XAttribute("PesoBrutoCargaSolta", itemCargaSolta.PesoBruto),
                                                                     new XAttribute("CodigoEmbalagemCargaSolta", itemCargaSolta.CodigoEmbalagem),
                                                                     new XAttribute("MarcaCargaSolta", itemCargaSolta.Marca),
                                                                     new XAttribute("ContraMarcaCargaSolta", itemCargaSolta.ContraMarca),
                                                                     new XAttribute("DestinoCargaSolta", itemCargaSolta.Destino),
                                                                     new XAttribute("CodigoImoCargaSolta", itemCargaSolta.CodigoImo),
                                                                     new XAttribute("CodigoOnuCargaSolta", itemCargaSolta.CodigoOnu),
                                                                     new XAttribute("DDECargaSolta", itemCargaSolta.DDE),
                                                                     new XAttribute("RECargaSolta", itemCargaSolta.RE),
                                                                     new XAttribute("SequencialCargaSolta", itemCargaSolta.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "109":
                                {
                                    foreach (var itemConteinerCheio in listaConteinerCheio.Where(x => x.Sequencial == item.StringData.Substring(182, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "ConteinerCheio",
                                                                     new XAttribute("IdentificadorConteinerCheio", itemConteinerCheio.Identificador),
                                                                     new XAttribute("CnpjConteinerCheio", itemConteinerCheio.CNPJBase + itemConteinerCheio.CNPJFilial + itemConteinerCheio.CNPJControle),
                                                                     new XAttribute("NumeroViagemConteinerCheio", itemConteinerCheio.NumeroViagem),
                                                                     new XAttribute("NumeroConteinerBoletimIDFACheio", itemConteinerCheio.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoConteinerCheio", itemConteinerCheio.PortoEmissao),
                                                                     new XAttribute("EmitenteConteinerCheio", itemConteinerCheio.Emitente),
                                                                     new XAttribute("DataEmissaoConteinerCheio", itemConteinerCheio.DataEmissao),
                                                                     new XAttribute("SiglaConteinerConteinerCheio", itemConteinerCheio.SiglaConteiner),
                                                                     new XAttribute("TamanhoConteinerCheio", itemConteinerCheio.Tamanho),
                                                                     new XAttribute("TipoBasicoConteinerCheio", itemConteinerCheio.TipoBasico),
                                                                     new XAttribute("IsocodeConteinerCheio", itemConteinerCheio.Isocode),
                                                                     new XAttribute("TaraConteinerCheio", itemConteinerCheio.Tara),
                                                                     new XAttribute("LacreOrigem1ConteinerCheio", itemConteinerCheio.LacreOrigem1),
                                                                     new XAttribute("LacreOrigem2ConteinerCheio", itemConteinerCheio.LacreOrigem2),
                                                                     new XAttribute("LacreOrigem3ConteinerCheio", itemConteinerCheio.LacreOrigem3),
                                                                     new XAttribute("LacreOrigem4ConteinerCheio", itemConteinerCheio.LacreOrigem4),
                                                                     new XAttribute("PesoBrutoConteinerCheio", itemConteinerCheio.PesoBruto),
                                                                     new XAttribute("RegimeMovimentacaoConteinerCheio", itemConteinerCheio.RegimeMovimentacao),
                                                                     new XAttribute("CodigoDestinoouOrigemConteinerCheio", itemConteinerCheio.CodigoDestinoouOrigem),
                                                                     new XAttribute("SequencialConteinerCheio", itemConteinerCheio.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "110":
                                {
                                    foreach (var itemGranel in listaGranel.Where(x => x.Sequencial == item.StringData.Substring(151, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "Granel",
                                                                     new XAttribute("IdentificadorGranel", itemGranel.Identificador),
                                                                     new XAttribute("CnpjGranel", itemGranel.CNPJBase + itemGranel.CNPJFilial + itemGranel.CNPJControle),
                                                                     new XAttribute("NumeroViagemGranel", itemGranel.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimGranel", itemGranel.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoGranel", itemGranel.PortoEmissao),
                                                                     new XAttribute("EmitenteGranel", itemGranel.Emitente),
                                                                     new XAttribute("DataEmissaoGranel", itemGranel.DataEmissao),
                                                                     new XAttribute("ItemGranel", itemGranel.Item),
                                                                     new XAttribute("CodigoMercadoriaGranel", itemGranel.CodigoMercadoria),
                                                                     new XAttribute("PesoBrutoGranel", itemGranel.PesoBruto),
                                                                     new XAttribute("DestinoouOrigemGranel", itemGranel.DestinoouOrigem),
                                                                     new XAttribute("CodigoImoGranel", itemGranel.CodigoIMO),
                                                                     new XAttribute("CodigoOnuGranel", itemGranel.CodigoOnu),
                                                                     new XAttribute("DDEGranel", itemGranel.DDE),
                                                                     new XAttribute("REGranel", itemGranel.RE),
                                                                     new XAttribute("SequencialGranel", itemGranel.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "111":
                                {
                                    foreach (var itemMercadoriaConteinerizada in listaMercadoriaConteinerizada.Where(x => x.Sequencial == item.StringData.Substring(53, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "MercadoriaConteinerizada",
                                                                      new XAttribute("IdentificadorMercadoriaConteinerizada", itemMercadoriaConteinerizada.Identificador),
                                                                     new XAttribute("CnpjMercadoriaConteinerizada", itemMercadoriaConteinerizada.CNPJBase + itemMercadoriaConteinerizada.CNPJFilial + itemMercadoriaConteinerizada.CNPJControle),
                                                                     new XAttribute("NumeroViagemMercadoriaConteinerizada", itemMercadoriaConteinerizada.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimMercadoriaConteinerizada", itemMercadoriaConteinerizada.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoMercadoriaConteinerizada", itemMercadoriaConteinerizada.PortoEmissao),
                                                                     new XAttribute("EmitenteMercadoriaConteinerizada", itemMercadoriaConteinerizada.Emitente),
                                                                     new XAttribute("DataEmissaoMercadoriaConteinerizada", itemMercadoriaConteinerizada.DataEmissao),
                                                                     new XAttribute("ItemMercadoriaConteinerizada", itemMercadoriaConteinerizada.Item),
                                                                     new XAttribute("CodigoMercadoriaMercadoriaConteinerizada", itemMercadoriaConteinerizada.CodigoMercadoria),
                                                                     new XAttribute("QuantidadeVolumeMercadoriaConteinerizada", itemMercadoriaConteinerizada.QuantidadeVolume),
                                                                     new XAttribute("PesoBrutoMercadoriaConteinerizada", itemMercadoriaConteinerizada.PesoBruto),
                                                                     new XAttribute("CodigoEmbalagemMercadoriaConteinerizada", itemMercadoriaConteinerizada.CodigoEmbalagem),
                                                                     new XAttribute("MarcaMercadoriaConteinerizada", itemMercadoriaConteinerizada.Marca),
                                                                     new XAttribute("ContraMarcaMercadoriaConteinerizada", itemMercadoriaConteinerizada.ContraMarca),
                                                                     new XAttribute("DestinoouOrigemMercadoriaConteinerizada", itemMercadoriaConteinerizada.DestinoouOrigem),
                                                                     new XAttribute("SiglaConteinerMercadoriaConteinerizada", itemMercadoriaConteinerizada.SiglaConteiner),
                                                                     new XAttribute("DestinoouOrigemConteinerizada", itemMercadoriaConteinerizada.CodigoIMO),
                                                                     new XAttribute("CodigoIMOConteinerizada", itemMercadoriaConteinerizada.CodigoOnu),
                                                                     new XAttribute("DDEMercadoriaConteinerizada", itemMercadoriaConteinerizada.DDE),
                                                                     new XAttribute("REMercadoriaConteinerizada", itemMercadoriaConteinerizada.RE),
                                                                     new XAttribute("SequencialMercadoriaConteinerizada", itemMercadoriaConteinerizada.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }
                            case "112":
                                {
                                    foreach (var itemBoletimDescricao in listaBoletimDescricao.Where(x => x.Sequencial == item.StringData.Substring(156, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimDescricao",
                                                                     new XAttribute("IdentificadorBoletimDescricao", itemBoletimDescricao.Identificador),
                                                                     new XAttribute("CnpjBoletimDescricao", itemBoletimDescricao.CNPJBase + itemBoletimDescricao.CNPJFilial + itemBoletimDescricao.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimDescricao", itemBoletimDescricao.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimBoletimDescricao", itemBoletimDescricao.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoBoletimDescricao", itemBoletimDescricao.PortoEmissao),
                                                                     new XAttribute("Emitente", itemBoletimDescricao.Emitente),
                                                                     new XAttribute("DataEmissao", itemBoletimDescricao.DataEmissao),
                                                                     new XAttribute("ItemBoletimDescricao", itemBoletimDescricao.Item),
                                                                     new XAttribute("OrigemBoletimDescricao", itemBoletimDescricao.Origem),
                                                                     new XAttribute("DescritivoBoletimDescricao", itemBoletimDescricao.Descritivo),
                                                                     new XAttribute("SequencialBoletimDescricao", itemBoletimDescricao.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "199":
                                {

                                    xEle.Add(
                                               new XElement(
                                                                "Trailler",
                                                                 new XAttribute("IdentificadorTrailler", objTrailler.Identificador),
                                                                 new XAttribute("QuantidadeRegistro102Trailler", objTrailler.QuantidadeRegistro102),
                                                                 new XAttribute("QuantidadeRegistro103Trailler", objTrailler.QuantidadeRegistro103),
                                                                 new XAttribute("QuantidadeRegistro104Trailler", objTrailler.QuantidadeRegistro103),
                                                                 new XAttribute("QuantidadeRegistro105Trailler", objTrailler.QuantidadeRegistro105),
                                                                 new XAttribute("QuantidadeRegistro106Trailler", objTrailler.QuantidadeRegistro106),
                                                                 new XAttribute("QuantidadeRegistro107Trailler", objTrailler.QuantidadeRegistro107),
                                                                 new XAttribute("QuantidadeRegistro108Trailler", objTrailler.QuantidadeRegistro108),
                                                                 new XAttribute("QuantidadeRegistro109Trailler", objTrailler.QuantidadeRegistro109),
                                                                 new XAttribute("QuantidadeRegistro110Trailler", objTrailler.QuantidadeRegistro110),
                                                                 new XAttribute("QuantidadeRegistro111Trailler", objTrailler.QuantidadeRegistro111),
                                                                 new XAttribute("QuantidadeRegistro112Trailler", objTrailler.QuantidadeRegistro112),
                                                                 new XAttribute("QuantidadeTotalRegistroTrailler", objTrailler.QuantidadeTotalRegistro),
                                                                 new XAttribute("SequencialTrailler", objTrailler.Sequencial)
                                                           )

                                           );

                                    break;
                                }



                            case "201":
                                {

                                    xEle.Add(
                                             new XElement("HeaderBoletim",
                                                           new XAttribute("IdentificadorHeader", objHeaderBoletim.Identificador),
                                                           new XAttribute("CnpjHeader", objHeaderBoletim.CNPJBase + objHeaderBoletim.CNPJFilial + objHeaderBoletim.CNPJControle),
                                                           new XAttribute("NomeOperador", objHeaderBoletim.NomeOperador),
                                                           new XAttribute("NumeroViagemHeader", objHeaderBoletim.NumeroViagem),
                                                           new XAttribute("DataGravacaHeader", objHeaderBoletim.DataGravacaoArquivo),
                                                           new XAttribute("HoraGravacaoHeader", objHeaderBoletim.HoraArquivo),
                                                           new XAttribute("CnpjDestinatarioHeader", objHeaderBoletim.CNPJBaseDestinatario + objHeader.CNPJFilialDestinatario + objHeader.CNPJControleDestinatario),
                                                           new XAttribute("NomeDestinatarioHeader", objHeaderBoletim.NomeDestinatario),
                                                           new XAttribute("NomeNavioHeader", objHeaderBoletim.NomeNavio),
                                                           new XAttribute("LloydRegisterHeader", objHeaderBoletim.LloydRegister),
                                                           new XAttribute("TipoArquivoHeader", objHeaderBoletim.TipoArquivo),
                                                           new XAttribute("SequencialHeader", objHeaderBoletim.Sequencial)
                                                         )
                                       );

                                    break;
                                }

                            case "202":
                                {
                                    //SEM DOCUMENTAÇÃO DE EXPECIFICAÇÃO


                                    //xEle.Add(
                                    //         new XElement("TransferenciaBoletim",
                                    //                       new XAttribute("IdentificadorHeader", objHeaderBoletim.Identificador),
                                    //                       new XAttribute("CnpjHeader", objHeaderBoletim.CNPJBase + objHeaderBoletim.CNPJFilial + objHeaderBoletim.CNPJControle),
                                    //                       new XAttribute("NomeOperador", objHeaderBoletim.NomeOperador),
                                    //                       new XAttribute("NumeroViagemHeader", objHeaderBoletim.NumeroViagem),
                                    //                       new XAttribute("DataGravacaHeader", objHeaderBoletim.DataGravacaoArquivo),
                                    //                       new XAttribute("HoraGravacaoHeader", objHeaderBoletim.HoraArquivo),
                                    //                       new XAttribute("CnpjDestinatarioHeader", objHeaderBoletim.CNPJBaseDestinatario + objHeader.CNPJFilialDestinatario + objHeader.CNPJControleDestinatario),
                                    //                       new XAttribute("NomeDestinatarioHeader", objHeaderBoletim.NomeDestinatario),
                                    //                       new XAttribute("LloydRegisterHeader", objHeaderBoletim.NomeNavio),
                                    //                       new XAttribute("LloydRegisterHeader", objHeaderBoletim.LloydRegister),
                                    //                       new XAttribute("TipoArquivoHeader", objHeaderBoletim.TipoArquivo),
                                    //                       new XAttribute("SequencialHeader", objHeaderBoletim.Sequencial)
                                    //                     )
                                    //   );

                                    break;
                                }

                            case "203":
                                {
                                    foreach (var itemBoletimCargaeDescarga in listaCargaeDescargaBoletim.Where(x => x.Sequencial == item.StringData.Substring(169, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimCargaeDescarga",
                                                                     new XAttribute("IdentificadorBoletimCargaeDescarga", itemBoletimCargaeDescarga.Identificador),
                                                                     new XAttribute("CnpjBoletimCargaeDescarga", itemBoletimCargaeDescarga.CNPJBase + itemBoletimCargaeDescarga.CNPJFilial + itemBoletimCargaeDescarga.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimCargaeDescarga", itemBoletimCargaeDescarga.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimCargaeDescarga", itemBoletimCargaeDescarga.NumeroBoletim),
                                                                     new XAttribute("LocalOperacaoBoletimCargaeDescarga", itemBoletimCargaeDescarga.LocalOperacao),
                                                                     new XAttribute("AoLargoBoletimCargaeDescarga", itemBoletimCargaeDescarga.AoLargo),
                                                                     new XAttribute("TipoNavegacaoBoletimCargaeDescarga", itemBoletimCargaeDescarga.TipoNavegacao),
                                                                     new XAttribute("DataInicialBoletimCargaeDescarga", itemBoletimCargaeDescarga.DataInicial),
                                                                     new XAttribute("DataFinalBoletimCargaeDescarga", itemBoletimCargaeDescarga.DataFinal),
                                                                     new XAttribute("PeriodoTrabalhoBoletimCargaeDescarga", itemBoletimCargaeDescarga.PeriodoTrabalho),
                                                                     new XAttribute("TernoBoletimCargaeDescarga", itemBoletimCargaeDescarga.Terno),
                                                                     new XAttribute("PoraoBoletimCargaeDescarga", itemBoletimCargaeDescarga.Porao),
                                                                     new XAttribute("PrimeiraLingadaBoletimCargaeDescarga", itemBoletimCargaeDescarga.PrimeiraLingada),
                                                                     new XAttribute("UltimaLingadaBoletimCargaeDescarga", itemBoletimCargaeDescarga.UltimaLingada),
                                                                     new XAttribute("TerminoOperacaoBoletimCargaeDescarga", itemBoletimCargaeDescarga.TerminoOperacao),
                                                                     new XAttribute("CodEquipamentoUtilizadoBoletimCargaeDescarga", itemBoletimCargaeDescarga.CodEquipamentoUtilizado),
                                                                     new XAttribute("CodAparelhodeTerra1BoletimCargaeDescarga", itemBoletimCargaeDescarga.CodAparelhodeTerra1),
                                                                     new XAttribute("CodAparelhodeTerra2BoletimCargaeDescarga", itemBoletimCargaeDescarga.CodAparelhodeTerra2),
                                                                     new XAttribute("CodAparelhodeTerra3BoletimCargaeDescarga", itemBoletimCargaeDescarga.CodAparelhodeTerra3),
                                                                     new XAttribute("CodAparelhodeTerra4BoletimCargaeDescarga", itemBoletimCargaeDescarga.CodAparelhodeTerra4),
                                                                     new XAttribute("MatriculaReferencia1BoletimCargaeDescarga", itemBoletimCargaeDescarga.MatriculaReferencia1),
                                                                     new XAttribute("MatriculaReferencia2BoletimCargaeDescarga", itemBoletimCargaeDescarga.MatriculaReferencia2),
                                                                     new XAttribute("SequencialBoletimDescricao", itemBoletimCargaeDescarga.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "204":
                                {
                                    foreach (var itemBoletimCargaSolta in listaCargaSoltaBoletim.Where(x => x.Sequencial == item.StringData.Substring(316, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimCargaSolta",
                                                                     new XAttribute("IdentificadorCargaSoltaBoletim", itemBoletimCargaSolta.Identificador),
                                                                     new XAttribute("CnpjCargaSoltaBoletim", itemBoletimCargaSolta.CNPJBase + itemBoletimCargaSolta.CNPJFilial + itemBoletimCargaSolta.CNPJControle),
                                                                     new XAttribute("NumeroViagemCargaSoltaBoletim", itemBoletimCargaSolta.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimCargaSoltaBoletim", itemBoletimCargaSolta.NumeroBoletim),
                                                                     new XAttribute("ItemBoletimCargaSolta", itemBoletimCargaSolta.Item),
                                                                     new XAttribute("CodigoMercadoriaBoletimCargaSolta", itemBoletimCargaSolta.CodigoMercadoria),
                                                                     new XAttribute("QuantidadeVolumesBoletimCargaSolta", itemBoletimCargaSolta.QuantidadeVolumes),
                                                                     new XAttribute("PesoBrutoBoletimCargaSolta", itemBoletimCargaSolta.PesoBruto),
                                                                     new XAttribute("CodigoEmbalagemBoletimCargaSolta", itemBoletimCargaSolta.CodigoEmbalagem),
                                                                     new XAttribute("AvariaBoletimCargaSolta", itemBoletimCargaSolta.Avaria),
                                                                     new XAttribute("TipoOperacaoBoletimCargaSolta", itemBoletimCargaSolta.TipoOperacao),
                                                                     new XAttribute("CNPJExportadorBoletimCargaSolta", itemBoletimCargaSolta.CNPJExportador),
                                                                     new XAttribute("OrigemOuDestinoBoletimCargaSolta", itemBoletimCargaSolta.OrigemOuDestino),
                                                                     new XAttribute("HoraOperacaoBoletimCargaSolta", itemBoletimCargaSolta.HoraOperacao),
                                                                     new XAttribute("CodPagamentoOgmoBoletimCargaSolta", itemBoletimCargaSolta.CodPagamentoOgmo),
                                                                     new XAttribute("AcordoBoletimCargaSolta", itemBoletimCargaSolta.Acordo),
                                                                     new XAttribute("EstivadorBoletimCargaSolta", itemBoletimCargaSolta.Estivador),
                                                                     new XAttribute("ConferenteBoletimCargaSolta", itemBoletimCargaSolta.Conferente),
                                                                     new XAttribute("ConsertadorBoletimCargaSolta", itemBoletimCargaSolta.Consertador),
                                                                     new XAttribute("SintraportBoletimCargaSolta", itemBoletimCargaSolta.Sintraport),
                                                                     new XAttribute("SindaportBoletimCargaSolta", itemBoletimCargaSolta.Sindaport),
                                                                     new XAttribute("SindoGeespeBoletimCargaSolta", itemBoletimCargaSolta.SindoGeespe),
                                                                     new XAttribute("RodoviariosBoletimCargaSolta", itemBoletimCargaSolta.Rodoviarios),
                                                                     new XAttribute("PortoOrigemBoletimCargaSolta", itemBoletimCargaSolta.PortoOrigem),
                                                                     new XAttribute("PortoDestinoBoletimCargaSolta", itemBoletimCargaSolta.PortoDestino),
                                                                     new XAttribute("SequencialBoletimCargaSolta", itemBoletimCargaSolta.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "205":
                                {
                                    foreach (var itemBoletimConteiner in listaConteinerBoletim.Where(x => x.Sequencial == item.StringData.Substring(199, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimConteiner",
                                                                     new XAttribute("IdentificadorBoletimConteiner", itemBoletimConteiner.Identificador),
                                                                     new XAttribute("CnpjBoletimConteiner", itemBoletimConteiner.CNPJBase + itemBoletimConteiner.CNPJFilial + itemBoletimConteiner.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimConteiner", itemBoletimConteiner.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimConteinerBoletim", itemBoletimConteiner.NumeroBoletim),
                                                                     new XAttribute("SiglaBoletimConteiner", itemBoletimConteiner.Sigla),
                                                                     new XAttribute("TamanhoBoletimConteiner", itemBoletimConteiner.Tamanho),
                                                                     new XAttribute("TipoBasicoBoletimConteiner", itemBoletimConteiner.TipoBasico),
                                                                     new XAttribute("AvariaBoletimConteiner", itemBoletimConteiner.Avaria),
                                                                     new XAttribute("LacreOrigem1BoletimConteiner", itemBoletimConteiner.LacreOrigem1),
                                                                     new XAttribute("LacreOrigem2BoletimConteiner", itemBoletimConteiner.LacreOrigem2),
                                                                     new XAttribute("LacreOrigem3BoletimConteiner", itemBoletimConteiner.LacreOrigem3),
                                                                     new XAttribute("LacreOrigem4BoletimConteiner", itemBoletimConteiner.LacreOrigem4),
                                                                     new XAttribute("PesoBrutoBoletimConteiner", itemBoletimConteiner.PesoBruto),
                                                                     new XAttribute("TipoOperacaoBoletimConteiner", itemBoletimConteiner.TipoOperacao),
                                                                     new XAttribute("SituacaoBoletimConteiner", itemBoletimConteiner.Situacao),                                                                
                                                                     new XAttribute("DestinoOuOrigemBoletimConteiner", itemBoletimConteiner.DestinoOuOrigem),
                                                                     new XAttribute("HoraOperacaoBoletimConteiner", itemBoletimConteiner.HoraOperacao),
                                                                     new XAttribute("CodPagamentoOgmoBoletimConteiner", itemBoletimConteiner.CodPagamentoOgmo),
                                                                     new XAttribute("IsocodeBoletimConteiner", itemBoletimConteiner.Isocode),
                                                                     new XAttribute("AcordoBoletimConteiner", itemBoletimConteiner.Acordo),
                                                                     new XAttribute("EstivadorBoletimConteiner", itemBoletimConteiner.Estivador),
                                                                     new XAttribute("ConferenteBoletimConteiner", itemBoletimConteiner.Conferente),
                                                                     new XAttribute("ConsertadorBoletimConteiner", itemBoletimConteiner.Consertador),
                                                                     new XAttribute("SintraportBoletimConteiner", itemBoletimConteiner.Sintraport),
                                                                     new XAttribute("SindaportBoletimConteiner", itemBoletimConteiner.Sindaport),
                                                                     new XAttribute("SindoGeespeBoletimConteiner", itemBoletimConteiner.SindoGeespe),
                                                                     new XAttribute("RodoviariosBoletimConteiner", itemBoletimConteiner.Rodoviarios),
                                                                     new XAttribute("PortoOrigemBoletimConteiner", itemBoletimConteiner.PortoOrigem),
                                                                     new XAttribute("PortoDestinoBoletimConteiner", itemBoletimConteiner.PortoDestino),
                                                                     new XAttribute("TaraBoletimConteiner", itemBoletimConteiner.Tara),
                                                                     new XAttribute("SequencialBoletimConteiner", itemBoletimConteiner.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }
                            case "206":
                                {
                                    foreach (var itemBoletimGranel in listaGranelBoletim.Where(x => x.Sequencial == item.StringData.Substring(109, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimGranel",
                                                                     new XAttribute("IdentificadorBoletimGranel", itemBoletimGranel.Identificador),
                                                                     new XAttribute("CnpjBoletimGranel", itemBoletimGranel.CNPJBase + itemBoletimGranel.CNPJFilial + itemBoletimGranel.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimGranel", itemBoletimGranel.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimGranelBoletim", itemBoletimGranel.NumeroBoletim),
                                                                     new XAttribute("ItemBoletimGranel", itemBoletimGranel.Item),
                                                                     new XAttribute("CodigoMercadoriaBoletimGranel", itemBoletimGranel.CodigoMercadoria),                                                                    
                                                                     new XAttribute("PesoBrutoBoletimGranel", itemBoletimGranel.PesoBruto),
                                                                     new XAttribute("TipoOperacaoBoletimGranel", itemBoletimGranel.TipoOperacao),                                                                   
                                                                     new XAttribute("DestinoOuOrigemBoletimGranel", itemBoletimGranel.DestinoOuOrigem),                                                                   
                                                                     new XAttribute("CodPagamentoOgmoBoletimGranel", itemBoletimGranel.CodPagamentoOgmo),                                                       
                                                                     new XAttribute("AcordoBoletimGranel", itemBoletimGranel.Acordo),
                                                                     new XAttribute("EstivadorBoletimGranel", itemBoletimGranel.Estivador),
                                                                     new XAttribute("ConferenteBoletimGranel", itemBoletimGranel.Conferente),
                                                                     new XAttribute("ConsertadorBoletimGranel", itemBoletimGranel.Consertador),
                                                                     new XAttribute("SintraportBoletimGranel", itemBoletimGranel.Sintraport),
                                                                     new XAttribute("SindaportBoletimGranel", itemBoletimGranel.Sindaport),
                                                                     new XAttribute("SindoGeespeBoletimGranel", itemBoletimGranel.SindoGeespe),
                                                                     new XAttribute("RodoviariosBoletimGranel", itemBoletimGranel.Rodoviarios),
                                                                     new XAttribute("PortoOrigemBoletimGranel", itemBoletimGranel.PortoOrigem),
                                                                     new XAttribute("PortoDestinoBoletimGranel", itemBoletimGranel.PortoDestino),                                                          
                                                                     new XAttribute("SequencialBoletimGranel", itemBoletimGranel.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "207":
                                {
                                    foreach (var itemBoletimParalizacoes in listaParalizacoes.Where(x => x.Sequencial == item.StringData.Substring(115, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "BoletimParalizacoes",
                                                                     new XAttribute("IdentificadorBoletimParalizacoes", itemBoletimParalizacoes.Identificador),
                                                                     new XAttribute("CnpjBoletimParalizacoes", itemBoletimParalizacoes.CNPJBase + itemBoletimParalizacoes.CNPJFilial + itemBoletimParalizacoes.CNPJControle),
                                                                     new XAttribute("NumeroViagemBoletimParalizacoes", itemBoletimParalizacoes.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimParalizacoesBoletim", itemBoletimParalizacoes.NumeroBoletim),
                                                                     new XAttribute("CodParalisacaoBoletimParalizacoes", itemBoletimParalizacoes.CodParalisacao),
                                                                     new XAttribute("HoraInicioBoletimParalizacoes", itemBoletimParalizacoes.HoraInicio),
                                                                     new XAttribute("HoraFimBoletimParalizacoes", itemBoletimParalizacoes.HoraFim),
                                                                     new XAttribute("ObservacaoBoletimParalizacoes", itemBoletimParalizacoes.Observacao),                                                                    
                                                                     new XAttribute("EstivadorBoletimParalizacoes", itemBoletimParalizacoes.Estivador),
                                                                     new XAttribute("ConferenteBoletimParalizacoes", itemBoletimParalizacoes.Conferente),
                                                                     new XAttribute("ConsertadorBoletimParalizacoes", itemBoletimParalizacoes.Consertador),
                                                                     new XAttribute("SintraportBoletimParalizacoes", itemBoletimParalizacoes.Sintraport),
                                                                     new XAttribute("SindaportBoletimParalizacoes", itemBoletimParalizacoes.Sindaport),
                                                                     new XAttribute("SindoGeespeBoletimParalizacoes", itemBoletimParalizacoes.SindoGeespe),
                                                                     new XAttribute("RodoviariosBoletimParalizacoes", itemBoletimParalizacoes.Rodoviarios),
                                                                     new XAttribute("ParalisacaoOgmoBoletimParalizacoes", itemBoletimParalizacoes.ParalisacaoOgmo),                                                  
                                                                     new XAttribute("SequencialBoletimParalizacoes", itemBoletimParalizacoes.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "208":
                                {
                                    foreach (var itemConteinerBoletimIDFA in listaConteinerBoletimIDFA.Where(x => x.Sequencial == item.StringData.Substring(70, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "ConteinerBoletimIDFA",
                                                                     new XAttribute("IdentificadorConteinerBoletimIDFA", itemConteinerBoletimIDFA.Identificador),
                                                                     new XAttribute("CnpjConteinerBoletimIDFA", itemConteinerBoletimIDFA.CNPJBase + itemConteinerBoletimIDFA.CNPJFilial + itemConteinerBoletimIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemConteinerBoletimIDFA", itemConteinerBoletimIDFA.NumeroViagem),
                                                                     new XAttribute("QteConteinerCheioDescarregadoBoletimIDFABoletim", itemConteinerBoletimIDFA.QteConteinerCheioDescarregado),
                                                                     new XAttribute("QteConteinerCheioManifestoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerCheioManifesto),
                                                                     new XAttribute("QteConteinerCheioComManifestoDescarregadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerCheioComManifestoDescarregado),
                                                                     new XAttribute("QteConteinervazioDescarregadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinervazioDescarregado),
                                                                     new XAttribute("QteConteinerCheioEmbarcadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerCheioEmbarcado),
                                                                     new XAttribute("QteConteinerCheioBalEmbarcadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerCheioBalEmbarcado),
                                                                     new XAttribute("QteConteinerCheiocPCIDescarregadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerCheiocPCIDescarregado),
                                                                     new XAttribute("QteConteinerVazioEmbarcadoConteinerBoletimIDFA", itemConteinerBoletimIDFA.QteConteinerVazioEmbarcado),                                                       
                                                                     new XAttribute("SequencialConteinerBoletimIDFA", itemConteinerBoletimIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "209":
                                {
                                    foreach (var itemConteinerItemIDFA in listaConteinerItemIDFA.Where(x => x.Sequencial == item.StringData.Substring(70, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "ConteinerItemIDFA",
                                                                     new XAttribute("IdentificadorConteinerBoletimIDFA", itemConteinerItemIDFA.Identificador),
                                                                     new XAttribute("CnpjConteinerItemIDFA", itemConteinerItemIDFA.CNPJBase + itemConteinerItemIDFA.CNPJFilial + itemConteinerItemIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemConteinerItemIDFA", itemConteinerItemIDFA.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimBoletimIDFABoletim", itemConteinerItemIDFA.NumeroBoletim),
                                                                     new XAttribute("PortoemissaoConteinerItemIDFA", itemConteinerItemIDFA.Portoemissao),
                                                                     new XAttribute("EmitenteConteinerItemIDFA", itemConteinerItemIDFA.Emitente),
                                                                     new XAttribute("DataEmissaoConteinerItemIDFA", itemConteinerItemIDFA.DataEmissao),
                                                                     new XAttribute("PortoDestinoFinalConteinerItemIDFA", itemConteinerItemIDFA.PortoDestinoFinal),
                                                                     new XAttribute("IdConteinerConteinerItemIDFA", itemConteinerItemIDFA.IdConteiner),
                                                                     new XAttribute("FaltaOuAcrescimoConteinerItemIDFA", itemConteinerItemIDFA.FaltaOuAcrescimo),                                                                     
                                                                     new XAttribute("SequencialConteinerItemIDFA", itemConteinerItemIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "210":
                                {
                                    foreach (var itemCargaGeralIDFA in listaCargaGeralIDFA.Where(x => x.Sequencial == item.StringData.Substring(159, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "CargaGeralIDFA",
                                                                     new XAttribute("IdentificadorCargaGeralIDFA", itemCargaGeralIDFA.Identificador),
                                                                     new XAttribute("CnpjCargaGeralIDFA", itemCargaGeralIDFA.CNPJBase + itemCargaGeralIDFA.CNPJFilial + itemCargaGeralIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemCargaGeralIDFA", itemCargaGeralIDFA.NumeroViagem),
                                                                     new XAttribute("QtdeDescarregadaCargaGeralIDFA", itemCargaGeralIDFA.QtdeDescarregada),
                                                                     new XAttribute("PesoDescarregadoCargaGeralIDFA", itemCargaGeralIDFA.PesoDescarregado),
                                                                     new XAttribute("QtdeManifestadaCargaGeralIDFA", itemCargaGeralIDFA.QtdeManifestada),
                                                                     new XAttribute("PesoManifestadoCargaGeralIDFA", itemCargaGeralIDFA.PesoManifestado),
                                                                     new XAttribute("QtdeDescarregadoComManifestoCargaGeralIDFA", itemCargaGeralIDFA.QtdeDescarregadoComManifesto),
                                                                     new XAttribute("PesoDescarregadoComManifestoCargaGeralIDFA", itemCargaGeralIDFA.PesoDescarregadoComManifesto),
                                                                     new XAttribute("QtdeEmbarcadaCargaGeralIDFA", itemCargaGeralIDFA.QtdeEmbarcada),
                                                                     new XAttribute("PesoEmbarcadoCargaGeralIDFA", itemCargaGeralIDFA.PesoEmbarcado),
                                                                     new XAttribute("QtdeTotalEmbarcadoCargaGeralIDFA", itemCargaGeralIDFA.QtdeTotalEmbarcado),
                                                                     new XAttribute("PesoTotalEmbarcadoCargaGeralIDFA", itemCargaGeralIDFA.PesoTotalEmbarcado),                                                          
                                                                     new XAttribute("SequencialCargaGeralIDFA", itemCargaGeralIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "211":
                                {
                                    foreach (var itemCargaGeralIDFA in listaItemCargaGeralIDFA.Where(x => x.Sequencial == item.StringData.Substring(105, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "CargaGeralIDFA",
                                                                     new XAttribute("IdentificadorItemCargaGeralIDFA", itemCargaGeralIDFA.Identificador),
                                                                     new XAttribute("CnpjItemCargaGeralIDFA", itemCargaGeralIDFA.CNPJBase + itemCargaGeralIDFA.CNPJFilial + itemCargaGeralIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemItemCargaGeralIDFA", itemCargaGeralIDFA.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimItemCargaGeralIDFA", itemCargaGeralIDFA.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoItemCargaGeralIDFA", itemCargaGeralIDFA.PortoEmissao),
                                                                     new XAttribute("EmitenteItemCargaGeralIDFA", itemCargaGeralIDFA.Emitente),                                                                 
                                                                     new XAttribute("DataEmissaoItemCargaGeralIDFA", itemCargaGeralIDFA.DataEmissao),
                                                                     new XAttribute("PortodeDestinoFinalItemCargaGeralIDFA", itemCargaGeralIDFA.PortodeDestinoFinal),
                                                                     new XAttribute("MercadoriaItemCargaGeralIDFA", itemCargaGeralIDFA.Mercadoria),
                                                                     new XAttribute("PesoEmbarcadoItemCargaGeralIDFA", itemCargaGeralIDFA.Quantidade),
                                                                     new XAttribute("QtdeTotalEmbarcadoItemCargaGeralIDFA", itemCargaGeralIDFA.Peso),
                                                                     new XAttribute("FaltaouAcrescimoItemCargaGeralIDFA", itemCargaGeralIDFA.FaltaouAcrescimo),
                                                                     new XAttribute("SequencialItemCargaGeralIDFA", itemCargaGeralIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "212":
                                {
                                    foreach (var itemGranelBoletimIDFA in listaGranelBoletimIDFA.Where(x => x.Sequencial == item.StringData.Substring(87, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "GranelBoletimIDFA",
                                                                     new XAttribute("IdentificadorGranelBoletimIDFA", itemGranelBoletimIDFA.Identificador),
                                                                     new XAttribute("CnpjItemGranelBoletimIDFA", itemGranelBoletimIDFA.CNPJBase + itemGranelBoletimIDFA.CNPJFilial + itemGranelBoletimIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemGranelBoletimIDFA", itemGranelBoletimIDFA.NumeroViagem),
                                                                     new XAttribute("PesoDescarregadoGranelBoletimIDFA", itemGranelBoletimIDFA.PesoDescarregado),
                                                                     new XAttribute("PesoManifestadoGranelBoletimIDFA", itemGranelBoletimIDFA.PesoManifestado),
                                                                     new XAttribute("PesoDescarregadoComManifestoGranelBoletimIDFA", itemGranelBoletimIDFA.PesoDescarregadoComManifesto),
                                                                     new XAttribute("PesoDescarregadoComPCIGranelBoletimIDFA", itemGranelBoletimIDFA.PesoDescarregadoComPCI),
                                                                     new XAttribute("PesoEmbarcadoGranelBoletimIDFA", itemGranelBoletimIDFA.PesoEmbarcado),                                                                     
                                                                     new XAttribute("SequencialItemGranelBoletimIDFA", itemGranelBoletimIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "213":
                                {
                                    foreach (var itemGranelItemBoletimIDFA in listaGranelItemBoletimIDFA.Where(x => x.Sequencial == item.StringData.Substring(105, 6)))
                                    {
                                        xEle.Add(
                                                   new XElement(
                                                                    "GranelItemBoletimIDFA",
                                                                     new XAttribute("IdentificadorItemCargaGeralIDFA", itemGranelItemBoletimIDFA.Identificador),
                                                                     new XAttribute("CnpjItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.CNPJBase + itemGranelItemBoletimIDFA.CNPJFilial + itemGranelItemBoletimIDFA.CNPJControle),
                                                                     new XAttribute("NumeroViagemItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.NumeroViagem),
                                                                     new XAttribute("NumeroBoletimItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.NumeroBoletim),
                                                                     new XAttribute("PortoEmissaoItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.PortoEmissao),
                                                                     new XAttribute("EmitenteItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.Emitente),
                                                                     new XAttribute("DataEmissaoItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.DataEmissao),
                                                                     new XAttribute("PortoDestinoFinalItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.PortoDestinoFinal),
                                                                     new XAttribute("MercadoriaItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.Mercadoria),
                                                                     new XAttribute("QtdeTotalEmbarcadoItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.Peso),
                                                                     new XAttribute("FaltaouAcrescimoItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.FaltaOuAcrescimo),
                                                                     new XAttribute("SequencialItemGranelItemBoletimIDFA", itemGranelItemBoletimIDFA.Sequencial)
                                                               )
                                               );
                                    }
                                    break;
                                }

                            case "299":
                                {

                                    xEle.Add(
                                               new XElement(
                                                                "TraillerBoletim",
                                                                 new XAttribute("IdentificadorTraillerBoletim", objTraillerBoletim.Identificador),
                                                                 new XAttribute("QuantidadeRegistro202TraillerBoletim", objTraillerBoletim.QuantidadeRegistro202),
                                                                 new XAttribute("QuantidadeRegistro203TraillerBoletim", objTraillerBoletim.QuantidadeRegistro203),
                                                                 new XAttribute("QuantidadeRegistro204TraillerBoletim", objTraillerBoletim.QuantidadeRegistro203),
                                                                 new XAttribute("QuantidadeRegistro205TraillerBoletim", objTraillerBoletim.QuantidadeRegistro205),
                                                                 new XAttribute("QuantidadeRegistro206TraillerBoletim", objTraillerBoletim.QuantidadeRegistro206),
                                                                 new XAttribute("QuantidadeRegistro207TraillerBoletim", objTraillerBoletim.QuantidadeRegistro207),
                                                                 new XAttribute("QuantidadeRegistro208TraillerBoletim", objTraillerBoletim.QuantidadeRegistro208),
                                                                 new XAttribute("QuantidadeRegistro209TraillerBoletim", objTraillerBoletim.QuantidadeRegistro209),
                                                                 new XAttribute("QuantidadeRegistro210TraillerBoletim", objTraillerBoletim.QuantidadeRegistro210),
                                                                 new XAttribute("QuantidadeRegistro211TraillerBoletim", objTraillerBoletim.QuantidadeRegistro211),
                                                                 new XAttribute("QuantidadeRegistro212TraillerBoletim", objTraillerBoletim.QuantidadeRegistro212),
                                                                 new XAttribute("QuantidadeRegistro213TraillerBoletim", objTraillerBoletim.QuantidadeRegistro213),
                                                                 new XAttribute("QuantidadeTotalRegistroTraillerBoletim",objTraillerBoletim.QuantidadeTotalRegistro),
                                                                 new XAttribute("SequencialTraillerBoletim", objTraillerBoletim.Sequencial)
                                                           )

                                           );
                                    break;
                                }
                        }

                    }

                    var xManifesto = nomearquivo.Substring(0,6)== "ARQBOL" ? new XElement("Boletim", xEle): new XElement("Manifesto", xEle);

                    #region inserir tabela integracao      
                    Utils integraManifesto = new Utils();
                    if (nomearquivo.Contains("ARQBOL"))
                        integraManifesto.InsereIntegracaoXML("Boletim", xManifesto.ToString(), nomearquivo);
                    else
                        integraManifesto.InsereIntegracaoXML("Manifesto", xManifesto.ToString(), nomearquivo);
                    #endregion


                    #endregion
                }
                return listaLog;
            }
            catch (Exception e)
            {

                throw;
            }
        }


        #endregion

        #region Validate arquivos texto Boletim
        public HeaderBoletim ValidateBoletimHeader(Data linha)
        {
            HeaderBoletim obj = new HeaderBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NomeOperador = linha.StringData.Substring(17, 60).Trim();
                obj.NumeroViagem = linha.StringData.Substring(77, 10).Trim();
                //obj.NumeroViagemAgencia = linha.StringData.Substring(87, 10).Trim();
                obj.NumeroViagemAgencia = linha.StringData.Substring(87, 8).Trim(); //alterado por conta propria VALIDAR
                obj.DataGravacaoArquivo = linha.StringData.Substring(95, 8).Trim();
                obj.HoraArquivo = linha.StringData.Substring(103, 6).Trim();

                if (linha.StringData.Substring(109, 8) != "")//campos não obrigatorios
                {
                    obj.CNPJBaseDestinatario = linha.StringData.Substring(109, 8).Trim();
                    obj.CNPJFilialDestinatario = linha.StringData.Substring(117, 4).Trim();
                    obj.CNPJControleDestinatario = linha.StringData.Substring(121, 2).Trim();
                    obj.NomeDestinatario = linha.StringData.Substring(123, 60).Trim();
                }

                obj.NomeNavio = linha.StringData.Substring(183, 30).Trim();
                obj.LloydRegister = linha.StringData.Substring(213, 8).Trim();
                obj.TipoArquivo = linha.StringData.Substring(221, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(222, 6).Trim();
            }
            catch
            {
                obj = new HeaderBoletim();
            }
            return obj;
        }

        public TransferenciaBoletim ValidateCargaeDescargaBoletim(Data linha) //Boletim Carga e Descarga 203
        {
            TransferenciaBoletim obj = new TransferenciaBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 5).Trim();
                obj.LocalOperacao = linha.StringData.Substring(32, 5).Trim();
                obj.AoLargo = linha.StringData.Substring(37, 1).Trim();
                obj.TipoNavegacao = linha.StringData.Substring(38, 15).Trim();
                obj.DataInicial = linha.StringData.Substring(53, 8).Trim();
                obj.DataFinal = linha.StringData.Substring(61, 8).Trim();
                obj.PeriodoTrabalho = linha.StringData.Substring(69, 2).Trim();
                obj.Terno = linha.StringData.Substring(71, 2).Trim();
                obj.Porao = linha.StringData.Substring(73, 10).Trim();
                obj.PrimeiraLingada = linha.StringData.Substring(83, 6).Trim();
                obj.UltimaLingada = linha.StringData.Substring(89, 6).Trim();
                obj.TerminoOperacao = linha.StringData.Substring(95, 1).Trim();
                obj.TipoOperacao = linha.StringData.Substring(96, 15).Trim();
                obj.CodEquipamentoUtilizado = linha.StringData.Substring(111, 8).Trim();
                obj.CodAparelhodeTerra1 = linha.StringData.Substring(119, 8).Trim();
                obj.CodAparelhodeTerra2 = linha.StringData.Substring(127, 8).Trim();
                obj.CodAparelhodeTerra3 = linha.StringData.Substring(135, 8).Trim();
                obj.CodAparelhodeTerra4 = linha.StringData.Substring(143, 8).Trim();
                obj.MatriculaReferencia1 = linha.StringData.Substring(151,9).Trim();
                obj.MatriculaReferencia2 = linha.StringData.Substring(160, 9).Trim();
                obj.Sequencial = linha.StringData.Substring(169, 6).Trim();
            }
            catch
            {
                obj = new TransferenciaBoletim();
            }


            return obj;
        }

        public CargaSoltaBoletim ValidateCargaSoltaBoletim(Data linha) 
        {
            CargaSoltaBoletim obj = new CargaSoltaBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 5).Trim();
                obj.Item = linha.StringData.Substring(32, 3).Trim();
                obj.CodigoMercadoria = linha.StringData.Substring(35, 8).Trim();
                obj.QuantidadeVolumes = linha.StringData.Substring(43, 6).Trim();
                obj.PesoBruto = linha.StringData.Substring(49, 12).Trim();
                obj.CodigoEmbalagem = linha.StringData.Substring(61, 3).Trim();
                obj.Avaria = linha.StringData.Substring(64, 3).Trim();
                obj.TipoOperacao = linha.StringData.Substring(67, 20).Trim();
                obj.CNPJExportador = linha.StringData.Substring(87, 14).Trim();
                obj.OrigemOuDestino = linha.StringData.Substring(101, 6).Trim();
                obj.Marca = linha.StringData.Substring(106, 60).Trim();
                obj.ContraMarca = linha.StringData.Substring(166, 60).Trim();
                obj.NumeroIdentificacao             = linha.StringData.Substring(226, 50).Trim();
                obj.CodTerminoDestinoOuOrigem       = linha.StringData.Substring(276, 7).Trim();
                obj.HoraOperacao = linha.StringData.Substring(283, 6).Trim();
                obj.CodPagamentoOgmo = linha.StringData.Substring(289, 5).Trim();
                obj.Acordo = linha.StringData.Substring(294, 5).Trim();
                obj.Estivador = linha.StringData.Substring(299, 1).Trim();
                obj.Conferente = linha.StringData.Substring(300, 1).Trim();
                obj.Consertador = linha.StringData.Substring(301, 1).Trim();
                obj.Sintraport = linha.StringData.Substring(302, 1).Trim();
                obj.Sindaport = linha.StringData.Substring(303, 1).Trim();
                obj.SindoGeespe = linha.StringData.Substring(304, 1).Trim();
                obj.Rodoviarios = linha.StringData.Substring(305, 1).Trim();
                obj.PortoOrigem = linha.StringData.Substring(306, 5).Trim();
                obj.PortoDestino = linha.StringData.Substring(311, 5).Trim();
                obj.Sequencial = linha.StringData.Substring(316, 6).Trim();
            }
            catch
            {
                obj = new CargaSoltaBoletim();
            }


            return obj;
        }

        public ConteinerBoletim ValidateConteinerBoletim(Data linha)
        {
            ConteinerBoletim obj = new ConteinerBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 5).Trim();
                obj.Sigla = linha.StringData.Substring(32, 11).Trim();
                obj.Tamanho = linha.StringData.Substring(43, 2).Trim();
                obj.TipoBasico = linha.StringData.Substring(45, 2).Trim();
                obj.Avaria = linha.StringData.Substring(47, 3).Trim();
                obj.LacreOrigem1 = linha.StringData.Substring(50, 15).Trim();
                obj.LacreOrigem2 = linha.StringData.Substring(65, 15).Trim();
                obj.LacreOrigem3 = linha.StringData.Substring(80, 15).Trim();
                obj.LacreOrigem4 = linha.StringData.Substring(95, 15).Trim();
                obj.PesoBruto = linha.StringData.Substring(110, 12).Trim();
                obj.TipoOperacao = linha.StringData.Substring(122, 20).Trim();
                obj.Situacao = linha.StringData.Substring(142, 5).Trim();
                obj.DestinoOuOrigem = linha.StringData.Substring(147, 7).Trim();
                obj.HoraOperacao = linha.StringData.Substring(154, 6).Trim();
                obj.CodPagamentoOgmo = linha.StringData.Substring(160, 5).Trim();
                obj.Isocode = linha.StringData.Substring(165, 4).Trim();
                obj.Acordo = linha.StringData.Substring(169, 1).Trim();
                obj.Estivador = linha.StringData.Substring(170, 1).Trim();
                obj.Conferente = linha.StringData.Substring(171, 1).Trim();
                obj.Consertador = linha.StringData.Substring(172, 1).Trim();
                obj.Sintraport = linha.StringData.Substring(173, 1).Trim();
                obj.Sindaport = linha.StringData.Substring(174, 1).Trim();
                obj.SindoGeespe = linha.StringData.Substring(175, 1).Trim();
                obj.Rodoviarios = linha.StringData.Substring(176, 1).Trim();
                obj.PortoOrigem = linha.StringData.Substring(177, 5).Trim();
                obj.PortoDestino = linha.StringData.Substring(182, 5).Trim();
                obj.Tara = linha.StringData.Substring(187, 12).Trim();
                obj.Sequencial = linha.StringData.Substring(199, 6).Trim();
            }
            catch
            {
                obj = new ConteinerBoletim();
            }


            return obj;
        }

        public GranelBoletim ValidateGranelBoletim(Data linha)
        {
            GranelBoletim obj = new GranelBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 5).Trim();
                obj.Item = linha.StringData.Substring(32, 3).Trim();
                obj.CodigoMercadoria = linha.StringData.Substring(35, 8).Trim();
                obj.PesoBruto = linha.StringData.Substring(43, 12).Trim();
                obj.TipoOperacao = linha.StringData.Substring(55, 20).Trim();
                obj.DestinoOuOrigem = linha.StringData.Substring(75, 7).Trim();
                obj.CodPagamentoOgmo = linha.StringData.Substring(82, 5).Trim();
                obj.Acordo = linha.StringData.Substring(87, 5).Trim();
                obj.Estivador = linha.StringData.Substring(92, 1).Trim();
                obj.Conferente = linha.StringData.Substring(93, 1).Trim();
                obj.Consertador = linha.StringData.Substring(94, 1).Trim();
                obj.Sintraport = linha.StringData.Substring(95, 1).Trim();
                obj.Sindaport = linha.StringData.Substring(96, 1).Trim();
                obj.SindoGeespe = linha.StringData.Substring(97, 1).Trim();
                obj.Rodoviarios = linha.StringData.Substring(98, 1).Trim();
                obj.PortoOrigem = linha.StringData.Substring(99, 5).Trim();
                obj.PortoDestino = linha.StringData.Substring(104, 5).Trim();
                obj.Sequencial = linha.StringData.Substring(109, 6).Trim();
            }
            catch
            {
                obj = new GranelBoletim();
            }


            return obj;
        }

        public Paralisacoes ValidateParalisacoesBoletim(Data linha)
        {
            Paralisacoes obj = new Paralisacoes();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 5).Trim();
                obj.CodParalisacao = linha.StringData.Substring(32, 3).Trim();
                obj.HoraInicio = linha.StringData.Substring(35, 6).Trim();
                obj.HoraFim = linha.StringData.Substring(41, 6).Trim();
                obj.Observacao = linha.StringData.Substring(47, 60).Trim();
                obj.Estivador = linha.StringData.Substring(107, 1).Trim();
                obj.Conferente = linha.StringData.Substring(108, 1).Trim();
                obj.Consertador = linha.StringData.Substring(109, 1).Trim();
                obj.Sintraport = linha.StringData.Substring(110, 1).Trim();
                obj.Sindaport = linha.StringData.Substring(111, 1).Trim();
                obj.SindoGeespe = linha.StringData.Substring(112, 1).Trim();
                obj.Rodoviarios = linha.StringData.Substring(113, 1).Trim();
                obj.ParalisacaoOgmo = linha.StringData.Substring(114, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(115, 6).Trim();
            }
            catch
            {
                obj = new Paralisacoes();
            }


            return obj;
        }

        public ConteinerBoletimIDFA ValidateConteinerBoletimIDFA(Data linha)
        {
            ConteinerBoletimIDFA obj = new ConteinerBoletimIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.QteConteinerCheioDescarregado = linha.StringData.Substring(27, 5).Trim();
                obj.QteConteinerCheioManifesto = linha.StringData.Substring(32, 5).Trim();
                obj.QteConteinerCheioComManifestoDescarregado = linha.StringData.Substring(37, 5).Trim();
                obj.QteConteinervazioDescarregado = linha.StringData.Substring(42, 5).Trim();
                obj.QteConteinerCheioEmbarcado = linha.StringData.Substring(47, 5).Trim();
                obj.QteConteinerCheioBalEmbarcado = linha.StringData.Substring(52, 6).Trim();
                obj.QteConteinerCheiocPCIDescarregado = linha.StringData.Substring(58, 6).Trim();
                obj.QteConteinerVazioEmbarcado = linha.StringData.Substring(64, 6).Trim();
                obj.Sequencial = linha.StringData.Substring(70, 6).Trim();
            }
            catch
            {
                obj = new ConteinerBoletimIDFA();
            }


            return obj;
        }

        public ConteinerItemIDFA ValidateItemConteinerBoletimIDFA(Data linha)
        {
            ConteinerItemIDFA obj = new ConteinerItemIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.Portoemissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.PortoDestinoFinal = linha.StringData.Substring(74, 5).Trim();
                obj.IdConteiner = linha.StringData.Substring(79, 11).Trim();
                obj.FaltaOuAcrescimo = linha.StringData.Substring(90, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(91, 6).Trim();
            }
            catch
            {
                obj = new ConteinerItemIDFA();
            }


            return obj;
        }

        public CargaGeralIDFA ValidateCargaGeralIDFABoletim(Data linha)
        {
            CargaGeralIDFA obj = new CargaGeralIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.QtdeDescarregada = linha.StringData.Substring(27, 10).Trim();
                obj.PesoDescarregado = linha.StringData.Substring(37, 12).Trim();
                obj.QtdeManifestada = linha.StringData.Substring(49, 10).Trim();
                obj.PesoManifestado = linha.StringData.Substring(59, 12).Trim();
                obj.QtdeDescarregadoComManifesto = linha.StringData.Substring(71, 10).Trim();
                obj.PesoDescarregadoComManifesto = linha.StringData.Substring(81, 12).Trim();
                obj.QtdeDescarregadoComPCI = linha.StringData.Substring(93, 10).Trim();
                obj.PesoDescarregadoComPCI = linha.StringData.Substring(103, 12).Trim();
                obj.QtdeEmbarcada = linha.StringData.Substring(115, 10).Trim();
                obj.PesoEmbarcado = linha.StringData.Substring(125, 12).Trim();
                obj.QtdeTotalEmbarcado = linha.StringData.Substring(137, 10).Trim();
                obj.PesoTotalEmbarcado = linha.StringData.Substring(147, 12).Trim();
                obj.Sequencial = linha.StringData.Substring(159, 6).Trim();
            }
            catch
            {
                obj = new CargaGeralIDFA();
            }


            return obj;
        }

        public ItemCargaGeralIDFA ValidateItemCargaGeralIDFABoletim(Data linha)
        {
            ItemCargaGeralIDFA obj = new ItemCargaGeralIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.PortodeDestinoFinal = linha.StringData.Substring(74, 5).Trim();
                obj.Mercadoria = linha.StringData.Substring(79, 8).Trim();
                obj.Quantidade = linha.StringData.Substring(87, 5).Trim();
                obj.Peso = linha.StringData.Substring(92, 12).Trim();
                obj.FaltaouAcrescimo = linha.StringData.Substring(104, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(105, 6).Trim();
            }
            catch
            {
                obj = new ItemCargaGeralIDFA();
            }


            return obj;
        }

        public GranelBoletimIDFA ValidateGranelBoletimIDFA(Data linha)
        {
            GranelBoletimIDFA obj = new GranelBoletimIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.PesoDescarregado = linha.StringData.Substring(27, 12).Trim();
                obj.PesoManifestado = linha.StringData.Substring(39, 12).Trim();
                obj.PesoDescarregadoComManifesto = linha.StringData.Substring(51, 12).Trim();
                obj.PesoDescarregadoComPCI = linha.StringData.Substring(63, 12).Trim();
                obj.PesoEmbarcado = linha.StringData.Substring(75, 12).Trim();
                obj.Sequencial = linha.StringData.Substring(87, 6).Trim();
            }
            catch
            {
                obj = new GranelBoletimIDFA();
            }


            return obj;
        }

        public GranelItemBoletimIDFA ValidateGranelItemBoletimIDFA(Data linha)
        {
            GranelItemBoletimIDFA obj = new GranelItemBoletimIDFA();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.CNPJBase = linha.StringData.Substring(3, 8).Trim();
                obj.CNPJFilial = linha.StringData.Substring(11, 4).Trim();
                obj.CNPJControle = linha.StringData.Substring(15, 2).Trim();
                obj.NumeroViagem = linha.StringData.Substring(17, 10).Trim();
                obj.NumeroBoletim = linha.StringData.Substring(27, 30).Trim();
                obj.PortoEmissao = linha.StringData.Substring(57, 5).Trim();
                obj.Emitente = linha.StringData.Substring(62, 4).Trim();
                obj.DataEmissao = linha.StringData.Substring(66, 8).Trim();
                obj.PortoDestinoFinal = linha.StringData.Substring(74, 5).Trim();
                obj.Mercadoria = linha.StringData.Substring(79, 8).Trim();
                obj.Peso = linha.StringData.Substring(87, 12).Trim();
                obj.FaltaOuAcrescimo = linha.StringData.Substring(99, 1).Trim();
                obj.Sequencial = linha.StringData.Substring(100, 6).Trim();
            }
            catch
            {
                obj = new GranelItemBoletimIDFA();
            }


            return obj;
        }

        public TraillerBoletim ValidateTraillerBoletim(Data linha, string sequencial)
        {
            TraillerBoletim obj = new TraillerBoletim();
            try
            {
                obj.Identificador = linha.StringData.Substring(0, 3).Trim();
                obj.QuantidadeRegistro202 = linha.StringData.Substring(3, 6).Trim();
                obj.QuantidadeRegistro203 = linha.StringData.Substring(9, 6).Trim();
                obj.QuantidadeRegistro204 = linha.StringData.Substring(15, 6).Trim();
                obj.QuantidadeRegistro205 = linha.StringData.Substring(21, 6).Trim();
                obj.QuantidadeRegistro206 = linha.StringData.Substring(27, 6).Trim();
                obj.QuantidadeRegistro207 = linha.StringData.Substring(33, 6).Trim();
                obj.QuantidadeRegistro208 = linha.StringData.Substring(39, 6).Trim();
                obj.QuantidadeRegistro209 = linha.StringData.Substring(45, 6).Trim();
                obj.QuantidadeRegistro210 = linha.StringData.Substring(51, 6).Trim();
                obj.QuantidadeRegistro211 = linha.StringData.Substring(57, 6).Trim();
                obj.QuantidadeRegistro212 = linha.StringData.Substring(63, 6).Trim();
                obj.QuantidadeRegistro213 = linha.StringData.Substring(69, 6).Trim();
                obj.QuantidadeTotalRegistro = linha.StringData.Substring(75, 6).Trim();
                obj.Sequencial = sequencial.Substring(7, 5).Replace(".txt", "");

            }
            catch
            {
                obj = new TraillerBoletim();
            }


            return obj;
        }
        #endregion



        #region LogMessage

        public void InsereLog(int linha,string nomeEntidade,string nomearquivo,string message, string messageSystem)
        {
            string str = "";
            SqlCommand objCmd;
            str = @"INSERT INTO [dbo].[LogMessage]
                   ([Linha]
                   ,[NomeEntidade]
                   ,[Data]
                   ,[Message]
                   ,[MessageSystem]
                   ,NomeArquivo)
                    VALUES
                   (@Linha
                   ,@NomeEntidade
                   ,@Data
                   ,@Message
                   ,@MessageSystem
                   ,@NomeArquivo)  ";
            SqlConnection conn = ConexaoDb();
            conn.Open();


            //LogMessage obj = new LogMessage();
            //obj.Linha = linha;
            //obj.NomeEntidade = nomeEntidade;
            //obj.Data = DateTime.Now;
            //obj.Message = message;
            //obj.MessageSystem = messageSystem;
            //obj.NomeArquivo = nomearquivo;
            //db.LogMensagens.Add(obj);

            //db.SaveChanges();

            try
            {
                objCmd = new SqlCommand(str, conn);
                objCmd.Parameters.AddWithValue("@Linha", linha);
                objCmd.Parameters.AddWithValue("@NomeEntidade", nomeEntidade);
                objCmd.Parameters.AddWithValue("@Data", DateTime.Now);
                objCmd.Parameters.AddWithValue("@Message", message);
                objCmd.Parameters.AddWithValue("@MessageSystem", messageSystem);
                objCmd.Parameters.AddWithValue("@NomeArquivo", nomearquivo);
                objCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        public void InsereIntegracaoXML(string nomeEntidade, string xml, string nomeArquivo)
        {


            int vxml = xml.Length;
            int ventidade = nomeEntidade.Length;
            int vnomeArquivo = nomeArquivo.Length;
           

            string str = "";
            SqlCommand objCmd;
            str = @"INSERT INTO [dbo].[Integration]
                   (
                    [Entidade]
                   ,[DtEntrada]
                   ,[XMLRecebido]
                   ,[Situacao]
                   ,[NomeArquivo])
                    VALUES
                   (
                    @Entidade
                   ,@DtEntrada
                   ,@XMLRecebido
                   ,@Situacao
                   ,@NomeArquivo)  ";
            SqlConnection conn = ConexaoDb();
            conn.Open();
            try
            {
                objCmd = new SqlCommand(str, conn);
                
                objCmd.Parameters.AddWithValue("@Entidade", nomeEntidade);
                objCmd.Parameters.AddWithValue("@DtEntrada", DateTime.Now);
                objCmd.Parameters.AddWithValue("@XMLRecebido", xml);
                objCmd.Parameters.AddWithValue("@Situacao", "Aguardando");
                objCmd.Parameters.AddWithValue("@NomeArquivo",nomeArquivo);
                objCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            
        }
        public string VarrerDiretorio(string caminhoIndividual)
        {
            //string tokenTransaction = MD5Hash.CalculaHash(DateTime.Now.ToString("yyyyMMddhmmtt"));

            string CaminhoBusca     = db.Parametros.Where(x => x.Nome == "BuscaArquivos").Select(x => x.Valor).FirstOrDefault(); //ConfigurationManager.AppSettings["BuscaArquivos"];
            string CaminhoValido    = db.Parametros.Where(x => x.Nome == "ArquivosValidos").Select(x => x.Valor).FirstOrDefault(); 
            string CaminhoErro      = db.Parametros.Where(x => x.Nome == "ArquivosInvalidos").Select(x => x.Valor).FirstOrDefault(); 
            string modeloXsd        = db.Parametros.Where(x => x.Nome == "Modelosxsd").Select(x => x.Valor).FirstOrDefault();  //ConfigurationManager.AppSettings["Modelosxsd"];

            List<LogMessage> lista = new List<LogMessage>();
            int qtdeArquivosvalidosXml = 0, qtdeArquivosvalidostxt = 0;
            int qtdeArquivosinvalidosXml = 0, qtdeArquivosinvalidostxt = 0;
            IEnumerable<FileInfo> arquivos;
            #region pre requisito saber os locais dos arquivos a buscar
            // string pastaOrigem = @"C:\Projetos\Docas\Fichas XML\Xml_Entrada";
            // string pastaDestino = @"C:\Projetos\Docas\Fichas XML\Xml_Validado";
            // string pastaDestinoForaPadrao = @"C:\Projetos\Docas\Fichas XML\Xml_ForaPadrao";
            //string modeloXsd = @"C:\Projetos\Docas\Modelos XSD\";
            #endregion

            if (!Directory.Exists(CaminhoValido))
                Directory.CreateDirectory(CaminhoValido);

            if (string.IsNullOrEmpty(caminhoIndividual))
            {
                arquivos = new DirectoryInfo(CaminhoBusca).EnumerateFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".txt" || x.Extension == ".TXT" || x.Extension == ".xml" || x.Extension == ".XML");
            }
            else
            {
                arquivos = new DirectoryInfo(CaminhoBusca).EnumerateFiles("*.*", SearchOption.AllDirectories).Where(x => x.FullName == caminhoIndividual);
            }
         
            foreach (var arquivo in arquivos)
            {
               // ValidacaoXML validadorXML = new ValidacaoXML();
               /// lista = validadorXML.ValidarXml(arquivo.FullName, @"C:\Projetos\Docas\Modelos XSD\DE.xsd");

                if (arquivo.Extension == ".xml"|| arquivo.Extension == ".XML")
                {
                    ValidacaoXML validadorXML = new ValidacaoXML();
                    string[] arrayversaoArquivosTratado = Regex.Split(arquivo.Name, "_");
                    //Arquivo xml
                    // string nomeArquivosTratado = arquivo.Name.Substring(17, arquivo.Name.Length - 17).Substring(0, arquivo.Name.Substring(17, arquivo.Name.Length - 17).IndexOf("_"));
                    string nomeArquivosTratado = arrayversaoArquivosTratado[arrayversaoArquivosTratado.Count() - 2].ToString();
                    string versaoArquivosTratado= arrayversaoArquivosTratado[arrayversaoArquivosTratado.Count()-1].ToString().Replace(".xml","").Replace(".XML", "");

                    string versaoArquivosxsd = nomeArquivosTratado + "_" + versaoArquivosTratado;
                    string modeloArquivoXsd = string.Empty;
                    if (db.ModelosXsd.Where(x => x.NomeArquivo == nomeArquivosTratado && x.Versao ==versaoArquivosTratado).Count() > 0)
                    {
                        modeloArquivoXsd = db.ModelosXsd.Where(x => x.NomeArquivo == nomeArquivosTratado && x.Versao == versaoArquivosTratado).Select(x => x.Modelo).FirstOrDefault();
                        lista = validadorXML.ValidarXml(arquivo.FullName, modeloArquivoXsd);
                    }
                    else
                    {
                        //Tratamento para o caso de não possui modelo no repositorio
                    }
                    

                   // lista = validadorXML.ValidarXml(arquivo.FullName, modeloXsd + nomeArquivosTratado + ".xsd");

                   // lista = validadorXML.ValidarXml(arquivo.FullName, modeloXsd + nomeArquivosTratado + ".xsd");

                    if (lista.Where(x => x.NomeEntidade != "").Count() > 0)
                    {
                        qtdeArquivosinvalidosXml = qtdeArquivosinvalidosXml + 1;

                        #region criando xml 
                        var xEle = new XElement("LogMessage", from emp in lista
                                                              select new XElement("Falhas",
                                                                      new XAttribute("Message", emp.Message),
                                                                      new XAttribute("MessageSystem", emp.MessageSystem),
                                                                      new XAttribute("Data", emp.Data),
                                                                      new XAttribute("NomeEntidade", emp.NomeEntidade)
                            ));

                        #endregion

                        #region Inserindo erro na entidade
                        Utils util = new Utils();

                        foreach (var itemErro in lista)
                        {
                            util.InsereLog(itemErro.Linha, nomeArquivosTratado, arquivo.Name, itemErro.Message, itemErro.MessageSystem);
                        }

                        var nomeArquivo = Path.GetFileName(arquivo.FullName);
                        var caminhoDestino = Path.Combine(CaminhoErro, nomeArquivo);
                        arquivo.MoveTo(caminhoDestino);
                        xEle.Save(CaminhoErro + nomeArquivo + "_ERROR");

                        #endregion
                    }
                    else
                    {
                        //Arquivo validado
                        qtdeArquivosvalidosXml = qtdeArquivosvalidosXml + 1;
                        var nomeArquivo = Path.GetFileName(arquivo.FullName);
                        var caminhoDestino = Path.Combine(CaminhoValido, nomeArquivo);
                        Utils util = new Utils();
                        if (!File.Exists(caminhoDestino))
                        {
                            arquivo.MoveTo(caminhoDestino);
                            string xmlString = File.ReadAllText(caminhoDestino);
                            if (db.Integracoes.Where(x => x.DtProcessamento != null && x.NomeArquivo == arquivo.Name).Count() > 0)
                            {
                                util.InsereLog(0, nomeArquivosTratado, arquivo.Name, "ERR_01: Arquivo processado anteriormente", "Arquivo processado anteriormente, favor verificar!");
                                return "ERR_01: Arquivo processado anteriormente";
                            }
                            else
                            {
                                util.InsereIntegracaoXML(nomeArquivosTratado, xmlString, nomeArquivo);
                            }
                        }
                    }
                }
                if (arquivo.Extension == ".txt" || arquivo.Extension == ".TXT")
                {
                    var nomeArquivo = Path.GetFileName(arquivo.FullName); // texto.txt
                    var caminhoDestino = Path.Combine(CaminhoValido, nomeArquivo);
                    var caminhoBusca = Path.Combine(CaminhoBusca, nomeArquivo);
                    string xmlString = File.ReadAllText(caminhoBusca);
                    Utils util = new Utils();
                    if (db.Integracoes.Where(x => x.NomeArquivo == nomeArquivo && x.DtProcessamento != null).Count() <= 0)
                    {
                        if (nomeArquivo.Contains("ARQBOL"))
                            lista = util.ValidadorManifesto(caminhoBusca, nomeArquivo);
                        else
                            lista = util.ValidadorManifesto(caminhoBusca, nomeArquivo);

                        if (lista.Select(x => x.Message != "").FirstOrDefault())
                        {
                            qtdeArquivosinvalidostxt = qtdeArquivosinvalidostxt + 1;
                            caminhoDestino = Path.Combine(CaminhoErro, nomeArquivo);
                            #region criando xml 
                            var xEle = new XElement("LogMessage", from emp in lista
                                                                  select new XElement("Error",
                                                                          new XAttribute("Message", emp.Message),
                                                                          new XAttribute("MessageSystem", emp.MessageSystem),
                                                                          new XAttribute("Data", emp.Data),
                                                                          new XAttribute("Entidade", emp.NomeEntidade)
                                ));

                            #endregion

                            foreach (var itemErro in lista)
                            {
                                util.InsereLog(itemErro.Linha, itemErro.NomeEntidade, arquivo.Name, itemErro.Message, itemErro.MessageSystem);
                            }
                            if (!File.Exists(caminhoDestino))
                            {
                                arquivo.MoveTo(caminhoDestino);
                                xEle.Save(CaminhoErro + nomeArquivo + "_ERROR");
                            }
                        }
                        else
                        {
                            //Sucesso
                            qtdeArquivosvalidostxt = qtdeArquivosvalidostxt + 1;
                            if (!File.Exists(caminhoDestino))
                                arquivo.MoveTo(caminhoDestino);
                        }
                    }
                    else
                    {
                        //Arquivo já foi importado anteriormente
                        qtdeArquivosinvalidostxt = qtdeArquivosinvalidostxt + 1;
                        util.InsereLog(0, "Sistema", arquivo.Name, "Arquivo repetido", "Arquivo já consta na base para processamento");
                    }

                }
            }

            return string.Format("XML's válidos: " + qtdeArquivosvalidosXml.ToString() + " | inválidos: " + qtdeArquivosinvalidosXml.ToString()
                               + " TXT's válidos: " + qtdeArquivosvalidostxt.ToString() + " | inválidos: " + qtdeArquivosinvalidostxt.ToString()
                                );

        }


    }
}