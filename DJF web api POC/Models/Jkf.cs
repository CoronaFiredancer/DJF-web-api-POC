using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
	public class Jkf
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		//foreign keys
		public Guid AssociationGuid { get; set; }
		public Guid RegionGuid { get; set; }

		//navigation properties
		public Association Association { get; set; }
		public Region Region { get; set; }
	}
}