using IntegracaoPsP.Domain.Entities.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;


namespace IntegracaoPsP.Domain.Entities.Validacao
{

    public class ValidacaoXML
    {
       
        private bool falhou;
        List<LogMessage> listaMessage = new List<LogMessage>();
        public bool Falhou
        {
            get { return falhou; }
        }

        public bool ValidarXmlbkp(string xmlFilename, string schemaFilename)
        {
            // Define o tipo de validação
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            // Carrega o arquivo de esquema
            XmlSchemaSet schemas = new XmlSchemaSet();
            settings.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 
            schemas.Add(null, schemaFilename);
            
            // Especifica o tratamento de evento para os erros de validacao
            settings.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            XmlReader validator = XmlReader.Create(xmlFilename, settings);

            falhou = false;
            try
            {
                // Faz a leitura de todos os dados XML
                while (validator.Read()) { }
            }
            catch (XmlException err)
            {
                // Um erro ocorre se o documento XML inclui caracteres ilegais
                // ou tags que não estão aninhadas corretamente
                Console.WriteLine("Ocorreu um erro critico durante a validacao XML.");
                Console.WriteLine(err.Message);
                falhou = true;
            }
            finally
            {
                validator.Close();
            }
            return !falhou;
        }


        public List<LogMessage> ValidarXmlValido(string xmlFilename, string schemaFilename)
        {
            // Define o tipo de validação
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            // Carrega o arquivo de esquema
            XmlSchemaSet schemas = new XmlSchemaSet();
            settings.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 


            schemas.Add(null, schemaFilename);
            // Especifica o tratamento de evento para os erros de validacao
            settings.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            XmlReader validator = XmlReader.Create(xmlFilename, settings);
            falhou = false;
            try
            {
                // Faz a leitura de todos os dados XML
                while (validator.Read()) { }
            }
            catch (XmlException err)
            {
                // Um erro ocorre se o documento XML inclui caracteres ilegais
                // ou tags que não estão aninhadas corretamente
                Console.WriteLine("Ocorreu um erro critico durante a validacao XML.");
                Console.WriteLine(err.Message);
                falhou = true;
            }
            finally
            {
                validator.Close();
            }
            return listaMessage;
        }

        public List<LogMessage> ValidarXml(string xmlFilename, string schemaFilename)
        {
            // Define o tipo de validação
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            // Carrega o arquivo de esquema
            XmlSchemaSet schemas = new XmlSchemaSet();
            settings.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 

            ///TESTE

            System.Text.ASCIIEncoding myEncoder = new System.Text.ASCIIEncoding();
            //MemoryStream MemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(@"C:\Projetos\Docas\Modelos XSD\DE.xsd")));
            MemoryStream MemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(schemaFilename));
            // byte[] bytes = myEncoder.GetBytes(File.ReadAllText(@"C:\Projetos\Docas\Modelos XSD\DE.xsd"));
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.CloseInput = true;
            XmlReader xmlR = XmlReader.Create(MemoryStream, xmlReaderSettings);


            schemas.Add(null, xmlR);

            //////
          //  schemas.Add(null, xr);
            // Especifica o tratamento de evento para os erros de validacao
            settings.ValidationEventHandler += ValidationEventHandler;
            // cria um leitor para validação
            XmlReader validator = XmlReader.Create(xmlFilename, settings);
            falhou = false;
            try
            {
                // Faz a leitura de todos os dados XML
                while (validator.Read()) { }
            }
            catch (XmlException err)
            {
                // Um erro ocorre se o documento XML inclui caracteres ilegais
                // ou tags que não estão aninhadas corretamente
                Console.WriteLine("Ocorreu um erro critico durante a validacao XML.");
                Console.WriteLine(err.Message);
                falhou = true;
            }
            finally
            {
                validator.Close();
            }
            return listaMessage;
        }



        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            falhou = true;
            // Exibe o erro da validação
            listaMessage.Add(new LogMessage
                                                   {
                                                       Linha = 0,
                                                       NomeEntidade = "saasa",//sender.ToString(),
                                                       Message = args.Message,
                                                       MessageSystem = args.Message,
                                                       Data = DateTime.Now,
                                                       Id = 0

                                                   }
                                  );

            


            //Console.WriteLine();
        }

        private void ValidationEventHandlerbkp(object sender, ValidationEventArgs args)
        {
            falhou = true;
            // Exibe o erro da validação
            LogMessage listaLog = (new LogMessage
            {
                Linha = 0,
                NomeEntidade = sender.ToString(),
                Message = args.Message,
                MessageSystem = args.Message
            }
                                  );




            //Console.WriteLine();
        }






    }

}
