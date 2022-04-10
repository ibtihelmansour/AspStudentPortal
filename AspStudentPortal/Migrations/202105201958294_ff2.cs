namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "classe_id", "dbo.Classes");
            DropIndex("dbo.AspNetUsers", new[] { "classe_id" });
            DropColumn("dbo.AspNetUsers", "classe_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "classe_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "classe_id");
            AddForeignKey("dbo.AspNetUsers", "classe_id", "dbo.Classes", "id");
        }
    }
}
