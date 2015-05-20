using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
	public class AssociationCommittee
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public ICollection<Member> CommitteeMembers { get; set; }
		public ICollection<Association> CommitteeAssociations { get; set; }

		//Foregin keys, needed or taken care of by EF via the collections?
		public Guid MemberGuid { get; set; }
		public Guid AssociationGuid { get; set; }

		//Navigation properties
		//public Member Member { get; set; }
		//public Association Association { get; set; }

		public AssociationCommittee()
		{
			CommitteeMembers = new List<Member>();
			CommitteeAssociations = new List<Association>();
		}
	}
}