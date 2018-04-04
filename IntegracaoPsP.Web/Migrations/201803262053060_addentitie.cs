namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentitie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PortodeEscala",
                c => new
                    {
                        PortodeEscalaId = c.Int(nullable: false, identity: true),
                        Identificador = c.String(nullable: false, maxLength: 3, unicode: false),
                        CNPJBase = c.String(nullable: false, maxLength: 8, unicode: false),
                        CNPJFilial = c.String(nullable: false, maxLength: 4, unicode: false),
                        CNPJControle = c.String(nullable: false, maxLength: 2, unicode: false),
                        NumeroViagem = c.String(nullable: false, maxLength: 10, unicode: false),
                        CodigoPortodeEscala = c.String(nullable: false, maxLength: 5, unicode: false),
                        PrimeiroPorto = c.String(nullable: false, maxLength: 1, unicode: false),
                        DataEntrada = c.String(nullable: false, maxLength: 8, unicode: false),
                        DataSaida = c.String(nullable: false, maxLength: 8, unicode: false),
                        Quantidade = c.String(maxLength: 4, unicode: false),
                        Sequencial = c.String(nullable: false, maxLength: 6, unicode: false),
                    })
                .PrimaryKey(t => t.PortodeEscalaId);
            
            AddColumn("dbo.Integration", "NomeArquivo", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.Integration", "DtProcessamento", c => c.DateTime());
            AlterColumn("dbo.Frete", "Valor", c => c.String(maxLength: 12, unicode: false));
            AlterColumn("dbo.Granel", "PortoEmissao", c => c.String(nullable: false, maxLength: 5, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Granel", "PortoEmissao", c => c.String(nullable: false, maxLength: 4, unicode: false));
            AlterColumn("dbo.Frete", "Valor", c => c.String(maxLength: 9, unicode: false));
            DropColumn("dbo.Integration", "DtProcessamento");
            DropColumn("dbo.Integration", "NomeArquivo");
            DropTable("dbo.PortodeEscala");
        }
    }
}
