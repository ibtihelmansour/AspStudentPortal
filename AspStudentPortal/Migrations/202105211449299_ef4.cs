namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ef4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SchoolBranches", "level_levelId", "dbo.Levels");
            DropIndex("dbo.SchoolBranches", new[] { "level_levelId" });
            AddColumn("dbo.SchoolBranches", "level", c => c.Int(nullable: false));
            DropColumn("dbo.SchoolBranches", "level_levelId");
            DropTable("dbo.Levels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        levelId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.levelId);
            
            AddColumn("dbo.SchoolBranches", "level_levelId", c => c.Int());
            DropColumn("dbo.SchoolBranches", "level");
            CreateIndex("dbo.SchoolBranches", "level_levelId");
            AddForeignKey("dbo.SchoolBranches", "level_levelId", "dbo.Levels", "levelId");
        }
    }
}
