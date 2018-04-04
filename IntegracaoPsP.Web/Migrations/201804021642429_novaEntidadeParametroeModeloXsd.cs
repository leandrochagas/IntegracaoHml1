namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novaEntidadeParametroeModeloXsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModeloXsd",
                c => new
                    {
                        ModeloXsdId = c.Int(nullable: false, identity: true),
                        NomeArquivo = c.String(nullable: false, maxLength: 200, unicode: false),
                        Versao = c.String(nullable: false, maxLength: 10, unicode: false),
                        Modelo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        StAtivo = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Usuario = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ModeloXsdId);
            
            CreateTable(
                "dbo.Parametro",
                c => new
                    {
                        ParametroId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                        Valor = c.String(maxLength: 200, unicode: false),
                        StAtivo = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Usuario = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ParametroId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametro");
            DropTable("dbo.ModeloXsd");
        }
    }
}
