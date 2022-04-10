namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Enrollments", "paymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "paymentMethod", c => c.Int());
        }
    }
}
