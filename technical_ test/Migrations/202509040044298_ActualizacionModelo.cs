namespace technical__test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionModelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "GuidCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "GuidCode");
        }
    }
}
