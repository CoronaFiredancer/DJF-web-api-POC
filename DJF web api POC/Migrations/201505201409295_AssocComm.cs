namespace DJF_web_api_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssocComm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssociationCommittees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Associations", "AssociationCommittee_Id", c => c.Guid());
            AddColumn("dbo.Members", "AssociationCommittee_Id", c => c.Guid());
            CreateIndex("dbo.Associations", "AssociationCommittee_Id");
            CreateIndex("dbo.Members", "AssociationCommittee_Id");
            AddForeignKey("dbo.Associations", "AssociationCommittee_Id", "dbo.AssociationCommittees", "Id");
            AddForeignKey("dbo.Members", "AssociationCommittee_Id", "dbo.AssociationCommittees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "AssociationCommittee_Id", "dbo.AssociationCommittees");
            DropForeignKey("dbo.Associations", "AssociationCommittee_Id", "dbo.AssociationCommittees");
            DropIndex("dbo.Members", new[] { "AssociationCommittee_Id" });
            DropIndex("dbo.Associations", new[] { "AssociationCommittee_Id" });
            DropColumn("dbo.Members", "AssociationCommittee_Id");
            DropColumn("dbo.Associations", "AssociationCommittee_Id");
            DropTable("dbo.AssociationCommittees");
        }
    }
}
