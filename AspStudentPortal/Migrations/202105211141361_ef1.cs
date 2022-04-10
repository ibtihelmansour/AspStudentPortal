namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ef1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranchId" });
            RenameColumn(table: "dbo.Classes", name: "schoolBranchId", newName: "schoolBranch_id");
            AlterColumn("dbo.Classes", "schoolBranch_id", c => c.Int());
            CreateIndex("dbo.Classes", "schoolBranch_id");
            AddForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranch_id" });
            AlterColumn("dbo.Classes", "schoolBranch_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Classes", name: "schoolBranch_id", newName: "schoolBranchId");
            CreateIndex("dbo.Classes", "schoolBranchId");
            AddForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches", "id", cascadeDelete: true);
        }
    }
}
