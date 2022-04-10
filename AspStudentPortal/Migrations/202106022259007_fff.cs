namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Course_id", c => c.Int());
            CreateIndex("dbo.Courses", "Course_id");
            AddForeignKey("dbo.Courses", "Course_id", "dbo.Courses", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Course_id", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "Course_id" });
            DropColumn("dbo.Courses", "Course_id");
        }
    }
}
