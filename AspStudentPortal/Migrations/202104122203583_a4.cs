namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "paymentMethod", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "paymentMethod", c => c.Int());
        }
    }
}
