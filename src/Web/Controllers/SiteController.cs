using System.Web.Mvc;
using Blog.Core.Services;
using Infrastructure;

namespace Blog.Web.Controllers
{
	public class SiteController : Controller
	{
		private readonly IPostRepository _posts;

		public SiteController()
		{
			_posts = new PostRepository();
		}

		public ViewResult Index()
		{
			return View(_posts.GetAll());
		}
	}
}