namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "salary", c => c.Single());
        }
    }
}
