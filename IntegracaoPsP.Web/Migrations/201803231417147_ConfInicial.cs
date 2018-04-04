namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boletim",
                c => new
                    {
                        BoletimId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        TipoBoletim = c.String(nullable: false, maxLength: 1, unicode: false),
                        Observacao = c.String(maxLength: 60, unicode: false),
                        Shipper = c.String(nullable: false, maxLength: 60, unicode: false),
                        Consignee = c.String(nullable: false, maxLength: 60, unicode: false),
                        Notify = c.String(maxLength: 60, unicode: false),
                        Nvocc = c.String(maxLength: 60, unicode: false),
                        PortodeTransbordo = c.String(maxLength: 5, unicode: false),
                        PortodeDestinoFinal = c.String(nullable: false, maxLength: 5, unicode: false),
                        CE = c.String(nullable: false, maxLength: 20, unicode: false),
                        TransitoPara = c.String(maxLength: 10, unicode: false),
                        Corrente = c.String(nullable: false, maxLength: 20, unicode: false),
                        CNPJShipper = c.String(nullable: false, maxLength: 14, unicode: false),
                        CNPJConsigner = c.String(nullable: false, maxLength: 14, unicode: false),
                        CNPJNotify = c.String(maxLength: 14, unicode: false),
                        CNPJNvocc = c.String(maxLength: 14, unicode: false),
                        UltimoPortoEscala = c.String(nullable: false, maxLength: 5, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.BoletimId);
            
            CreateTable(
                "dbo.BoletimDescricao",
                c => new
                    {
                        BoletimDescricaoId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        Item = c.String(maxLength: 11, unicode: false),
                        Origem = c.String(nullable: false, maxLength: 1, unicode: false),
                        Descritivo = c.String(nullable: false, maxLength: 70, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.BoletimDescricaoId);
            
            CreateTable(
                "dbo.BoletimMaster",
                c => new
                    {
                        BoletimMasterId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        NumeroBoletimMaster = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissaoMaster = c.String(nullable: false, maxLength: 5, unicode: false),
                        EmitenteMaster = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissaoMaster = c.String(nullable: false, maxLength: 8, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.BoletimMasterId);
            
            CreateTable(
                "dbo.CargaSolta",
                c => new
                    {
                        CargaSoltaId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        Item = c.String(maxLength: 3, unicode: false),
                        CodigoMercadoria = c.String(nullable: false, maxLength: 8, unicode: false),
                        QuantidadeVolumes = c.String(nullable: false, maxLength: 6, unicode: false),
                        PesoBruto = c.String(nullable: false, maxLength: 12, unicode: false),
                        CodigoEmbalagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 60, unicode: false),
                        ContraMarca = c.String(maxLength: 60, unicode: false),
                        Destino = c.String(maxLength: 7, unicode: false),
                        CodigoImo = c.String(maxLength: 3, unicode: false),
                        CodigoOnu = c.String(maxLength: 4, unicode: false),
                        DDE = c.String(maxLength: 20, unicode: false),
                        RE = c.String(maxLength: 20, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.CargaSoltaId);
            
            CreateTable(
                "dbo.Conteiner",
                c => new
                    {
                        ConteinerId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        Sigla = c.String(nullable: false, maxLength: 11, unicode: false),
                        Tamanho = c.String(nullable: false, maxLength: 2, unicode: false),
                        TipoBasico = c.String(nullable: false, maxLength: 2, unicode: false),
                        Isocode = c.String(maxLength: 4, unicode: false),
                        Tara = c.String(nullable: false, maxLength: 8, unicode: false),
                        Operacao = c.String(nullable: false, maxLength: 8, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.ConteinerId);
            
            CreateTable(
                "dbo.ConteinerCheio",
                c => new
                    {
                        ConteinerCheioId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        SiglaConteiner = c.String(nullable: false, maxLength: 11, unicode: false),
                        Tamanho = c.String(nullable: false, maxLength: 2, unicode: false),
                        TipoBasico = c.String(nullable: false, maxLength: 2, unicode: false),
                        Isocode = c.String(nullable: false, maxLength: 4, unicode: false),
                        Tara = c.String(nullable: false, maxLength: 8, unicode: false),
                        LacreOrigem1 = c.String(nullable: false, maxLength: 15, unicode: false),
                        LacreOrigem2 = c.String(maxLength: 15, unicode: false),
                        LacreOrigem3 = c.String(maxLength: 15, unicode: false),
                        LacreOrigem4 = c.String(maxLength: 15, unicode: false),
                        PesoBruto = c.String(nullable: false, maxLength: 12, unicode: false),
                        RegimeMovimentacao = c.String(nullable: false, maxLength: 2, unicode: false),
                        CodigoDestinoouOrigem = c.String(maxLength: 7, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.ConteinerCheioId);
            
            CreateTable(
                "dbo.Frete",
                c => new
                    {
                        FretelId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(maxLength: 3, unicode: false),
                        CNPJBase = c.String(maxLength: 8, unicode: false),
                        CNPJFilial = c.String(maxLength: 4, unicode: false),
                        CNPJControle = c.String(maxLength: 2, unicode: false),
                        NumeroViagem = c.String(maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(maxLength: 30, unicode: false),
                        PortoEmissao = c.String(maxLength: 5, unicode: false),
                        Emitente = c.String(maxLength: 4, unicode: false),
                        DataEmissao = c.String(maxLength: 8, unicode: false),
                        DescricaoFrete = c.String(maxLength: 30, unicode: false),
                        Moeda = c.String(maxLength: 5, unicode: false),
                        Valor = c.String(maxLength: 9, unicode: false),
                        PrePago = c.String(maxLength: 1, unicode: false),
                        Sequencial = c.String(maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.FretelId);
            
            CreateTable(
                "dbo.Granel",
                c => new
                    {
                        GranelId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 4, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        Item = c.String(maxLength: 3, unicode: false),
                        CodigoMercadoria = c.String(nullable: false, maxLength: 8, unicode: false),
                        PesoBruto = c.String(nullable: false, maxLength: 12, unicode: false),
                        DestinoouOrigem = c.String(maxLength: 7, unicode: false),
                        CodigoIMO = c.String(maxLength: 3, unicode: false),
                        CodigoOnu = c.String(maxLength: 4, unicode: false),
                        DDE = c.String(maxLength: 20, unicode: false),
                        RE = c.String(maxLength: 20, unicode: false),
                        Sequencial = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.GranelId);
            
            CreateTable(
                "dbo.HeaderManifesto",
                c => new
                    {
                        HeaderManifestoId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NomeEmpresa = c.String(nullable: false, maxLength: 60, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroViagemAgencia = c.String(nullable: false, maxLength: 10, unicode: false),
                        DataGravacaoArquivo = c.String(nullable: false, maxLength: 8, unicode: false),
                        HoraArquivo = c.String(nullable: false, maxLength: 6, unicode: false),
                        CNPJBaseDestinatario = c.String(maxLength: 8, unicode: false),
                        CNPJFilialDestinatario = c.String(maxLength: 4, unicode: false),
                        CNPJControleDestinatario = c.String(maxLength: 2, unicode: false),
                        NomeDestinatario = c.String(maxLength: 60, unicode: false),
                        LloydRegister = c.String(maxLength: 8, unicode: false),
                        TipoArquivo = c.String(nullable: false, maxLength: 1, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.HeaderManifestoId);
            
            CreateTable(
                "dbo.IntegrationHistoryErro",
                c => new
                    {
                        IntegrationHistoryErroId = c.Int(nullable: false, identity: true),
                        IntegrationId = c.Int(nullable: false),
                        DtEntrada = c.DateTime(nullable: false),
                        TpErro = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IntegrationHistoryErroId)
                .ForeignKey("dbo.Integration", t => t.IntegrationId)
                .Index(t => t.IntegrationId);
            
            CreateTable(
                "dbo.Integration",
                c => new
                    {
                        IntegrationId = c.Int(nullable: false, identity: true),
                        Entidade = c.String(nullable: false, maxLength: 30, unicode: false),
                        DtEntrada = c.DateTime(nullable: false),
                        XmlRecebido = c.String(nullable: false, maxLength: 8000, unicode: false),
                        XmlAlterado = c.String(maxLength: 8000, unicode: false),
                        Situacao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.IntegrationId);
            
            CreateTable(
                "dbo.LogMessage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Linha = c.Int(nullable: false),
                        NomeEntidade = c.String(maxLength: 100, unicode: false),
                        Data = c.DateTime(nullable: false),
                        Message = c.String(maxLength: 100, unicode: false),
                        MessageSystem = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MercadoriaConteinerizada",
                c => new
                    {
                        MercadoriaConteinerizadaId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        NumeroBoletim = c.String(nullable: false, maxLength: 30, unicode: false),
                        PortoEmissao = c.String(nullable: false, maxLength: 5, unicode: false),
                        Emitente = c.String(nullable: false, maxLength: 4, unicode: false),
                        DataEmissao = c.String(nullable: false, maxLength: 8, unicode: false),
                        Item = c.String(maxLength: 3, unicode: false),
                        CodigoMercadoria = c.String(nullable: false, maxLength: 8, unicode: false),
                        QuantidadeVolume = c.String(nullable: false, maxLength: 6, unicode: false),
                        PesoBruto = c.String(nullable: false, maxLength: 12, unicode: false),
                        CodigoEmbalagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 60, unicode: false),
                        ContraMarca = c.String(maxLength: 60, unicode: false),
                        DestinoouOrigem = c.String(maxLength: 7, unicode: false),
                        SiglaConteiner = c.String(nullable: false, maxLength: 11, unicode: false),
                        CodigoIMO = c.String(maxLength: 3, unicode: false),
                        CodigoOnu = c.String(maxLength: 4, unicode: false),
                        DDE = c.String(maxLength: 20, unicode: false),
                        RE = c.String(maxLength: 20, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.MercadoriaConteinerizadaId);
            
            CreateTable(
                "dbo.Parceiro",
                c => new
                    {
                        ParceiroId = c.Int(nullable: false, identity: true),
                        MercadoriaConteinerizadaId = c.Int(nullable: false),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        CNPJBaseParceiro = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilialParceiro = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControleParceiro = c.String(nullable: false, maxLength: 2, unicode: false),
                        NomeParceiro = c.String(nullable: false, maxLength: 60, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.ParceiroId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 100, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Trailler",
                c => new
                    {
                        TraillerId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        QuantidadeRegistro102 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro103 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro104 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro105 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro106 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro107 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro108 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro109 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro110 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro111 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeRegistro112 = c.String(nullable: false, maxLength: 6, unicode: false),
                        QuantidadeTotalRegistro = c.String(nullable: false, maxLength: 6, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.TraillerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 100, unicode: false),
                        SecurityStamp = c.String(maxLength: 100, unicode: false),
                        PhoneNumber = c.String(maxLength: 100, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 100, unicode: false),
                        ClaimType = c.String(maxLength: 100, unicode: false),
                        ClaimValue = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 100, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 100, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.IntegrationHistoryErro", "IntegrationId", "dbo.Integration");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.IntegrationHistoryErro", new[] { "IntegrationId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Trailler");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Parceiro");
            DropTable("dbo.MercadoriaConteinerizada");
            DropTable("dbo.LogMessage");
            DropTable("dbo.Integration");
            DropTable("dbo.IntegrationHistoryErro");
            DropTable("dbo.HeaderManifesto");
            DropTable("dbo.Granel");
            DropTable("dbo.Frete");
            DropTable("dbo.ConteinerCheio");
            DropTable("dbo.Conteiner");
            DropTable("dbo.CargaSolta");
            DropTable("dbo.BoletimMaster");
            DropTable("dbo.BoletimDescricao");
            DropTable("dbo.Boletim");
        }
    }
}
