using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
	public class Region
	{
		public Guid Id { get; set; }
		public string RegionName { get; set; }


		//foreign key
		public Guid JkfGuid { get; set; }

		//navigation property
		public Jkf Jkf { get; set; }
	}
}