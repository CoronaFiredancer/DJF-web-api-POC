using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
	public class Member
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public ICollection<Association> AssociationMemberships { get; set; }

		public Member()
		{
			AssociationMemberships = new List<Association>();
		}
	}
}