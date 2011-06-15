using System.Web.Mvc;

namespace Blog.Web.Controllers
{
	public class SiteController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}
	}
}