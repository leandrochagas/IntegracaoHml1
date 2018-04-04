namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcampoLogMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogMessage", "NomeArquivo", c => c.String(maxLength: 40, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogMessage", "NomeArquivo");
        }
    }
}
