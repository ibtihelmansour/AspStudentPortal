namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "ClasseId" });
            RenameColumn(table: "dbo.Enrollments", name: "ClasseId", newName: "classe_id");
            AlterColumn("dbo.Enrollments", "classe_id", c => c.Int());
            CreateIndex("dbo.Enrollments", "classe_id");
            AddForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "classe_id" });
            AlterColumn("dbo.Enrollments", "classe_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrollments", name: "classe_id", newName: "ClasseId");
            CreateIndex("dbo.Enrollments", "ClasseId");
            AddForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes", "id", cascadeDelete: true);
        }
    }
}
