namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTodoItemCompletedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TodoItems", "CompletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TodoItems", "CompletedDate");
        }
    }
}
