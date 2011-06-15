using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalFilters.Filters.Add(new HandleErrorAttribute());

			RouteTable.Routes.MapRoute("Default", "{action}", new { controller = "Site", action = "Index" });
		}
	}
}