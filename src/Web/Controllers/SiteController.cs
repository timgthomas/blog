using System.Web.Mvc;
using Blog.Core.Services;
using Infrastructure;

namespace Blog.Web.Controllers
{
	public class SiteController : Controller
	{
		private IPostRepository _posts;

		public ViewResult Index()
		{
			_posts = new PostRepository(HttpContext.Server.MapPath("~/Content/posts"));
			return View(_posts.GetAll());
		}
	}
}