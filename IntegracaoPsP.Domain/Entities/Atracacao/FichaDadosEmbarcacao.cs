namespace fichaDadosEmbarcacao
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class fichaDadosEmbarcacao
    {

        private uint numeroDuvField;

        private fichaDadosEmbarcacaoAgenteMaritimo agenteMaritimoField;

        private string dataHoraPrevistaAtracacaoField;

        private string dataHoraPrevistaDesatracacaoField;

        private fichaDadosEmbarcacaoEmbarcacao embarcacaoField;

        /// <remarks/>
        public uint numeroDuv
        {
            get
            {
                return this.numeroDuvField;
            }
            set
            {
                this.numeroDuvField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoAgenteMaritimo agenteMaritimo
        {
            get
            {
                return this.agenteMaritimoField;
            }
            set
            {
                this.agenteMaritimoField = value;
            }
        }

        /// <remarks/>
        public string dataHoraPrevistaAtracacao
        {
            get
            {
                return this.dataHoraPrevistaAtracacaoField;
            }
            set
            {
                this.dataHoraPrevistaAtracacaoField = value;
            }
        }

        /// <remarks/>
        public string dataHoraPrevistaDesatracacao
        {
            get
            {
                return this.dataHoraPrevistaDesatracacaoField;
            }
            set
            {
                this.dataHoraPrevistaDesatracacaoField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacao embarcacao
        {
            get
            {
                return this.embarcacaoField;
            }
            set
            {
                this.embarcacaoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoAgenteMaritimo
    {

        private string nomeAgenciaField;

        private ulong cnpjAgenciaNavegacaoField;

        /// <remarks/>
        public string nomeAgencia
        {
            get
            {
                return this.nomeAgenciaField;
            }
            set
            {
                this.nomeAgenciaField = value;
            }
        }

        /// <remarks/>
        public ulong cnpjAgenciaNavegacao
        {
            get
            {
                return this.cnpjAgenciaNavegacaoField;
            }
            set
            {
                this.cnpjAgenciaNavegacaoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacao
    {

        private uint numeroIMOField;

        private string nomeEmbarcacaoField;

        private string areaNavegacaoField;

        private string nomeSociedadeClassificacaoField;

        private uint numeroInternacionalRegistroField;

        private object portariaHomologacaoHelipontoField;

        private decimal autonomiaRetencaoField;

        private string finalidadeField;

        private string tipoEmbarcacaoField;

        private string dataCertificadoRegistroField;

        private object numeroProvisorioRegistroField;

        private object numeroPRPMField;

        private object numeroTieField;

        private object numeroPrepsField;

        private object dataAdesaoPrepsField;

        private object inscricaoField;

        private ushort estadoBandeiraField;

        private fichaDadosEmbarcacaoEmbarcacaoArmadorProprietario armadorProprietarioField;

        private fichaDadosEmbarcacaoEmbarcacaoArmadorAfretador armadorAfretadorField;

        private object alturaBordaLivreField;

        private object capacidadeEquipamentoBordaLivreField;

        private object anoFabricacaoField;

        private fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacao meiosComunicacaoField;

        private fichaDadosEmbarcacaoEmbarcacaoCaracteristicas caracteristicasField;

        private fichaDadosEmbarcacaoEmbarcacaoIndicadores indicadoresField;

        private fichaDadosEmbarcacaoEmbarcacaoCertificados[] certificadosField;

        private fichaDadosEmbarcacaoEmbarcacaoPasseEntrada passeEntradaField;

        private fichaDadosEmbarcacaoEmbarcacaoPasseSaida passeSaidaField;

        /// <remarks/>
        public uint numeroIMO
        {
            get
            {
                return this.numeroIMOField;
            }
            set
            {
                this.numeroIMOField = value;
            }
        }

        /// <remarks/>
        public string nomeEmbarcacao
        {
            get
            {
                return this.nomeEmbarcacaoField;
            }
            set
            {
                this.nomeEmbarcacaoField = value;
            }
        }

        /// <remarks/>
        public string areaNavegacao
        {
            get
            {
                return this.areaNavegacaoField;
            }
            set
            {
                this.areaNavegacaoField = value;
            }
        }

        /// <remarks/>
        public string nomeSociedadeClassificacao
        {
            get
            {
                return this.nomeSociedadeClassificacaoField;
            }
            set
            {
                this.nomeSociedadeClassificacaoField = value;
            }
        }

        /// <remarks/>
        public uint numeroInternacionalRegistro
        {
            get
            {
                return this.numeroInternacionalRegistroField;
            }
            set
            {
                this.numeroInternacionalRegistroField = value;
            }
        }

        /// <remarks/>
        public object portariaHomologacaoHeliponto
        {
            get
            {
                return this.portariaHomologacaoHelipontoField;
            }
            set
            {
                this.portariaHomologacaoHelipontoField = value;
            }
        }

        /// <remarks/>
        public decimal autonomiaRetencao
        {
            get
            {
                return this.autonomiaRetencaoField;
            }
            set
            {
                this.autonomiaRetencaoField = value;
            }
        }

        /// <remarks/>
        public string finalidade
        {
            get
            {
                return this.finalidadeField;
            }
            set
            {
                this.finalidadeField = value;
            }
        }

        /// <remarks/>
        public string tipoEmbarcacao
        {
            get
            {
                return this.tipoEmbarcacaoField;
            }
            set
            {
                this.tipoEmbarcacaoField = value;
            }
        }

        /// <remarks/>
        public string dataCertificadoRegistro
        {
            get
            {
                return this.dataCertificadoRegistroField;
            }
            set
            {
                this.dataCertificadoRegistroField = value;
            }
        }

        /// <remarks/>
        public object numeroProvisorioRegistro
        {
            get
            {
                return this.numeroProvisorioRegistroField;
            }
            set
            {
                this.numeroProvisorioRegistroField = value;
            }
        }

        /// <remarks/>
        public object numeroPRPM
        {
            get
            {
                return this.numeroPRPMField;
            }
            set
            {
                this.numeroPRPMField = value;
            }
        }

        /// <remarks/>
        public object numeroTie
        {
            get
            {
                return this.numeroTieField;
            }
            set
            {
                this.numeroTieField = value;
            }
        }

        /// <remarks/>
        public object numeroPreps
        {
            get
            {
                return this.numeroPrepsField;
            }
            set
            {
                this.numeroPrepsField = value;
            }
        }

        /// <remarks/>
        public object dataAdesaoPreps
        {
            get
            {
                return this.dataAdesaoPrepsField;
            }
            set
            {
                this.dataAdesaoPrepsField = value;
            }
        }

        /// <remarks/>
        public object inscricao
        {
            get
            {
                return this.inscricaoField;
            }
            set
            {
                this.inscricaoField = value;
            }
        }

        /// <remarks/>
        public ushort estadoBandeira
        {
            get
            {
                return this.estadoBandeiraField;
            }
            set
            {
                this.estadoBandeiraField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoArmadorProprietario armadorProprietario
        {
            get
            {
                return this.armadorProprietarioField;
            }
            set
            {
                this.armadorProprietarioField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoArmadorAfretador armadorAfretador
        {
            get
            {
                return this.armadorAfretadorField;
            }
            set
            {
                this.armadorAfretadorField = value;
            }
        }

        /// <remarks/>
        public object alturaBordaLivre
        {
            get
            {
                return this.alturaBordaLivreField;
            }
            set
            {
                this.alturaBordaLivreField = value;
            }
        }

        /// <remarks/>
        public object capacidadeEquipamentoBordaLivre
        {
            get
            {
                return this.capacidadeEquipamentoBordaLivreField;
            }
            set
            {
                this.capacidadeEquipamentoBordaLivreField = value;
            }
        }

        /// <remarks/>
        public object anoFabricacao
        {
            get
            {
                return this.anoFabricacaoField;
            }
            set
            {
                this.anoFabricacaoField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacao meiosComunicacao
        {
            get
            {
                return this.meiosComunicacaoField;
            }
            set
            {
                this.meiosComunicacaoField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoCaracteristicas caracteristicas
        {
            get
            {
                return this.caracteristicasField;
            }
            set
            {
                this.caracteristicasField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoIndicadores indicadores
        {
            get
            {
                return this.indicadoresField;
            }
            set
            {
                this.indicadoresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("certificados", IsNullable = false)]
        public fichaDadosEmbarcacaoEmbarcacaoCertificados[] certificados
        {
            get
            {
                return this.certificadosField;
            }
            set
            {
                this.certificadosField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoPasseEntrada passeEntrada
        {
            get
            {
                return this.passeEntradaField;
            }
            set
            {
                this.passeEntradaField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoPasseSaida passeSaida
        {
            get
            {
                return this.passeSaidaField;
            }
            set
            {
                this.passeSaidaField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoArmadorProprietario
    {

        private string codigoCoanaField;

        private string nomeArmadorField;

        private ushort sedeArmadorField;

        /// <remarks/>
        public string codigoCoana
        {
            get
            {
                return this.codigoCoanaField;
            }
            set
            {
                this.codigoCoanaField = value;
            }
        }

        /// <remarks/>
        public string nomeArmador
        {
            get
            {
                return this.nomeArmadorField;
            }
            set
            {
                this.nomeArmadorField = value;
            }
        }

        /// <remarks/>
        public ushort sedeArmador
        {
            get
            {
                return this.sedeArmadorField;
            }
            set
            {
                this.sedeArmadorField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoArmadorAfretador
    {

        private string codigoCoanaField;

        private string nomeArmadorField;

        /// <remarks/>
        public string codigoCoana
        {
            get
            {
                return this.codigoCoanaField;
            }
            set
            {
                this.codigoCoanaField = value;
            }
        }

        /// <remarks/>
        public string nomeArmador
        {
            get
            {
                return this.nomeArmadorField;
            }
            set
            {
                this.nomeArmadorField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacao
    {

        private string irinField;

        private uint numeroINMARSATField;

        private string codigoChamadaDSCField;

        private decimal frequenciaDSCField;

        private string tipoSisOperacaoEPIRBField;

        private string radiotelefoniaField;

        private string radiotelegrafiaField;

        private bool radiotelexField;

        private bool sartTransponderField;

        private string tipoINMARSATField;

        private bool transponder9GhzField;

        private bool navtexField;

        private bool prepsField;

        private ushort numEPIRBField;

        private uint numeroMMSIEPIRBField;

        private string modeloEPIRBField;

        private string fabricanteEPIRBField;

        private object outrosEquipField;

        private fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacaoEmpresaManutencao empresaManutencaoField;

        /// <remarks/>
        public string irin
        {
            get
            {
                return this.irinField;
            }
            set
            {
                this.irinField = value;
            }
        }

        /// <remarks/>
        public uint numeroINMARSAT
        {
            get
            {
                return this.numeroINMARSATField;
            }
            set
            {
                this.numeroINMARSATField = value;
            }
        }

        /// <remarks/>
        public string codigoChamadaDSC
        {
            get
            {
                return this.codigoChamadaDSCField;
            }
            set
            {
                this.codigoChamadaDSCField = value;
            }
        }

        /// <remarks/>
        public decimal frequenciaDSC
        {
            get
            {
                return this.frequenciaDSCField;
            }
            set
            {
                this.frequenciaDSCField = value;
            }
        }

        /// <remarks/>
        public string tipoSisOperacaoEPIRB
        {
            get
            {
                return this.tipoSisOperacaoEPIRBField;
            }
            set
            {
                this.tipoSisOperacaoEPIRBField = value;
            }
        }

        /// <remarks/>
        public string radiotelefonia
        {
            get
            {
                return this.radiotelefoniaField;
            }
            set
            {
                this.radiotelefoniaField = value;
            }
        }

        /// <remarks/>
        public string radiotelegrafia
        {
            get
            {
                return this.radiotelegrafiaField;
            }
            set
            {
                this.radiotelegrafiaField = value;
            }
        }

        /// <remarks/>
        public bool radiotelex
        {
            get
            {
                return this.radiotelexField;
            }
            set
            {
                this.radiotelexField = value;
            }
        }

        /// <remarks/>
        public bool sartTransponder
        {
            get
            {
                return this.sartTransponderField;
            }
            set
            {
                this.sartTransponderField = value;
            }
        }

        /// <remarks/>
        public string tipoINMARSAT
        {
            get
            {
                return this.tipoINMARSATField;
            }
            set
            {
                this.tipoINMARSATField = value;
            }
        }

        /// <remarks/>
        public bool transponder9Ghz
        {
            get
            {
                return this.transponder9GhzField;
            }
            set
            {
                this.transponder9GhzField = value;
            }
        }

        /// <remarks/>
        public bool navtex
        {
            get
            {
                return this.navtexField;
            }
            set
            {
                this.navtexField = value;
            }
        }

        /// <remarks/>
        public bool preps
        {
            get
            {
                return this.prepsField;
            }
            set
            {
                this.prepsField = value;
            }
        }

        /// <remarks/>
        public ushort numEPIRB
        {
            get
            {
                return this.numEPIRBField;
            }
            set
            {
                this.numEPIRBField = value;
            }
        }

        /// <remarks/>
        public uint numeroMMSIEPIRB
        {
            get
            {
                return this.numeroMMSIEPIRBField;
            }
            set
            {
                this.numeroMMSIEPIRBField = value;
            }
        }

        /// <remarks/>
        public string modeloEPIRB
        {
            get
            {
                return this.modeloEPIRBField;
            }
            set
            {
                this.modeloEPIRBField = value;
            }
        }

        /// <remarks/>
        public string fabricanteEPIRB
        {
            get
            {
                return this.fabricanteEPIRBField;
            }
            set
            {
                this.fabricanteEPIRBField = value;
            }
        }

        /// <remarks/>
        public object outrosEquip
        {
            get
            {
                return this.outrosEquipField;
            }
            set
            {
                this.outrosEquipField = value;
            }
        }

        /// <remarks/>
        public fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacaoEmpresaManutencao empresaManutencao
        {
            get
            {
                return this.empresaManutencaoField;
            }
            set
            {
                this.empresaManutencaoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoMeiosComunicacaoEmpresaManutencao
    {

        private object nomeEmpresaManutEPIRBField;

        private object nomePresidEmpManutEPIRBField;

        private object nomeChefeManutEmpManutEPIRBField;

        private object enderecoEmpManutEPIRBField;

        private object cidadeEmpManutEPIRBField;

        private object cepEmpManutEPIRBField;

        private object telEmpManutEPIRBField;

        private object telexEmpManutEPIRBField;

        private object faxEmpManutEPIRBField;

        /// <remarks/>
        public object nomeEmpresaManutEPIRB
        {
            get
            {
                return this.nomeEmpresaManutEPIRBField;
            }
            set
            {
                this.nomeEmpresaManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object nomePresidEmpManutEPIRB
        {
            get
            {
                return this.nomePresidEmpManutEPIRBField;
            }
            set
            {
                this.nomePresidEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object nomeChefeManutEmpManutEPIRB
        {
            get
            {
                return this.nomeChefeManutEmpManutEPIRBField;
            }
            set
            {
                this.nomeChefeManutEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object enderecoEmpManutEPIRB
        {
            get
            {
                return this.enderecoEmpManutEPIRBField;
            }
            set
            {
                this.enderecoEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object cidadeEmpManutEPIRB
        {
            get
            {
                return this.cidadeEmpManutEPIRBField;
            }
            set
            {
                this.cidadeEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object cepEmpManutEPIRB
        {
            get
            {
                return this.cepEmpManutEPIRBField;
            }
            set
            {
                this.cepEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object telEmpManutEPIRB
        {
            get
            {
                return this.telEmpManutEPIRBField;
            }
            set
            {
                this.telEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object telexEmpManutEPIRB
        {
            get
            {
                return this.telexEmpManutEPIRBField;
            }
            set
            {
                this.telexEmpManutEPIRBField = value;
            }
        }

        /// <remarks/>
        public object faxEmpManutEPIRB
        {
            get
            {
                return this.faxEmpManutEPIRBField;
            }
            set
            {
                this.faxEmpManutEPIRBField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoCaracteristicas
    {

        private decimal larguraField;

        private decimal comprimentoField;

        private decimal alturaField;

        private decimal caladoMaximoField;

        private decimal caladoMinimoField;

        private decimal capacidadeMaximaAguaField;

        private decimal arqueacaoBrutaField;

        private decimal dwtField;

        private decimal capacidadeAguaLastroField;

        private decimal arqueacaoLiquidaField;

        private decimal velocidadeMaximaField;

        private decimal capacidadeMaximaEfluentesField;

        private byte numeroCozinhasField;

        private byte numeroTanquesLastroField;

        private object corCascoField;

        private string tipoCascoField;

        private object corSuperestruturaField;

        private string tipoSuperestruturaField;

        private byte camarasRefrigeradasField;

        private object numeroLeitosHospitalField;

        private object numeroPiscinaAdultoField;

        private object numeroPiscinaInfantilField;

        private object numeroRestaurantesField;

        private object unidadesArCondicionadoField;

        private object banheirasHidromassagemField;

        private object totalTanquesField;

        private byte numeroPoroesField;

        /// <remarks/>
        public decimal largura
        {
            get
            {
                return this.larguraField;
            }
            set
            {
                this.larguraField = value;
            }
        }

        /// <remarks/>
        public decimal comprimento
        {
            get
            {
                return this.comprimentoField;
            }
            set
            {
                this.comprimentoField = value;
            }
        }

        /// <remarks/>
        public decimal altura
        {
            get
            {
                return this.alturaField;
            }
            set
            {
                this.alturaField = value;
            }
        }

        /// <remarks/>
        public decimal caladoMaximo
        {
            get
            {
                return this.caladoMaximoField;
            }
            set
            {
                this.caladoMaximoField = value;
            }
        }

        /// <remarks/>
        public decimal caladoMinimo
        {
            get
            {
                return this.caladoMinimoField;
            }
            set
            {
                this.caladoMinimoField = value;
            }
        }

        /// <remarks/>
        public decimal capacidadeMaximaAgua
        {
            get
            {
                return this.capacidadeMaximaAguaField;
            }
            set
            {
                this.capacidadeMaximaAguaField = value;
            }
        }

        /// <remarks/>
        public decimal arqueacaoBruta
        {
            get
            {
                return this.arqueacaoBrutaField;
            }
            set
            {
                this.arqueacaoBrutaField = value;
            }
        }

        /// <remarks/>
        public decimal dwt
        {
            get
            {
                return this.dwtField;
            }
            set
            {
                this.dwtField = value;
            }
        }

        /// <remarks/>
        public decimal capacidadeAguaLastro
        {
            get
            {
                return this.capacidadeAguaLastroField;
            }
            set
            {
                this.capacidadeAguaLastroField = value;
            }
        }

        /// <remarks/>
        public decimal arqueacaoLiquida
        {
            get
            {
                return this.arqueacaoLiquidaField;
            }
            set
            {
                this.arqueacaoLiquidaField = value;
            }
        }

        /// <remarks/>
        public decimal velocidadeMaxima
        {
            get
            {
                return this.velocidadeMaximaField;
            }
            set
            {
                this.velocidadeMaximaField = value;
            }
        }

        /// <remarks/>
        public decimal capacidadeMaximaEfluentes
        {
            get
            {
                return this.capacidadeMaximaEfluentesField;
            }
            set
            {
                this.capacidadeMaximaEfluentesField = value;
            }
        }

        /// <remarks/>
        public byte numeroCozinhas
        {
            get
            {
                return this.numeroCozinhasField;
            }
            set
            {
                this.numeroCozinhasField = value;
            }
        }

        /// <remarks/>
        public byte numeroTanquesLastro
        {
            get
            {
                return this.numeroTanquesLastroField;
            }
            set
            {
                this.numeroTanquesLastroField = value;
            }
        }

        /// <remarks/>
        public object corCasco
        {
            get
            {
                return this.corCascoField;
            }
            set
            {
                this.corCascoField = value;
            }
        }

        /// <remarks/>
        public string tipoCasco
        {
            get
            {
                return this.tipoCascoField;
            }
            set
            {
                this.tipoCascoField = value;
            }
        }

        /// <remarks/>
        public object corSuperestrutura
        {
            get
            {
                return this.corSuperestruturaField;
            }
            set
            {
                this.corSuperestruturaField = value;
            }
        }

        /// <remarks/>
        public string tipoSuperestrutura
        {
            get
            {
                return this.tipoSuperestruturaField;
            }
            set
            {
                this.tipoSuperestruturaField = value;
            }
        }

        /// <remarks/>
        public byte camarasRefrigeradas
        {
            get
            {
                return this.camarasRefrigeradasField;
            }
            set
            {
                this.camarasRefrigeradasField = value;
            }
        }

        /// <remarks/>
        public object numeroLeitosHospital
        {
            get
            {
                return this.numeroLeitosHospitalField;
            }
            set
            {
                this.numeroLeitosHospitalField = value;
            }
        }

        /// <remarks/>
        public object numeroPiscinaAdulto
        {
            get
            {
                return this.numeroPiscinaAdultoField;
            }
            set
            {
                this.numeroPiscinaAdultoField = value;
            }
        }

        /// <remarks/>
        public object numeroPiscinaInfantil
        {
            get
            {
                return this.numeroPiscinaInfantilField;
            }
            set
            {
                this.numeroPiscinaInfantilField = value;
            }
        }

        /// <remarks/>
        public object numeroRestaurantes
        {
            get
            {
                return this.numeroRestaurantesField;
            }
            set
            {
                this.numeroRestaurantesField = value;
            }
        }

        /// <remarks/>
        public object unidadesArCondicionado
        {
            get
            {
                return this.unidadesArCondicionadoField;
            }
            set
            {
                this.unidadesArCondicionadoField = value;
            }
        }

        /// <remarks/>
        public object banheirasHidromassagem
        {
            get
            {
                return this.banheirasHidromassagemField;
            }
            set
            {
                this.banheirasHidromassagemField = value;
            }
        }

        /// <remarks/>
        public object totalTanques
        {
            get
            {
                return this.totalTanquesField;
            }
            set
            {
                this.totalTanquesField = value;
            }
        }

        /// <remarks/>
        public byte numeroPoroes
        {
            get
            {
                return this.numeroPoroesField;
            }
            set
            {
                this.numeroPoroesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoIndicadores
    {

        private bool incineradoresField;

        private bool helipontoField;

        private bool coletaSeletivaField;

        private bool estacaoTratamentoEsgotoField;

        private bool estacaoTratamentoAguaField;

        private bool equipamentosPlanosSegurancaField;

        private bool certificadoTemporarioField;

        private bool poraoField;

        private bool salaResiduosSolidosField;

        private bool salaoBelezaField;

        private bool spaField;

        private bool indicadorAITField;

        private bool saunaField;

        private bool possuiGuindasteField;

        /// <remarks/>
        public bool incineradores
        {
            get
            {
                return this.incineradoresField;
            }
            set
            {
                this.incineradoresField = value;
            }
        }

        /// <remarks/>
        public bool heliponto
        {
            get
            {
                return this.helipontoField;
            }
            set
            {
                this.helipontoField = value;
            }
        }

        /// <remarks/>
        public bool coletaSeletiva
        {
            get
            {
                return this.coletaSeletivaField;
            }
            set
            {
                this.coletaSeletivaField = value;
            }
        }

        /// <remarks/>
        public bool estacaoTratamentoEsgoto
        {
            get
            {
                return this.estacaoTratamentoEsgotoField;
            }
            set
            {
                this.estacaoTratamentoEsgotoField = value;
            }
        }

        /// <remarks/>
        public bool estacaoTratamentoAgua
        {
            get
            {
                return this.estacaoTratamentoAguaField;
            }
            set
            {
                this.estacaoTratamentoAguaField = value;
            }
        }

        /// <remarks/>
        public bool equipamentosPlanosSeguranca
        {
            get
            {
                return this.equipamentosPlanosSegurancaField;
            }
            set
            {
                this.equipamentosPlanosSegurancaField = value;
            }
        }

        /// <remarks/>
        public bool certificadoTemporario
        {
            get
            {
                return this.certificadoTemporarioField;
            }
            set
            {
                this.certificadoTemporarioField = value;
            }
        }

        /// <remarks/>
        public bool porao
        {
            get
            {
                return this.poraoField;
            }
            set
            {
                this.poraoField = value;
            }
        }

        /// <remarks/>
        public bool salaResiduosSolidos
        {
            get
            {
                return this.salaResiduosSolidosField;
            }
            set
            {
                this.salaResiduosSolidosField = value;
            }
        }

        /// <remarks/>
        public bool salaoBeleza
        {
            get
            {
                return this.salaoBelezaField;
            }
            set
            {
                this.salaoBelezaField = value;
            }
        }

        /// <remarks/>
        public bool spa
        {
            get
            {
                return this.spaField;
            }
            set
            {
                this.spaField = value;
            }
        }

        /// <remarks/>
        public bool indicadorAIT
        {
            get
            {
                return this.indicadorAITField;
            }
            set
            {
                this.indicadorAITField = value;
            }
        }

        /// <remarks/>
        public bool sauna
        {
            get
            {
                return this.saunaField;
            }
            set
            {
                this.saunaField = value;
            }
        }

        /// <remarks/>
        public bool possuiGuindaste
        {
            get
            {
                return this.possuiGuindasteField;
            }
            set
            {
                this.possuiGuindasteField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoCertificados
    {

        private string numeroField;

        private string dataEmissaoField;

        private string dataExpiracaoField;

        private string tipoField;

        private object unidadeLocalEmitenteField;

        /// <remarks/>
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        public string dataEmissao
        {
            get
            {
                return this.dataEmissaoField;
            }
            set
            {
                this.dataEmissaoField = value;
            }
        }

        /// <remarks/>
        public string dataExpiracao
        {
            get
            {
                return this.dataExpiracaoField;
            }
            set
            {
                this.dataExpiracaoField = value;
            }
        }

        /// <remarks/>
        public string tipo
        {
            get
            {
                return this.tipoField;
            }
            set
            {
                this.tipoField = value;
            }
        }

        /// <remarks/>
        public object unidadeLocalEmitente
        {
            get
            {
                return this.unidadeLocalEmitenteField;
            }
            set
            {
                this.unidadeLocalEmitenteField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoPasseEntrada
    {

        private string numeroField;

        private string nomeVisitadorField;

        private string dataVisitaField;

        private string localField;

        private object tipoGRUField;

        private object observacaoField;

        /// <remarks/>
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        public string nomeVisitador
        {
            get
            {
                return this.nomeVisitadorField;
            }
            set
            {
                this.nomeVisitadorField = value;
            }
        }

        /// <remarks/>
        public string dataVisita
        {
            get
            {
                return this.dataVisitaField;
            }
            set
            {
                this.dataVisitaField = value;
            }
        }

        /// <remarks/>
        public string local
        {
            get
            {
                return this.localField;
            }
            set
            {
                this.localField = value;
            }
        }

        /// <remarks/>
        public object tipoGRU
        {
            get
            {
                return this.tipoGRUField;
            }
            set
            {
                this.tipoGRUField = value;
            }
        }

        /// <remarks/>
        public object observacao
        {
            get
            {
                return this.observacaoField;
            }
            set
            {
                this.observacaoField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class fichaDadosEmbarcacaoEmbarcacaoPasseSaida
    {

        private string numeroField;

        private string dataLiberacaoField;

        private string localField;

        private object tipoGRUField;

        private object observacaoField;

        /// <remarks/>
        public string numero
        {
            get
            {
                return this.numeroField;
            }
            set
            {
                this.numeroField = value;
            }
        }

        /// <remarks/>
        public string dataLiberacao
        {
            get
            {
                return this.dataLiberacaoField;
            }
            set
            {
                this.dataLiberacaoField = value;
            }
        }

        /// <remarks/>
        public string local
        {
            get
            {
                return this.localField;
            }
            set
            {
                this.localField = value;
            }
        }

        /// <remarks/>
        public object tipoGRU
        {
            get
            {
                return this.tipoGRUField;
            }
            set
            {
                this.tipoGRUField = value;
            }
        }

        /// <remarks/>
        public object observacao
        {
            get
            {
                return this.observacaoField;
            }
            set
            {
                this.observacaoField = value;
            }
        }
    }


}
