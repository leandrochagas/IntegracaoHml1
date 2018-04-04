using IntegracaoPsP.Domain.Entities.Xml;
using IntegracaoPsP.Service.Functions;
using IntegracaoPsP.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Services;
using System.Xml;
using System.Xml.Serialization;

namespace IntegracaoPsP.Service
{
    /// <summary>
    /// Summary description for PsP
    /// </summary>
    [WebService(Namespace = "http://linkcon.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class PsP : WebService
    {
        #region Constantes de endereços de busca de arquivos
        //string CaminhoBusca = System.Configuration.ConfigurationManager.AppSettings["BuscaArquivos"];
        //string CaminhoValido = System.Configuration.ConfigurationManager.AppSettings["ArquivosValidos"];
        //string CaminhoErro = System.Configuration.ConfigurationManager.AppSettings["ArquivosInvalidos"];
        //string modeloXsd = System.Configuration.ConfigurationManager.AppSettings["Modelosxsd"]; 
        #endregion

        private ApplicationDbContext db = new ApplicationDbContext();

        [WebMethod(Description = @"Método responsável em verificar se existem arquivos a serem processados")]
        public string BuscarArquivos()
        {
            Utils util = new Utils();
            try
            {
                return util.VarrerDiretorio(null);
            }
            catch (Exception e)
            {
                util.InsereLog(0, "System", "ERROR", "Erro interno", e.ToString());
                return  "NOK";
            }
        }




        [WebMethod(Description = @"Método responsável processar um arquivo de fomra individual")]
        public string BuscarArquivosIndividual(string caminho)
        {
            Utils util = new Utils();
            try
            {
                return util.VarrerDiretorio(caminho);
            }
            catch (Exception e)
            {
                util.InsereLog(0, "System", "ERROR", "Erro interno", e.ToString());
                return "NOK";
            }
        }


        [WebMethod(Description = @"Método responsável fornecer os registros que estão aptos a serem processados pelo terceiro")]
        public List<string> Integrar(string token)
        {
            Utils util = new Utils();
            try
            {
               
                if (token == "linkcon.com/2018")
                {
                    List<Integration> lista = new List<Integration>();
                    lista = db.Integracoes.Where(x => x.Situacao == "Aguardando").ToList();
                    List<string> xmls = db.Integracoes.Where(x => x.Situacao == "Aguardando").Select(x => x.XmlRecebido).ToList();
                    return xmls;
                }
                else
                {
                    List<string> xmlsErro = new List<string>();
                    xmlsErro.Add("NOK");
                    return xmlsErro;
                }

            }
            catch (Exception e )
            {

                List<string> xmlsErro = new List<string>();
                xmlsErro.Add("NOK");
                util.InsereLog(0, "System", "ERROR", "Erro interno", e.ToString());
                return xmlsErro;
            }
            
            
        }



        //public List<LogMessage> ValidadorManifesto(string caminho, string nomearquivo)
        //{

            //    var validationResults = new List<ValidationResult>();
            //    Utils util = new Utils();

            //    List<Data> lista = util.ReadTxt(caminho);
            //    List<LogMessage> listaLog = new List<LogMessage>();

            //    HeaderManifesto objHeader = new HeaderManifesto();
            //    Parceiro objParceiro = new Parceiro();
            //    Conteiner objConteiner = new Conteiner();
            //    PortodeEscala objPortodeEscala = new PortodeEscala();
            //    Boletim objBoletim = new Boletim();
            //    BoletimMaster objBoletimMaster = new BoletimMaster();
            //    Frete objFrete = new Frete();
            //    CargaSolta objCargaSolta = new CargaSolta();
            //    ConteinerCheio objConteinerCheio = new ConteinerCheio();
            //    Granel objGranel = new Granel();
            //    MercadoriaConteinerizada objMercadoriaConteinerizada = new MercadoriaConteinerizada();
            //    BoletimDescricao objBoletimDescricao = new BoletimDescricao();
            //    Trailler objTrailler = new Trailler();
            //    try
            //    {

            //        int linha = 0;

            //        #region Inicializado Listas

            //        List<Parceiro> listaParceiro = new List<Parceiro>();
            //        List<Conteiner> listaConteiner = new List<Conteiner>();
            //        List<ConteinerCheio> listaConteinerCheio = new List<ConteinerCheio>();
            //        List<PortodeEscala> listaPortodeEscala = new List<PortodeEscala>();
            //        List<Boletim> listaBoletim = new List<Boletim>();
            //        List<BoletimMaster> listaBoletimMaster = new List<BoletimMaster>();

            //        List<Frete> listaFrete = new List<Frete>();
            //        List<CargaSolta> listaCargaSolta = new List<CargaSolta>();
            //        List<Granel> listaGranel = new List<Granel>();
            //        List<MercadoriaConteinerizada> listaMercadoriaConteinerizada = new List<MercadoriaConteinerizada>();
            //        List<BoletimDescricao> listaBoletimDescricao = new List<BoletimDescricao>();


            //        #endregion

            //        foreach (var item in lista)
            //        {
            //            linha = linha + 1;
            //            switch (item.StringData.Substring(0, 3))
            //            {
            //                case "101":
            //                    {
            //                        objHeader = util.ValidateHeader(item);
            //                        var contextHeader = new ValidationContext(objHeader, serviceProvider: null, items: null);

            //                        #region Add Erros Header
            //                        if (Validator.TryValidateObject(objHeader, contextHeader, validationResults, true) == false)
            //                        {
            //                            //erro de validação

            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextHeader.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            // db.HeadersManifesto.Add(objHeader);
            //                        }
            //                        #endregion
            //                        break;
            //                    }
            //                case "102":
            //                    {
            //                        objParceiro = util.ValidateParceiros(item);
            //                        var contextParceiro = new ValidationContext(objParceiro, serviceProvider: null, items: null);
            //                        #region Add Erros Parceiros
            //                        if (Validator.TryValidateObject(objParceiro, contextParceiro, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextParceiro.DisplayName,// "Manifesto Header",
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaParceiro.Add(objParceiro);
            //                        }
            //                        #endregion
            //                        break;
            //                    }
            //                case "103":
            //                    {
            //                        objConteiner = util.ValidateConteiner(item);
            //                        var contextConteiner = new ValidationContext(objConteiner, serviceProvider: null, items: null);
            //                        #region Add Erros Conteiner
            //                        if (Validator.TryValidateObject(objConteiner, contextConteiner, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextConteiner.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaConteiner.Add(objConteiner);
            //                        }
            //                        #endregion
            //                        break;
            //                    }
            //                case "104":
            //                    {
            //                        objPortodeEscala = util.ValidatePortodeEscala(item);
            //                        var contextPortodeEscala = new ValidationContext(objPortodeEscala, serviceProvider: null, items: null);
            //                        #region Add Erros Porto Escala
            //                        if (Validator.TryValidateObject(objPortodeEscala, contextPortodeEscala, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextPortodeEscala.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaPortodeEscala.Add(objPortodeEscala);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                /*Caso o Tipo de BL (105) Seja “S”–SERVIÇO OU “H”–H-BL será obrigatório o registro 106.*/

            //                case "105":
            //                    {
            //                        objBoletim = util.ValidateBoletim(item);
            //                        var contextBoletim = new ValidationContext(objBoletim, serviceProvider: null, items: null);
            //                        #region Add Erros Boletim
            //                        if (Validator.TryValidateObject(objBoletim, contextBoletim, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextBoletim.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaBoletim.Add(objBoletim);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                case "106":
            //                    {
            //                        objBoletimMaster = util.ValidateBoletimMaster(item);
            //                        var contextBoletimMaster = new ValidationContext(objBoletimMaster, serviceProvider: null, items: null);
            //                        #region Add Erros BoletimMaster
            //                        if (Validator.TryValidateObject(objBoletimMaster, contextBoletimMaster, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextBoletimMaster.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaBoletimMaster.Add(objBoletimMaster);
            //                        }
            //                        #endregion
            //                        break;
            //                    }
            //                case "107":
            //                    {
            //                        objFrete = util.ValidateFrete(item);
            //                        var contextFrete = new ValidationContext(objFrete, serviceProvider: null, items: null);
            //                        #region Add Erros Frete
            //                        if (Validator.TryValidateObject(objFrete, contextFrete, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextFrete.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaFrete.Add(objFrete);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                /*
            //                 Tendo registro do tipo 105 será obrigatório no arquivo constar registros do tipo 108 OU 109 OU 110 
            //                */
            //                case "108":
            //                    {
            //                        objCargaSolta = util.ValidateCargaSolta(item);
            //                        var contextCargaSolta = new ValidationContext(objCargaSolta, serviceProvider: null, items: null);
            //                        #region Add Erros Carga Solta
            //                        if (Validator.TryValidateObject(objCargaSolta, contextCargaSolta, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextCargaSolta.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }

            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaCargaSolta.Add(objCargaSolta);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                /*
            //                Tendo registro do tipo 105 será obrigatório no arquivo constar registros do tipo 108 OU 109 OU 110 
            //                Caso o Tipo de BL (105) Seja “S”–SERVIÇO OU “H”–H-BL será obrigatório o registro 106.
            //               */

            //                case "109":
            //                    {
            //                        objConteinerCheio = util.ValidateConteinerCheio(item);
            //                        var contextConteinerCheio = new ValidationContext(objConteinerCheio, serviceProvider: null, items: null);
            //                        #region Add Erros Conteiner Cheio
            //                        if (Validator.TryValidateObject(objConteinerCheio, contextConteinerCheio, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextConteinerCheio.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaConteinerCheio.Add(objConteinerCheio);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                case "110":
            //                    {
            //                        objGranel = util.ValidateGranel(item);
            //                        var contextGranel = new ValidationContext(objGranel, serviceProvider: null, items: null);
            //                        #region Add Erros Granel
            //                        if (Validator.TryValidateObject(objGranel, contextGranel, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextGranel.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaGranel.Add(objGranel);
            //                        }
            //                        #endregion
            //                        break;
            //                    }


            //                /*
            //                Tendo registro do tipo 109 será obrigatório no arquivo constar registros do tipo 111 
            //                */
            //                case "111":
            //                    {
            //                        objMercadoriaConteinerizada = util.ValidateMercadoriaConteinerizada(item);
            //                        var contextMercadoriaConteinerizada = new ValidationContext(objMercadoriaConteinerizada, serviceProvider: null, items: null);
            //                        #region Add Erros Mercadoria Conteinerizada
            //                        if (Validator.TryValidateObject(objMercadoriaConteinerizada, contextMercadoriaConteinerizada, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextMercadoriaConteinerizada.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaMercadoriaConteinerizada.Add(objMercadoriaConteinerizada);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                case "112":
            //                    {
            //                        objBoletimDescricao = util.ValidateBoletimDescricao(item);
            //                        var contextBoletimDescricao = new ValidationContext(objBoletimDescricao, serviceProvider: null, items: null);
            //                        #region Add Erros Descrição Boletim
            //                        if (Validator.TryValidateObject(objBoletimDescricao, contextBoletimDescricao, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextBoletimDescricao.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo
            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            listaBoletimDescricao.Add(objBoletimDescricao);
            //                        }
            //                        #endregion
            //                        break;
            //                    }

            //                case "199":
            //                    {
            //                        objTrailler = util.ValidateTrailler(item, nomearquivo);
            //                        var contextTrailler = new ValidationContext(objTrailler, serviceProvider: null, items: null);
            //                        #region Add Erros Descrição Boletim
            //                        if (Validator.TryValidateObject(objTrailler, contextTrailler, validationResults, true) == false)
            //                        {
            //                            //erro de validação
            //                            foreach (var itemLog in validationResults)
            //                            {
            //                                listaLog.Add(new LogMessage
            //                                {
            //                                    Linha = linha,
            //                                    NomeEntidade = contextTrailler.DisplayName,
            //                                    Message = itemLog.ErrorMessage.ToString(),
            //                                    MessageSystem = itemLog.ErrorMessage.ToString(),
            //                                    Data = DateTime.Now,
            //                                    NomeArquivo = nomearquivo

            //                                }
            //                               );
            //                            }
            //                            validationResults.Clear();
            //                        }
            //                        else
            //                        {
            //                            // db.Traillers.Add(objTrailler);
            //                        }
            //                        #endregion

            //                        break;
            //                    }
            //                default:
            //                    break;

            //            }

            //        }


            //        #region validações adicionais
            //        if (objHeader.Sequencial == null || objTrailler.Sequencial == null)
            //        {
            //            listaLog.Add(new LogMessage
            //            {
            //                Linha = linha,
            //                NomeEntidade = "Header|Trailler",
            //                Message = "Erro validação",
            //                MessageSystem = "É obrigatório o arquivo possui um Header(101) e um Trailler(199)",
            //                Data = DateTime.Now,
            //                NomeArquivo = nomearquivo

            //            });

            //        }
            //        else
            //        {

            //            #region validação registro 105
            //            if (int.Parse(objTrailler.QuantidadeRegistro105) > 0)
            //            {
            //                if (!(int.Parse(objTrailler.QuantidadeRegistro108) > 0 || int.Parse(objTrailler.QuantidadeRegistro109) > 0 || int.Parse(objTrailler.QuantidadeRegistro110) > 0))
            //                {
            //                    //errado

            //                    listaLog.Add(new LogMessage
            //                    {
            //                        Linha = linha,
            //                        NomeEntidade = "Boletim",
            //                        Message = "Erro validação",
            //                        MessageSystem = "serão obrigatórios os registros(108 ou 109 ou 110) para registros do tipo 105",
            //                        Data = DateTime.Now,
            //                        NomeArquivo = nomearquivo

            //                    });
            //                }
            //            }
            //            #endregion

            //            #region validação registro do tipo "Serviço"

            //            if (objBoletim.TipoBoletim == "S" || objBoletim.TipoBoletim == "H")
            //            {
            //                if (int.Parse(objTrailler.QuantidadeRegistro106) <= 0)
            //                {

            //                    listaLog.Add(new LogMessage
            //                    {
            //                        Linha = linha,
            //                        NomeEntidade = "BoletimMaster",
            //                        Message = "Erro validação",
            //                        MessageSystem = "Para o tipo de Boletim S ou N é obrigatório o registro do tipo Boletim Master (106)",
            //                        Data = DateTime.Now,
            //                        NomeArquivo = nomearquivo

            //                    });

            //                }

            //            }

            //            #endregion

            //            #region validação registro 109

            //            if (int.Parse(objTrailler.QuantidadeRegistro109) > 0)
            //            {
            //                if (int.Parse(objTrailler.QuantidadeRegistro108) <= 0)
            //                {
            //                    listaLog.Add(new LogMessage
            //                    {
            //                        Linha = linha,
            //                        NomeEntidade = "ConteinerCheio",
            //                        Message = "Erro validação",
            //                        MessageSystem = "Para o tipo de registro 109 é obrigatório o registro de mercadoria conteinerizada(111)",
            //                        Data = DateTime.Now,
            //                        NomeArquivo = nomearquivo

            //                    });
            //                }

            //            }
            //            #endregion
            //        }

            //        #endregion

            //        if (listaLog.Count <= 0)
            //        {
            //            #region criando xml 

            //            List<XElement> xEle = new List<XElement>();

            //            foreach (var item in lista)
            //            {
            //                switch (item.StringData.Substring(0, 3))
            //                {
            //                    case "101":
            //                        {
            //                            xEle.Add(
            //                                      new XElement("Header",
            //                                                    new XAttribute("IdentificadorHeader", objHeader.Identificador),
            //                                                    new XAttribute("CnpjHeader", objHeader.CNPJBase + objHeader.CNPJFilial + objHeader.CNPJControle),
            //                                                    new XAttribute("NomeEmpresaHeader", objHeader.NomeEmpresa),
            //                                                    new XAttribute("NumeroViagemHeader", objHeader.NumeroViagem),
            //                                                    new XAttribute("DataGravacaHeader", objHeader.DataGravacaoArquivo),
            //                                                    new XAttribute("HoraGravacaoHeader", objHeader.HoraArquivo),
            //                                                    new XAttribute("CnpjDestinatarioHeader", objHeader.CNPJBaseDestinatario + objHeader.CNPJFilialDestinatario + objHeader.CNPJControleDestinatario),
            //                                                    new XAttribute("NomeDestinatarioHeader", objHeader.NomeDestinatario),
            //                                                    new XAttribute("LloydRegisterHeader", objHeader.LloydRegister),
            //                                                    new XAttribute("TipoArquivoHeader", objHeader.TipoArquivo),
            //                                                    new XAttribute("SequencialHeader", objHeader.Sequencial)
            //                                                  )
            //                                );
            //                            break;
            //                        }
            //                    case "102":
            //                        {

            //                            foreach (var itemparceiro in listaParceiro.Where(x => x.Sequencial == item.StringData.Substring(101, 6)))
            //                            {
            //                                xEle.Add(
            //                                            new XElement(
            //                                                          "Parceiros",
            //                                                            new XAttribute("IdentificadorParceiros", itemparceiro.Identificador),
            //                                                            new XAttribute("CnpjEmpresaParceiros", itemparceiro.CNPJBase + itemparceiro.CNPJFilial + itemparceiro.CNPJControle),
            //                                                            new XAttribute("NumeroViagemParceiros", itemparceiro.NumeroViagem),
            //                                                            new XAttribute("CnpjParceiros", itemparceiro.CNPJBaseParceiro + itemparceiro.CNPJFilialParceiro + itemparceiro.CNPJControleParceiro),
            //                                                            new XAttribute("NomeParceiros", itemparceiro.NomeParceiro),
            //                                                            new XAttribute("SequencialParceiros", itemparceiro.Sequencial)
            //                                                          )
            //                                        );
            //                            }

            //                            break;
            //                        }
            //                    case "103":
            //                        {
            //                            foreach (var itemconteinervazio in listaConteiner.Where(x => x.Sequencial == item.StringData.Substring(62, 6)))
            //                            {
            //                                xEle.Add(
            //                                             new XElement(
            //                                                              "ConteinerVazio",
            //                                                                 new XAttribute("Identificadorconteinervazio", itemconteinervazio.Identificador),
            //                                                                 new XAttribute("Cnpjconteinervazio", itemconteinervazio.CNPJBase + itemconteinervazio.CNPJFilial + itemconteinervazio.CNPJControle),
            //                                                                 new XAttribute("NumeroViagemconteinervazio", itemconteinervazio.NumeroViagem),
            //                                                                 new XAttribute("Siglaconteinervazio", itemconteinervazio.Sigla),
            //                                                                 new XAttribute("Tamanhoconteinervazio", itemconteinervazio.Tamanho),
            //                                                                 new XAttribute("TipoBasicoconteinervazio", itemconteinervazio.TipoBasico),
            //                                                                 new XAttribute("Isocodeconteinervazio", itemconteinervazio.Isocode),
            //                                                                 new XAttribute("Taraconteinervazio", itemconteinervazio.Tara),
            //                                                                 new XAttribute("Operacaoconteinervazio", itemconteinervazio.Operacao),
            //                                                                 new XAttribute("Sequencialconteinervazio", itemconteinervazio.Sequencial)
            //                                                               )
            //                                       );
            //                            }
            //                            break;
            //                        }
            //                    case "104":
            //                        {
            //                            foreach (var itemPortoEscala in listaPortodeEscala.Where(x => x.Sequencial == item.StringData.Substring(53, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "PortoEscala",
            //                                                             new XAttribute("IdentificadorPortoEscala", itemPortoEscala.Identificador),
            //                                                             new XAttribute("CnpjPortoEscala", itemPortoEscala.CNPJBase + itemPortoEscala.CNPJFilial + itemPortoEscala.CNPJControle),
            //                                                             new XAttribute("CodigoPortoEscalaNumeroViagem", itemPortoEscala.NumeroViagem),
            //                                                             new XAttribute("CodigoPortodeEscalaPortoEscala", itemPortoEscala.CodigoPortodeEscala),
            //                                                             new XAttribute("PrimeiroPortoPortoEscala", itemPortoEscala.PrimeiroPorto),
            //                                                             new XAttribute("DataEntradaPortoEscala", itemPortoEscala.DataEntrada),
            //                                                             new XAttribute("DataSaidaPortoEscala", itemPortoEscala.DataSaida),
            //                                                             new XAttribute("QuantidadePortoEscala", itemPortoEscala.Quantidade),
            //                                                             new XAttribute("SequencialPortoEscala", itemPortoEscala.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "105":
            //                        {
            //                            foreach (var itemBoletim in listaBoletim.Where(x => x.Sequencial == item.StringData.Substring(496, 6)))
            //                            {
            //                                xEle.Add(
            //                                     new XElement(
            //                                                   "Boletim",
            //                                                    new XAttribute("IdentificadorBoletim", itemBoletim.Identificador),
            //                                                    new XAttribute("CnpjBoletim", itemBoletim.CNPJBase + itemBoletim.CNPJFilial + itemBoletim.CNPJControle),
            //                                                    new XAttribute("NumeroViagemBoletim", itemBoletim.NumeroViagem),
            //                                                    new XAttribute("NumeroBoletimBoletim", itemBoletim.NumeroBoletim),
            //                                                    new XAttribute("PortoEmissaoBoletim", itemBoletim.PortoEmissao),
            //                                                    new XAttribute("EmitenteBoletim", itemBoletim.Emitente),
            //                                                    new XAttribute("DataEmissaoBoletim", itemBoletim.DataEmissao),
            //                                                    new XAttribute("TipoBoletimBoletim", itemBoletim.TipoBoletim),
            //                                                    new XAttribute("ObservacaoBoletim", itemBoletim.Observacao),
            //                                                    new XAttribute("ShipperBoletim", itemBoletim.Shipper),
            //                                                    new XAttribute("ConsigneeBoletim", itemBoletim.Consignee),
            //                                                    new XAttribute("NotifyBoletim", itemBoletim.Notify),
            //                                                    new XAttribute("NvoccBoletim", itemBoletim.Nvocc),
            //                                                    new XAttribute("PortodeTransbordoBoletim", itemBoletim.PortodeTransbordo),
            //                                                    new XAttribute("PortodeDestinoFinalBoletim", itemBoletim.PortodeDestinoFinal),
            //                                                    new XAttribute("CEBoletim", itemBoletim.CE),
            //                                                    new XAttribute("TransitoParaBoletim", itemBoletim.TransitoPara),
            //                                                    new XAttribute("CorrenteBoletim", itemBoletim.Corrente),
            //                                                    new XAttribute("CNPJShipperBoletim", itemBoletim.CNPJShipper),
            //                                                    new XAttribute("CNPJConsignerBoletim", itemBoletim.CNPJConsigner),
            //                                                    new XAttribute("CNPJNotifyBoletim", itemBoletim.CNPJNotify),
            //                                                    new XAttribute("CNPJNvoccBoletim", itemBoletim.CNPJNvocc),
            //                                                    new XAttribute("UltimoPortoEscalaBoletim", itemBoletim.UltimoPortoEscala),
            //                                                    new XAttribute("SequencialBoletim", itemBoletim.Sequencial)
            //                                                                )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "106":
            //                        {
            //                            foreach (var itemBoletimMaster in listaBoletimMaster.Where(x => x.Sequencial == item.StringData.Substring(121, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "BoletimMaster",
            //                                                             new XAttribute("IdentificadorPortoEscala", itemBoletimMaster.Identificador),
            //                                                             new XAttribute("CnpjBoletimMaster", itemBoletimMaster.CNPJBase + itemBoletimMaster.CNPJFilial + itemBoletimMaster.CNPJControle),
            //                                                             new XAttribute("NumeroViagemBoletimMaster", itemBoletimMaster.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimBoletimMaster", itemBoletimMaster.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoBoletimMaster", itemBoletimMaster.PortoEmissao),
            //                                                             new XAttribute("EmitenteBoletimMaster", itemBoletimMaster.Emitente),
            //                                                             new XAttribute("DataEmissaoBoletimMaster", itemBoletimMaster.DataEmissaoMaster),
            //                                                             new XAttribute("SequencialBoletimMaster", itemBoletimMaster.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "107":
            //                        {
            //                            foreach (var itemFrete in listaFrete.Where(x => x.Sequencial == item.StringData.Substring(122, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "Frete",
            //                                                             new XAttribute("IdentificadorFrete", itemFrete.Identificador),
            //                                                             new XAttribute("CnpjFrete", itemFrete.CNPJBase + itemFrete.CNPJFilial + itemFrete.CNPJControle),
            //                                                             new XAttribute("NumeroViagemFrete", itemFrete.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimFrete", itemFrete.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoFrete", itemFrete.PortoEmissao),
            //                                                             new XAttribute("EmitenteFrete", itemFrete.Emitente),
            //                                                             new XAttribute("DataEmissaoFrete", itemFrete.DataEmissao),
            //                                                             new XAttribute("DescricaoFreteFrete", itemFrete.DescricaoFrete),
            //                                                             new XAttribute("MoedaFrete", itemFrete.Moeda),
            //                                                             new XAttribute("ValorFrete", itemFrete.Valor),
            //                                                             new XAttribute("PrePagoFrete", itemFrete.PrePago),
            //                                                             new XAttribute("SequencialFrete", itemFrete.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "108":
            //                        {
            //                            foreach (var itemCargaSolta in listaCargaSolta.Where(x => x.Sequencial == item.StringData.Substring(287, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "CargaSolta",
            //                                                             new XAttribute("IdentificadorCargaSolta", itemCargaSolta.Identificador),
            //                                                             new XAttribute("CnpjCargaSolta", itemCargaSolta.CNPJBase + itemCargaSolta.CNPJFilial + itemCargaSolta.CNPJControle),
            //                                                             new XAttribute("NumeroViagemCargaSolta", itemCargaSolta.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimCargaSolta", itemCargaSolta.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoCargaSolta", itemCargaSolta.PortoEmissao),
            //                                                             new XAttribute("ItemCargaSolta", itemCargaSolta.Item),
            //                                                             new XAttribute("CodigoMercadoriaCargaSolta", itemCargaSolta.CodigoMercadoria),
            //                                                             new XAttribute("QuantidadeVolumesCargaSolta", itemCargaSolta.QuantidadeVolumes),
            //                                                             new XAttribute("PesoBrutoCargaSolta", itemCargaSolta.PesoBruto),
            //                                                             new XAttribute("CodigoEmbalagemCargaSolta", itemCargaSolta.CodigoEmbalagem),
            //                                                             new XAttribute("MarcaCargaSolta", itemCargaSolta.Marca),
            //                                                             new XAttribute("ContraMarcaCargaSolta", itemCargaSolta.ContraMarca),
            //                                                             new XAttribute("DestinoCargaSolta", itemCargaSolta.Destino),
            //                                                             new XAttribute("CodigoImoCargaSolta", itemCargaSolta.CodigoImo),
            //                                                             new XAttribute("CodigoOnuCargaSolta", itemCargaSolta.CodigoOnu),
            //                                                             new XAttribute("DDECargaSolta", itemCargaSolta.DDE),
            //                                                             new XAttribute("RECargaSolta", itemCargaSolta.RE),
            //                                                             new XAttribute("SequencialCargaSolta", itemCargaSolta.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "109":
            //                        {
            //                            foreach (var itemConteinerCheio in listaConteinerCheio.Where(x => x.Sequencial == item.StringData.Substring(182, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "ConteinerCheio",
            //                                                             new XAttribute("IdentificadorConteinerCheio", itemConteinerCheio.Identificador),
            //                                                             new XAttribute("CnpjConteinerCheio", itemConteinerCheio.CNPJBase + itemConteinerCheio.CNPJFilial + itemConteinerCheio.CNPJControle),
            //                                                             new XAttribute("NumeroViagemConteinerCheio", itemConteinerCheio.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimConteinerCheio", itemConteinerCheio.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoConteinerCheio", itemConteinerCheio.PortoEmissao),
            //                                                             new XAttribute("EmitenteConteinerCheio", itemConteinerCheio.Emitente),
            //                                                             new XAttribute("DataEmissaoConteinerCheio", itemConteinerCheio.DataEmissao),
            //                                                             new XAttribute("SiglaConteinerConteinerCheio", itemConteinerCheio.SiglaConteiner),
            //                                                             new XAttribute("TamanhoConteinerCheio", itemConteinerCheio.Tamanho),
            //                                                             new XAttribute("TipoBasicoConteinerCheio", itemConteinerCheio.TipoBasico),
            //                                                             new XAttribute("IsocodeConteinerCheio", itemConteinerCheio.Isocode),
            //                                                             new XAttribute("TaraConteinerCheio", itemConteinerCheio.Tara),
            //                                                             new XAttribute("LacreOrigem1ConteinerCheio", itemConteinerCheio.LacreOrigem1),
            //                                                             new XAttribute("LacreOrigem2ConteinerCheio", itemConteinerCheio.LacreOrigem2),
            //                                                             new XAttribute("LacreOrigem3ConteinerCheio", itemConteinerCheio.LacreOrigem3),
            //                                                             new XAttribute("LacreOrigem4ConteinerCheio", itemConteinerCheio.LacreOrigem4),
            //                                                             new XAttribute("PesoBrutoConteinerCheio", itemConteinerCheio.PesoBruto),
            //                                                             new XAttribute("RegimeMovimentacaoConteinerCheio", itemConteinerCheio.RegimeMovimentacao),
            //                                                             new XAttribute("CodigoDestinoouOrigemConteinerCheio", itemConteinerCheio.CodigoDestinoouOrigem),
            //                                                             new XAttribute("SequencialConteinerCheio", itemConteinerCheio.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "110":
            //                        {
            //                            foreach (var itemGranel in listaGranel.Where(x => x.Sequencial == item.StringData.Substring(151, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "Granel",
            //                                                             new XAttribute("IdentificadorGranel", itemGranel.Identificador),
            //                                                             new XAttribute("CnpjGranel", itemGranel.CNPJBase + itemGranel.CNPJFilial + itemGranel.CNPJControle),
            //                                                             new XAttribute("NumeroViagemGranel", itemGranel.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimGranel", itemGranel.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoGranel", itemGranel.PortoEmissao),
            //                                                             new XAttribute("EmitenteGranel", itemGranel.Emitente),
            //                                                             new XAttribute("DataEmissaoGranel", itemGranel.DataEmissao),
            //                                                             new XAttribute("ItemGranel", itemGranel.Item),
            //                                                             new XAttribute("CodigoMercadoriaGranel", itemGranel.CodigoMercadoria),
            //                                                             new XAttribute("PesoBrutoGranel", itemGranel.PesoBruto),
            //                                                             new XAttribute("DestinoouOrigemGranel", itemGranel.DestinoouOrigem),
            //                                                             new XAttribute("CodigoImoGranel", itemGranel.CodigoIMO),
            //                                                             new XAttribute("CodigoOnuGranel", itemGranel.CodigoOnu),
            //                                                             new XAttribute("DDEGranel", itemGranel.DDE),
            //                                                             new XAttribute("REGranel", itemGranel.RE),
            //                                                             new XAttribute("SequencialGranel", itemGranel.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "111":
            //                        {
            //                            foreach (var itemMercadoriaConteinerizada in listaMercadoriaConteinerizada.Where(x => x.Sequencial == item.StringData.Substring(53, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "MercadoriaConteinerizada",
            //                                                              new XAttribute("IdentificadorMercadoriaConteinerizada", itemMercadoriaConteinerizada.Identificador),
            //                                                             new XAttribute("CnpjMercadoriaConteinerizada", itemMercadoriaConteinerizada.CNPJBase + itemMercadoriaConteinerizada.CNPJFilial + itemMercadoriaConteinerizada.CNPJControle),
            //                                                             new XAttribute("NumeroViagemMercadoriaConteinerizada", itemMercadoriaConteinerizada.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimMercadoriaConteinerizada", itemMercadoriaConteinerizada.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoMercadoriaConteinerizada", itemMercadoriaConteinerizada.PortoEmissao),
            //                                                             new XAttribute("EmitenteMercadoriaConteinerizada", itemMercadoriaConteinerizada.Emitente),
            //                                                             new XAttribute("DataEmissaoMercadoriaConteinerizada", itemMercadoriaConteinerizada.DataEmissao),
            //                                                             new XAttribute("ItemMercadoriaConteinerizada", itemMercadoriaConteinerizada.Item),
            //                                                             new XAttribute("CodigoMercadoriaMercadoriaConteinerizada", itemMercadoriaConteinerizada.CodigoMercadoria),
            //                                                             new XAttribute("QuantidadeVolumeMercadoriaConteinerizada", itemMercadoriaConteinerizada.QuantidadeVolume),
            //                                                             new XAttribute("PesoBrutoMercadoriaConteinerizada", itemMercadoriaConteinerizada.PesoBruto),
            //                                                             new XAttribute("CodigoEmbalagemMercadoriaConteinerizada", itemMercadoriaConteinerizada.CodigoEmbalagem),
            //                                                             new XAttribute("MarcaMercadoriaConteinerizada", itemMercadoriaConteinerizada.Marca),
            //                                                             new XAttribute("ContraMarcaMercadoriaConteinerizada", itemMercadoriaConteinerizada.ContraMarca),
            //                                                             new XAttribute("DestinoouOrigemMercadoriaConteinerizada", itemMercadoriaConteinerizada.DestinoouOrigem),
            //                                                             new XAttribute("SiglaConteinerMercadoriaConteinerizada", itemMercadoriaConteinerizada.SiglaConteiner),
            //                                                             new XAttribute("DestinoouOrigemConteinerizada", itemMercadoriaConteinerizada.CodigoIMO),
            //                                                             new XAttribute("CodigoIMOConteinerizada", itemMercadoriaConteinerizada.CodigoOnu),
            //                                                             new XAttribute("DDEMercadoriaConteinerizada", itemMercadoriaConteinerizada.DDE),
            //                                                             new XAttribute("REMercadoriaConteinerizada", itemMercadoriaConteinerizada.RE),
            //                                                             new XAttribute("SequencialMercadoriaConteinerizada", itemMercadoriaConteinerizada.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }
            //                    case "112":
            //                        {
            //                            foreach (var itemBoletimDescricao in listaBoletimDescricao.Where(x => x.Sequencial == item.StringData.Substring(156, 6)))
            //                            {
            //                                xEle.Add(
            //                                           new XElement(
            //                                                            "BoletimDescricao",
            //                                                             new XAttribute("IdentificadorBoletimDescricao", itemBoletimDescricao.Identificador),
            //                                                             new XAttribute("CnpjBoletimDescricao", itemBoletimDescricao.CNPJBase + itemBoletimDescricao.CNPJFilial + itemBoletimDescricao.CNPJControle),
            //                                                             new XAttribute("NumeroViagemBoletimDescricao", itemBoletimDescricao.NumeroViagem),
            //                                                             new XAttribute("NumeroBoletimBoletimDescricao", itemBoletimDescricao.NumeroBoletim),
            //                                                             new XAttribute("PortoEmissaoBoletimDescricao", itemBoletimDescricao.PortoEmissao),
            //                                                             new XAttribute("Emitente", itemBoletimDescricao.Emitente),
            //                                                             new XAttribute("DataEmissao", itemBoletimDescricao.DataEmissao),
            //                                                             new XAttribute("ItemBoletimDescricao", itemBoletimDescricao.Item),
            //                                                             new XAttribute("OrigemBoletimDescricao", itemBoletimDescricao.Origem),
            //                                                             new XAttribute("DescritivoBoletimDescricao", itemBoletimDescricao.Descritivo),
            //                                                             new XAttribute("SequencialBoletimDescricao", itemBoletimDescricao.Sequencial)
            //                                                       )
            //                                       );
            //                            }
            //                            break;
            //                        }

            //                    case "199":
            //                        {

            //                            xEle.Add(
            //                                       new XElement(
            //                                                        "Trailler",
            //                                                         new XAttribute("IdentificadorTrailler", objTrailler.Identificador),
            //                                                         new XAttribute("QuantidadeRegistro102Trailler", objTrailler.QuantidadeRegistro102),
            //                                                         new XAttribute("QuantidadeRegistro103Trailler", objTrailler.QuantidadeRegistro103),
            //                                                         new XAttribute("QuantidadeRegistro104Trailler", objTrailler.QuantidadeRegistro103),
            //                                                         new XAttribute("QuantidadeRegistro105Trailler", objTrailler.QuantidadeRegistro105),
            //                                                         new XAttribute("QuantidadeRegistro106Trailler", objTrailler.QuantidadeRegistro106),
            //                                                         new XAttribute("QuantidadeRegistro107Trailler", objTrailler.QuantidadeRegistro107),
            //                                                         new XAttribute("QuantidadeRegistro108Trailler", objTrailler.QuantidadeRegistro108),
            //                                                         new XAttribute("QuantidadeRegistro109Trailler", objTrailler.QuantidadeRegistro109),
            //                                                         new XAttribute("QuantidadeRegistro110Trailler", objTrailler.QuantidadeRegistro110),
            //                                                         new XAttribute("QuantidadeRegistro111Trailler", objTrailler.QuantidadeRegistro111),
            //                                                         new XAttribute("QuantidadeRegistro112Trailler", objTrailler.QuantidadeRegistro112),
            //                                                         new XAttribute("QuantidadeTotalRegistroTrailler", objTrailler.QuantidadeTotalRegistro),
            //                                                         new XAttribute("SequencialTrailler", objTrailler.Sequencial)
            //                                                   )

            //                                   );

            //                            break;
            //                        }
            //                }

            //            }

            //            var xManifesto = new XElement("Manifesto", xEle);

            //            #region inserir tabela integracao

            //            //string xml = File.ReadAllText(xManifesto.ToString());
            //            Utils integraManifesto = new Utils();
            //            integraManifesto.InsereIntegracaoXML("Manifesto", xManifesto.ToString(), nomearquivo);
            //            #endregion


            //            #endregion
            //        }
            //        return listaLog;
            //    }
            //    catch (Exception e)
            //    {

            //        throw;
            //    }
            //}


        public static T Desserelizar<T>(string arquivo) where T : new()
        {
            dynamic result = new T();

            XmlSerializer ser = new XmlSerializer(typeof(T));
            TextReader textReader = (TextReader)new StreamReader(arquivo);
            XmlTextReader reader = new XmlTextReader(textReader);
            reader.Read();
            result = (T)ser.Deserialize(reader);


            //switch (entidade)
            //{
            //    case "DE":
            //        {
            //            XmlSerializer ser = new XmlSerializer(typeof(fichaDadosEmbarcacao));
            //            TextReader textReader = (TextReader)new StreamReader(arquivo);
            //            XmlTextReader reader = new XmlTextReader(textReader);
            //            reader.Read();
            //            fichaDadosEmbarcacao obj = (fichaDadosEmbarcacao)ser.Deserialize(reader);
            //            result = (T)ser.Deserialize(reader);
            //            break;

            //        }

            //    case "AACDRJ":
            //        {
            //            XmlSerializer ser = new XmlSerializer(typeof(fichaAvisoAtracacao));
            //            TextReader textReader = (TextReader)new StreamReader(arquivo);
            //            XmlTextReader reader = new XmlTextReader(textReader);
            //            reader.Read();
            //            fichaAvisoAtracacao obj = (fichaAvisoAtracacao)ser.Deserialize(reader);
            //            break;
            //        }
            //    case "PE":
            //        {
            //            XmlSerializer ser = new XmlSerializer(typeof(fichaPrevisaoEstadia));
            //            TextReader textReader = (TextReader)new StreamReader(arquivo);
            //            XmlTextReader reader = new XmlTextReader(textReader);
            //            reader.Read();
            //            fichaPrevisaoEstadia obj = (fichaPrevisaoEstadia)ser.Deserialize(reader);
            //            break;
            //        }
            //    case "RPJV":
            //        {
            //            XmlSerializer ser = new XmlSerializer(typeof(fichaRegistroParceiroJV));
            //            TextReader textReader = (TextReader)new StreamReader(arquivo);
            //            XmlTextReader reader = new XmlTextReader(textReader);
            //            reader.Read();
            //            fichaRegistroParceiroJV obj = (fichaRegistroParceiroJV)ser.Deserialize(reader);
            //            break;
            //        }

            //    default:
            //        break;
            //}
            return (T)result;
        }


        //public string VarrerDiretorio()
        //{
        //    //string tokenTransaction = MD5Hash.CalculaHash(DateTime.Now.ToString("yyyyMMddhmmtt"));
        //    // bool ok = false;
        //    List<LogMessage> lista = new List<LogMessage>();
        //    int qtdeArquivosvalidosXml = 0, qtdeArquivosvalidostxt = 0;
        //    int qtdeArquivosinvalidosXml = 0, qtdeArquivosinvalidostxt = 0;
           
        //    #region pre requisito saber os locais dos arquivos a buscar
        //    // string pastaOrigem = @"C:\Projetos\Docas\Fichas XML\Xml_Entrada";
        //    // string pastaDestino = @"C:\Projetos\Docas\Fichas XML\Xml_Validado";
        //    // string pastaDestinoForaPadrao = @"C:\Projetos\Docas\Fichas XML\Xml_ForaPadrao";
        //    //string modeloXsd = @"C:\Projetos\Docas\Modelos XSD\";
        //    #endregion

        //    if (!Directory.Exists(CaminhoValido))
        //        Directory.CreateDirectory(CaminhoValido);

        //    var arquivos = new DirectoryInfo(CaminhoBusca).EnumerateFiles("*.*", SearchOption.AllDirectories).Where(x => x.Extension == ".txt" || x.Extension == ".xml");
        //    foreach (var arquivo in arquivos)
        //    {
        //        if (arquivo.Extension == ".xml")
        //        {

        //            ValidacaoXML validadorXML = new ValidacaoXML();
        //            string nomeArquivosTratado = arquivo.Name.Substring(17, arquivo.Name.Length - 17).Substring(0, arquivo.Name.Substring(17, arquivo.Name.Length - 17).IndexOf("_"));
        //            lista = validadorXML.ValidarXml(arquivo.FullName, modeloXsd + nomeArquivosTratado + ".xsd");

        //            if (lista.Where(x => x.NomeEntidade != "").Count() > 0)
        //            {
        //                qtdeArquivosinvalidosXml = qtdeArquivosinvalidosXml + 1;

        //                #region criando xml 
        //                var xEle = new XElement("LogMessage", from emp in lista
        //                                                      select new XElement("Falhas",
        //                                                              new XAttribute("Message", emp.Message),
        //                                                              new XAttribute("MessageSystem", emp.MessageSystem),
        //                                                              new XAttribute("Data", emp.Data),
        //                                                              new XAttribute("NomeEntidade", emp.NomeEntidade)
        //                    ));

        //                #endregion

        //                #region Inserindo erro na entidade
        //                Utils util = new Utils();

        //                foreach (var itemErro in lista)
        //                {
        //                    util.InsereLog(itemErro.Linha, nomeArquivosTratado, arquivo.Name, itemErro.Message, itemErro.MessageSystem);
        //                }

        //                var nomeArquivo = Path.GetFileName(arquivo.FullName);
        //                var caminhoDestino = Path.Combine(CaminhoErro, nomeArquivo);
        //                arquivo.MoveTo(caminhoDestino);
        //                xEle.Save(CaminhoErro + nomeArquivo + "_ERROR");

        //                #endregion
        //            }
        //            else
        //            {
        //                //Arquivo validado
        //                qtdeArquivosvalidosXml = qtdeArquivosvalidosXml + 1;
        //                var nomeArquivo = Path.GetFileName(arquivo.FullName);
        //                var caminhoDestino = Path.Combine(CaminhoValido, nomeArquivo);
        //                Utils util = new Utils();
        //                if (!File.Exists(caminhoDestino))
        //                {
        //                    arquivo.MoveTo(caminhoDestino);
        //                    string xmlString = File.ReadAllText(caminhoDestino);
        //                    if (db.Integracoes.Where(x => x.DtProcessamento != null && x.NomeArquivo == arquivo.Name).Count() > 0)
        //                    {
        //                        util.InsereIntegracaoXML(nomeArquivosTratado, xmlString, nomeArquivo);
        //                        util.InsereLog(0, nomeArquivosTratado, arquivo.Name, "ERR_01: Arquivo processado anteriormente", "Arquivo processado anteriormente, favor verificar!");
        //                        return "ERR_01: Arquivo processado anteriormente";
        //                    }
        //                }
        //                else
        //                {
        //                    if (db.Integracoes.Where(x => x.DtProcessamento != null && x.NomeArquivo == arquivo.Name).Count() > 0)
        //                    {
        //                        util.InsereLog(0, nomeArquivosTratado, arquivo.Name, "Arquivo processado anteriormente", "Arquivo processado anteriormente, favor verificar!");
        //                        return "Arquivo processado anteriormente";
        //                    }
        //                }

        //                //switch (nomeArquivosTratado)
        //                //{
        //                //    case "DE":
        //                //        {
        //                //            fichaDadosEmbarcacao obj = Desserelizar<fichaDadosEmbarcacao>(CaminhoValido + nomeArquivo);
        //                //            break;
        //                //        }
        //                //    case "PE":
        //                //        {
        //                //            fichaPrevisaoEstadia obj = Desserelizar<fichaPrevisaoEstadia>(CaminhoValido + nomeArquivo);
        //                //            break;
        //                //        }
        //                //    case "AACDRJ":
        //                //        {
        //                //            fichaAvisoAtracacao obj = Desserelizar<fichaAvisoAtracacao>(CaminhoValido + nomeArquivo);
        //                //            break;
        //                //        }
        //                //    case "RPJV":
        //                //        {
        //                //            fichaRegistroParceiroJV obj = Desserelizar<fichaRegistroParceiroJV>(CaminhoValido + nomeArquivo);
        //                //            break;
        //                //        }
        //                //        //default:
        //                //        //    { }
        //                //}


        //            }
        //        }
        //        if (arquivo.Extension == ".txt")
        //        {

        //            var nomeArquivo = Path.GetFileName(arquivo.FullName); // texto.txt
        //            var caminhoDestino = Path.Combine(CaminhoValido, nomeArquivo);
        //            var caminhoBusca = Path.Combine(CaminhoBusca, nomeArquivo);
        //            string xmlString = File.ReadAllText(caminhoBusca);
        //            Utils util = new Utils();
        //            if (db.Integracoes.Where(x => x.NomeArquivo == nomeArquivo && x.DtProcessamento != null).Count() <= 0)
        //            {

        //                lista = util.ValidadorManifesto(caminhoBusca, nomeArquivo);
        //                if (lista.Select(x => x.Message != "").FirstOrDefault())
        //                {
        //                    qtdeArquivosinvalidostxt = qtdeArquivosinvalidostxt + 1;
        //                    caminhoDestino = Path.Combine(CaminhoErro, nomeArquivo);
        //                    #region criando xml 
        //                    var xEle = new XElement("LogMessage", from emp in lista
        //                                                          select new XElement("Error",
        //                                                                  new XAttribute("Message", emp.Message),
        //                                                                  new XAttribute("MessageSystem", emp.MessageSystem),
        //                                                                  new XAttribute("Data", emp.Data),
        //                                                                  new XAttribute("Entidade", emp.NomeEntidade)
        //                        ));

        //                    #endregion

        //                    foreach (var itemErro in lista)
        //                    {
        //                        util.InsereLog(itemErro.Linha, itemErro.NomeEntidade, arquivo.Name, itemErro.Message, itemErro.MessageSystem);
        //                    }
        //                    if (!File.Exists(caminhoDestino))
        //                    {
        //                        arquivo.MoveTo(caminhoDestino);
        //                        xEle.Save(CaminhoErro + nomeArquivo + "_ERROR");
        //                    }
        //                }
        //                else
        //                {
        //                    //Sucesso
        //                    qtdeArquivosvalidostxt = qtdeArquivosvalidostxt + 1;
        //                    if (!File.Exists(caminhoDestino))
        //                        arquivo.MoveTo(caminhoDestino);
        //                }
        //            }
        //            else
        //            {
        //                //Arquivo já foi importado anteriormente
        //                qtdeArquivosinvalidostxt = qtdeArquivosinvalidostxt + 1;
        //                util.InsereLog(0, "Sistema", arquivo.Name, "Arquivo repetido", "Arquivo já consta na base para processamento");
        //            }

        //        }
        //    }

        //    return string.Format("XML's válidos: " + qtdeArquivosvalidosXml.ToString() + " | inválidos: " + qtdeArquivosinvalidosXml.ToString()
        //                       + " TXT's válidos: "+ qtdeArquivosvalidostxt.ToString() + " | inválidos: " + qtdeArquivosinvalidostxt.ToString()
        //                        );

        //}
    }
}
