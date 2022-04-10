namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ve : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "schoolBranch_idBranch", "dbo.SchoolBranches");
            DropForeignKey("dbo.Courses", "schoolBranch_idBranch", "dbo.SchoolBranches");
            DropIndex("dbo.Classes", new[] { "schoolBranch_idBranch" });
            DropIndex("dbo.Courses", new[] { "schoolBranch_idBranch" });
            RenameColumn(table: "dbo.Classes", name: "schoolBranch_idBranch", newName: "schoolBranch_id");
            RenameColumn(table: "dbo.Courses", name: "schoolBranch_idBranch", newName: "schoolBranch_id");
            DropPrimaryKey("dbo.SchoolBranches");
            AddColumn("dbo.SchoolBranches", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Classes", "schoolBranch_id", c => c.Int());
            AlterColumn("dbo.Courses", "schoolBranch_id", c => c.Int());
            AddPrimaryKey("dbo.SchoolBranches", "id");
            CreateIndex("dbo.Classes", "schoolBranch_id");
            CreateIndex("dbo.Courses", "schoolBranch_id");
            AddForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches", "id");
            AddForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches", "id");
            DropColumn("dbo.SchoolBranches", "idBranch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SchoolBranches", "idBranch", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Courses", "schoolBranch_id", "dbo.SchoolBranches");
            DropForeignKey("dbo.Classes", "schoolBranch_id", "dbo.SchoolBranches");
            DropIndex("dbo.Courses", new[] { "schoolBranch_id" });
            DropIndex("dbo.Classes", new[] { "schoolBranch_id" });
            DropPrimaryKey("dbo.SchoolBranches");
            AlterColumn("dbo.Courses", "schoolBranch_id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Classes", "schoolBranch_id", c => c.String(maxLength: 128));
            DropColumn("dbo.SchoolBranches", "id");
            AddPrimaryKey("dbo.SchoolBranches", "idBranch");
            RenameColumn(table: "dbo.Courses", name: "schoolBranch_id", newName: "schoolBranch_idBranch");
            RenameColumn(table: "dbo.Classes", name: "schoolBranch_id", newName: "schoolBranch_idBranch");
            CreateIndex("dbo.Courses", "schoolBranch_idBranch");
            CreateIndex("dbo.Classes", "schoolBranch_idBranch");
            AddForeignKey("dbo.Courses", "schoolBranch_idBranch", "dbo.SchoolBranches", "idBranch");
            AddForeignKey("dbo.Classes", "schoolBranch_idBranch", "dbo.SchoolBranches", "idBranch");
        }
    }
}
