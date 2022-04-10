namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "student_Id" });
            AlterColumn("dbo.Enrollments", "student_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Enrollments", "student_Id");
            AddForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "student_Id" });
            AlterColumn("dbo.Enrollments", "student_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", "student_Id");
            AddForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
