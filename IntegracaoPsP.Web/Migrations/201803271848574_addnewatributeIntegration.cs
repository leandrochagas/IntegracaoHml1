namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewatributeIntegration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integration", "DtRetorno", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integration", "DtRetorno");
        }
    }
}
