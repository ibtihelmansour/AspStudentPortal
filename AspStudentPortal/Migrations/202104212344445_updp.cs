namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.paymentMethods", "yearFees", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.paymentMethods", "yearFees");
        }
    }
}
