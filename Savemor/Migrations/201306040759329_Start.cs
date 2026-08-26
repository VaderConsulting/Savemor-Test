namespace Savemor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Parent = c.Int(nullable: false),
                        Headline = c.String(),
                        Image = c.String(),
                        Saving = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        CustomString1 = c.String(),
                        CustomString2 = c.String(),
                        CustomString3 = c.String(),
                        CustomString4 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            //DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Category",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Parent = c.Int(nullable: false),
            //            Headline = c.String(),
            //            Image = c.String(),
            //            Saving = c.Int(nullable: false),
            //            SortOrder = c.Int(nullable: false),
            //            CustomString1 = c.String(),
            //            CustomString2 = c.String(),
            //            CustomString3 = c.String(),
            //            CustomString4 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Category");
        }
    }
}
