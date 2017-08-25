namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTodoItemOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "OwnerId", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "OwnerId");
        }
    }
}
