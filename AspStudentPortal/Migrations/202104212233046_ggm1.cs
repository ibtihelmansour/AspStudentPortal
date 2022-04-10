namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggm1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes");
            DropForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "classe_id" });
            DropIndex("dbo.Enrollments", new[] { "student_Id" });
            RenameColumn(table: "dbo.Enrollments", name: "classe_id", newName: "ClasseId");
            RenameColumn(table: "dbo.Enrollments", name: "student_Id", newName: "studentId");
            AlterColumn("dbo.Enrollments", "ClasseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "studentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", "ClasseId");
            CreateIndex("dbo.Enrollments", "studentId");
            AddForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "studentId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "studentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "studentId" });
            DropIndex("dbo.Enrollments", new[] { "ClasseId" });
            AlterColumn("dbo.Enrollments", "studentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Enrollments", "ClasseId", c => c.Int());
            RenameColumn(table: "dbo.Enrollments", name: "studentId", newName: "student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "ClasseId", newName: "classe_id");
            CreateIndex("dbo.Enrollments", "student_Id");
            CreateIndex("dbo.Enrollments", "classe_id");
            AddForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "classe_id", "dbo.Classes", "id");
        }
    }
}
