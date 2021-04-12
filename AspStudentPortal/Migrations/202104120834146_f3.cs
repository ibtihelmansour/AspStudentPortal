namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "salary", newName: "salary1");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "salary1", newName: "salary");
        }
    }
}
