namespace DJF_web_api_POC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssocCommGuids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssociationCommittees", "MemberGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.AssociationCommittees", "AssociationGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssociationCommittees", "AssociationGuid");
            DropColumn("dbo.AssociationCommittees", "MemberGuid");
        }
    }
}
