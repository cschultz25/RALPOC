namespace Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupIdExtensions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Examples", "GroupId", c => c.String());
            AddColumn("dbo.TodoItems", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "UserId");
            DropColumn("dbo.Examples", "GroupId");
        }
    }
}
