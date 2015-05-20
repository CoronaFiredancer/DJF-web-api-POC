using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
	public class Association
	{
		public Guid Id { get; set; }
		public string AssociationName { get; set; }
		public ICollection<Member> AssociationMembers { get; set; }

		//Foreign key
		//public Guid ChairmanGuid { get; set; }

		//Navigation Property
		//public Member Member { get; set; }

		public Association()
		{
			AssociationMembers = new List<Member>();
		}
	}
}