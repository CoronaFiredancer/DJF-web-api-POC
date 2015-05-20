using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DJF_web_api_POC.Models;

namespace DJF_web_api_POC.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<DJF_web_api_POCContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(DJF_web_api_POCContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			//context.Members.AddOrUpdate(x => x.Id,
			//	new Member
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "Kai",
			//		LastName = "Kyndesgaard"
			//	},
			//	new Member
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "Kristoffer",
			//		LastName = "Piil"
			//	},
			//	new Member
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "Anders",
			//		LastName = "Jensen"
			//	},
			//	new Member
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "Daniel",
			//		LastName = "Toft"
			//	},
			//	new Member
			//	{
			//		Id = Guid.NewGuid(),
			//		FirstName = "Morten",
			//		LastName = "Kristensen"
			//	}
			//);

			//context.Associations.AddOrUpdate(x => x.Id,
			//	new Association
			//	{
			//		Id = Guid.NewGuid(),
			//		AssociationName = "Klamphuggerne",
					
			//	},
			//	new Association
			//	{
			//		Id = Guid.NewGuid(),
			//		AssociationName = "Fedtspillerne",
					
			//	}
			//	);

			context.AssociationCommittees.AddOrUpdate(x => x.Id,
				new AssociationCommittee
				{
					Id = Guid.NewGuid(),
					Title = "Dykkerne"
				},
				new AssociationCommittee
				{
					Id = Guid.NewGuid(),
					Title = "Drikkerne"
				}
				);
		}
	}
}
