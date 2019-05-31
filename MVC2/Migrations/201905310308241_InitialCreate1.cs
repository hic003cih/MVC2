namespace MVC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gamer", "RegisteredDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Gamer", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Gamer", "Gender", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gamer", "Gender", c => c.String());
            AlterColumn("dbo.Gamer", "Name", c => c.String());
            DropColumn("dbo.Gamer", "RegisteredDate");
        }
    }
}
