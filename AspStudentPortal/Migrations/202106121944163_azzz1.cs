namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azzz1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Course_id", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "Course_id" });
            AddColumn("dbo.ObjFiles", "course_id", c => c.Int());
            CreateIndex("dbo.ObjFiles", "course_id");
            AddForeignKey("dbo.ObjFiles", "course_id", "dbo.Courses", "id");
            DropColumn("dbo.Courses", "Course_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Course_id", c => c.Int());
            DropForeignKey("dbo.ObjFiles", "course_id", "dbo.Courses");
            DropIndex("dbo.ObjFiles", new[] { "course_id" });
            DropColumn("dbo.ObjFiles", "course_id");
            CreateIndex("dbo.Courses", "Course_id");
            AddForeignKey("dbo.Courses", "Course_id", "dbo.Courses", "id");
        }
    }
}
