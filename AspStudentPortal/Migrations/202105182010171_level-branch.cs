namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class levelbranch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        levelId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.levelId);
            
            CreateTable(
                "dbo.SchoolBranches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        level_levelId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Levels", t => t.level_levelId)
                .Index(t => t.level_levelId);
            
            AddColumn("dbo.AspNetUsers", "Classe_id", c => c.Int());
            AddColumn("dbo.Classes", "classe_id", c => c.Int());
            AddColumn("dbo.Classes", "SchoolBranch_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Classe_id");
            CreateIndex("dbo.Classes", "classe_id");
            CreateIndex("dbo.Classes", "SchoolBranch_id");
            AddForeignKey("dbo.Classes", "classe_id", "dbo.Classes", "id");
            AddForeignKey("dbo.AspNetUsers", "Classe_id", "dbo.Classes", "id");
            AddForeignKey("dbo.Classes", "SchoolBranch_id", "dbo.SchoolBranches", "id");
            DropTable("dbo.paymentMethods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.paymentMethods",
                c => new
                    {
                        MethodName = c.String(nullable: false, maxLength: 128),
                        yearFees = c.Single(nullable: false),
                        RegistrationFees = c.Single(nullable: false),
                        partwithMarkup = c.Single(nullable: false),
                        partWithoutMarkup = c.Single(nullable: false),
                        markupPercent = c.Single(nullable: false),
                        collegeYear = c.String(),
                    })
                .PrimaryKey(t => t.MethodName);
            
            DropForeignKey("dbo.SchoolBranches", "level_levelId", "dbo.Levels");
            DropForeignKey("dbo.Classes", "SchoolBranch_id", "dbo.SchoolBranches");
            DropForeignKey("dbo.AspNetUsers", "Classe_id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "classe_id", "dbo.Classes");
            DropIndex("dbo.SchoolBranches", new[] { "level_levelId" });
            DropIndex("dbo.Classes", new[] { "SchoolBranch_id" });
            DropIndex("dbo.Classes", new[] { "classe_id" });
            DropIndex("dbo.AspNetUsers", new[] { "Classe_id" });
            DropColumn("dbo.Classes", "SchoolBranch_id");
            DropColumn("dbo.Classes", "classe_id");
            DropColumn("dbo.AspNetUsers", "Classe_id");
            DropTable("dbo.SchoolBranches");
            DropTable("dbo.Levels");
        }
    }
}
