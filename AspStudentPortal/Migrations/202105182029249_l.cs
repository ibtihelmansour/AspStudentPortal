namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolBranches", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolBranches", "name");
        }
    }
}
