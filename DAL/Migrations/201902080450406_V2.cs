namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentCode = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        WorkingArea = c.String(nullable: false, maxLength: 50, unicode: false),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Phone = c.String(nullable: false, maxLength: 15, unicode: false),
                        Country = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.AgentCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agents");
        }
    }
}
