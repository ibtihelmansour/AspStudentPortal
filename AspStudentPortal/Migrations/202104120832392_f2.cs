namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "salary", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "salary");
        }
    }
}
