namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class level : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "classe_id", "dbo.Classes");
            DropIndex("dbo.Classes", new[] { "classe_id" });
            DropIndex("dbo.Classes", new[] { "SchoolBranch_id" });
            CreateIndex("dbo.Classes", "schoolBranch_id");
            DropColumn("dbo.Classes", "classe_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "classe_id", c => c.Int());
            DropIndex("dbo.Classes", new[] { "schoolBranch_id" });
            CreateIndex("dbo.Classes", "SchoolBranch_id");
            CreateIndex("dbo.Classes", "classe_id");
            AddForeignKey("dbo.Classes", "classe_id", "dbo.Classes", "id");
        }
    }
}
