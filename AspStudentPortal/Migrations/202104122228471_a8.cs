namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Enrollments", name: "student_Id", newName: "studentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_student_Id", newName: "IX_studentId");
            AlterColumn("dbo.Enrollments", "paymentMethod", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "paymentMethod", c => c.String());
            RenameIndex(table: "dbo.Enrollments", name: "IX_studentId", newName: "IX_student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "studentId", newName: "student_Id");
        }
    }
}
