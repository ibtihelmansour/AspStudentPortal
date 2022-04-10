namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ee3 : DbMigration
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
