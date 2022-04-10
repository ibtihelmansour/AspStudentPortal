namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Levels", "niveau", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Levels", "niveau");
        }
    }
}
