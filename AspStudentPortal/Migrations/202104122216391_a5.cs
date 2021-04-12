namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Enrollments", name: "student_Id", newName: "studentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_student_Id", newName: "IX_studentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Enrollments", name: "IX_studentId", newName: "IX_student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "studentId", newName: "student_Id");
        }
    }
}
