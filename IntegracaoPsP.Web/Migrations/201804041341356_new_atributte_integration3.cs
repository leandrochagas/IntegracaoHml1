namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_atributte_integration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntegrationHistoric",
                c => new
                    {
                        IntegrationHistoricId = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(maxLength: 60, unicode: false),
                        Entidade = c.String(maxLength: 100, unicode: false),
                        DataEnvio = c.DateTime(nullable: false),
                        Ip = c.String(maxLength: 20, unicode: false),
                        QtdeRegistros = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntegrationHistoricId);
            
            AddColumn("dbo.Integration", "QtdeRegistros", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integration", "QtdeRegistros");
            DropTable("dbo.IntegrationHistoric");
        }
    }
}
