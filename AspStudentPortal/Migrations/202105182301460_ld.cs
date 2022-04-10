namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ld : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Levels", "name", c => c.String());
            DropColumn("dbo.Levels", "niveau");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Levels", "niveau", c => c.String());
            DropColumn("dbo.Levels", "name");
        }
    }
}
