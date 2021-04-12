namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        paymentMethod = c.Int(),
                        dateEnrollment = c.DateTime(),
                        ClasseId = c.Int(nullable: false),
                        student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Classes", t => t.ClasseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.student_Id)
                .Index(t => t.ClasseId)
                .Index(t => t.student_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nameClasse = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "ClasseId", "dbo.Classes");
            DropIndex("dbo.Enrollments", new[] { "student_Id" });
            DropIndex("dbo.Enrollments", new[] { "ClasseId" });
            DropTable("dbo.Classes");
            DropTable("dbo.Enrollments");
        }
    }
}
