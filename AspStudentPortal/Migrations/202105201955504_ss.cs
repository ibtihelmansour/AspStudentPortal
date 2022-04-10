namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "classe_id" });
            RenameColumn(table: "dbo.Enrollments", name: "classe_id", newName: "ClasseId");
            AlterColumn("dbo.Enrollments", "ClasseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "ClasseId");
            AddForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "ClasseId" });
            AlterColumn("dbo.Enrollments", "ClasseId", c => c.Int());
            RenameColumn(table: "dbo.Enrollments", name: "ClasseId", newName: "classe_id");
            CreateIndex("dbo.Enrollments", "classe_id");
            AddForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes", "id");
        }
    }
}
