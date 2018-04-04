namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_atributte_integration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Integration", "XmlRecebido", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Integration", "XmlRecebido", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
