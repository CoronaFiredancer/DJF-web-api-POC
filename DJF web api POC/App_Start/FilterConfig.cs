using System.Web;
using System.Web.Mvc;

namespace DJF_web_api_POC
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
