namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ee2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches");
            DropForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranchId" });
            DropIndex("dbo.Courses", new[] { "schoolBranch_id" });
            RenameColumn(table: "dbo.Courses", name: "schoolBranch_id", newName: "schoolBranch_idBranch");
            DropPrimaryKey("dbo.SchoolBranches");
            AddColumn("dbo.Classes", "schoolBranch_idBranch", c => c.String(maxLength: 128));
            AddColumn("dbo.SchoolBranches", "idBranch", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.String());
            AlterColumn("dbo.Courses", "schoolBranch_idBranch", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.SchoolBranches", "idBranch");
            CreateIndex("dbo.Classes", "schoolBranch_idBranch");
            CreateIndex("dbo.Courses", "schoolBranch_idBranch");
            AddForeignKey("dbo.Classes", "schoolBranch_idBranch", "dbo.SchoolBranches", "idBranch");
            AddForeignKey("dbo.Courses", "schoolBranch_idBranch", "dbo.SchoolBranches", "idBranch");
            DropColumn("dbo.SchoolBranches", "id");
            DropColumn("dbo.SchoolBranches", "name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolBranches", "name", c => c.String());
            AddColumn("dbo.SchoolBranches", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Courses", "schoolBranch_idBranch", "dbo.SchoolBranches");
            DropForeignKey("dbo.Classes", "schoolBranch_idBranch", "dbo.SchoolBranches");
            DropIndex("dbo.Courses", new[] { "schoolBranch_idBranch" });
            DropIndex("dbo.Classes", new[] { "schoolBranch_idBranch" });
            DropPrimaryKey("dbo.SchoolBranches");
            AlterColumn("dbo.Courses", "schoolBranch_idBranch", c => c.Int());
            AlterColumn("dbo.Classes", "schoolBranchId", c => c.Int(nullable: false));
            DropColumn("dbo.SchoolBranches", "idBranch");
            DropColumn("dbo.Classes", "schoolBranch_idBranch");
            AddPrimaryKey("dbo.SchoolBranches", "id");
            RenameColumn(table: "dbo.Courses", name: "schoolBranch_idBranch", newName: "schoolBranch_id");
            CreateIndex("dbo.Courses", "schoolBranch_id");
            CreateIndex("dbo.Classes", "schoolBranchId");
            AddForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches", "id");
            AddForeignKey("dbo.Classes", "schoolBranchId", "dbo.SchoolBranches", "id", cascadeDelete: true);
        }
    }
}
