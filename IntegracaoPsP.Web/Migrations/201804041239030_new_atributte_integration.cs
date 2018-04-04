namespace IntegracaoPsP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_atributte_integration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integration", "TxtRecebido", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Integration", "TxtAlterado", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integration", "TxtAlterado");
            DropColumn("dbo.Integration", "TxtRecebido");
        }
    }
}
