namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "instructor_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "instructor_Id");
            AddForeignKey("dbo.Courses", "instructor_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "instructor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "instructor_Id" });
            DropColumn("dbo.Courses", "instructor_Id");
        }
    }
}
