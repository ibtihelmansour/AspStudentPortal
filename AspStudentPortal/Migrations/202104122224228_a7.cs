namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Enrollments", name: "studentId", newName: "student_Id");
            RenameIndex(table: "dbo.Enrollments", name: "IX_studentId", newName: "IX_student_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Enrollments", name: "IX_student_Id", newName: "IX_studentId");
            RenameColumn(table: "dbo.Enrollments", name: "student_Id", newName: "studentId");
        }
    }
}
