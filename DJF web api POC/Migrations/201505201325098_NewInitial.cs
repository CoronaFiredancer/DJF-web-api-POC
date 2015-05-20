namespace DJF_web_api_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Associations", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Association_Id", "dbo.Associations");
            DropForeignKey("dbo.Associations", "Member_Id1", "dbo.Members");
            DropIndex("dbo.Associations", new[] { "Member_Id" });
            DropIndex("dbo.Associations", new[] { "Member_Id1" });
            DropIndex("dbo.Members", new[] { "Association_Id" });
            CreateTable(
                "dbo.MemberAssociations",
                c => new
                    {
                        Member_Id = c.Guid(nullable: false),
                        Association_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_Id, t.Association_Id })
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("dbo.Associations", t => t.Association_Id, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.Association_Id);
            
            DropColumn("dbo.Associations", "ChairmanGuid");
            DropColumn("dbo.Associations", "Member_Id");
            DropColumn("dbo.Associations", "Member_Id1");
            DropColumn("dbo.Members", "Association_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Association_Id", c => c.Guid());
            AddColumn("dbo.Associations", "Member_Id1", c => c.Guid());
            AddColumn("dbo.Associations", "Member_Id", c => c.Guid());
            AddColumn("dbo.Associations", "ChairmanGuid", c => c.Guid(nullable: false));
            DropForeignKey("dbo.MemberAssociations", "Association_Id", "dbo.Associations");
            DropForeignKey("dbo.MemberAssociations", "Member_Id", "dbo.Members");
            DropIndex("dbo.MemberAssociations", new[] { "Association_Id" });
            DropIndex("dbo.MemberAssociations", new[] { "Member_Id" });
            DropTable("dbo.MemberAssociations");
            CreateIndex("dbo.Members", "Association_Id");
            CreateIndex("dbo.Associations", "Member_Id1");
            CreateIndex("dbo.Associations", "Member_Id");
            AddForeignKey("dbo.Associations", "Member_Id1", "dbo.Members", "Id");
            AddForeignKey("dbo.Members", "Association_Id", "dbo.Associations", "Id");
            AddForeignKey("dbo.Associations", "Member_Id", "dbo.Members", "Id");
        }
    }
}
