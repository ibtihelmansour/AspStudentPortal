namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ve1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranch_id" });
            DropColumn("dbo.Classes", "schoolBranchId");
            RenameColumn(table: "dbo.Classes", name: "schoolBranch_id", newName: "schoolBranchId");
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int(nullable: false));
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "schoolBranchId");
            AddForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranchId" });
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int());
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.String());
            RenameColumn(table: "dbo.Classes", name: "schoolBranchId", newName: "schoolBranch_id");
            AddColumn("dbo.Classes", "schoolBranchId", c => c.String());
            CreateIndex("dbo.Classes", "schoolBranch_id");
            AddForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches", "id");
        }
    }
}
