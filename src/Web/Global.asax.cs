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

			RouteTable.Routes.MapRoute("Default", "", new { controller = "Site", action = "Index" });
			RouteTable.Routes.MapRoute("Rss", "rss", new { controller = "Site", action = "Rss" });
			RouteTable.Routes.MapRoute("Post", "{slug}", new { controller = "Site", action = "Post" });
		}

		protected void Application_Error()
		{
			Session["last-error"] = Server.GetLastError();
		}
	}
}