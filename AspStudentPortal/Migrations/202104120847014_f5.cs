namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f5 : DbMigration
    {
        public override void Up()
        {
          //  DropColumn("dbo.AspNetUsers", "salary");
            RenameColumn(table: "dbo.AspNetUsers", name: "salary1", newName: "salary");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "salary", newName: "salary1");
            AddColumn("dbo.AspNetUsers", "salary", c => c.Single());
        }
    }
}
