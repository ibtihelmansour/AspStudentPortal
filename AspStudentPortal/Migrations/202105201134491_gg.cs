namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Enrollments", new[] { "schoolBranch_id" });
            DropColumn("dbo.Enrollments", "schoolBranch_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "schoolBranch_id", c => c.Int());
            CreateIndex("dbo.Enrollments", "schoolBranch_id");
            AddForeignKey("dbo.Enrollments", "schoolBranch_id", "dbo.SchoolBranches", "id");
        }
    }
}
