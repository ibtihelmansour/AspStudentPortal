namespace AspStudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        subject = c.Int(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Demands");
        }
    }
}
