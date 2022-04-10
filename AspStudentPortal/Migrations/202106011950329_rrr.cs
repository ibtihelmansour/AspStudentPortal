namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rrr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Courses", new[] { "schoolBranch_id" });
            RenameColumn(table: "dbo.Courses", name: "schoolBranch_id", newName: "SchoolBranchId");
            RenameColumn(table: "dbo.Courses", name: "instructor_Id", newName: "instructorId");
            RenameIndex(table: "dbo.Courses", name: "IX_instructor_Id", newName: "IX_instructorId");
            AlterColumn("dbo.Courses", "SchoolBranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "SchoolBranchId");
            AddForeignKey("dbo.Courses", "SchoolBranchId", "dbo.SchoolBranches", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "SchoolBranchId", "dbo.SchoolBranches");
            DropIndex("dbo.Courses", new[] { "SchoolBranchId" });
            AlterColumn("dbo.Courses", "SchoolBranchId", c => c.Int());
            RenameIndex(table: "dbo.Courses", name: "IX_instructorId", newName: "IX_instructor_Id");
            RenameColumn(table: "dbo.Courses", name: "instructorId", newName: "instructor_Id");
            RenameColumn(table: "dbo.Courses", name: "SchoolBranchId", newName: "schoolBranch_id");
            CreateIndex("dbo.Courses", "schoolBranch_id");
            AddForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches", "id");
        }
    }
}
