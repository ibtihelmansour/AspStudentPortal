namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranch_id" });
            RenameColumn(table: "dbo.Classes", name: "schoolBranch_id", newName: "schoolBranchId");
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Classes", "schoolBranchId");
            AddForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranchId" });
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int());
            RenameColumn(table: "dbo.Classes", name: "schoolBranchId", newName: "schoolBranch_id");
            CreateIndex("dbo.Classes", "schoolBranch_id");
            AddForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches", "id");
        }
    }
}
