namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreundues : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TodoItems", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TodoItems", "UserId", c => c.String());
        }
    }
}
