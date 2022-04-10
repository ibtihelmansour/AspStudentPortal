namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.paymentMethods",
                c => new
                    {
                        MethodName = c.String(nullable: false, maxLength: 128),
                        RegistrationFees = c.Single(nullable: false),
                        partwithMarkup = c.Single(nullable: false),
                        partWithoutMarkup = c.Single(nullable: false),
                        markupPercent = c.Single(nullable: false),
                        collegeYear = c.String(),
                    })
                .PrimaryKey(t => t.MethodName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.paymentMethods");
        }
    }
}
