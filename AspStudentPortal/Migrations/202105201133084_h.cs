namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Classe_id" });
            AddColumn("dbo.Enrollments", "classe_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "classe_id");
            CreateIndex("dbo.Enrollments", "classe_id");
            AddForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "classe_id" });
            DropIndex("dbo.AspNetUsers", new[] { "classe_id" });
            DropColumn("dbo.Enrollments", "classe_id");
            CreateIndex("dbo.AspNetUsers", "Classe_id");
        }
    }
}
