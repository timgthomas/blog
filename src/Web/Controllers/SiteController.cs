using System.Web.Mvc;
using Blog.Core.Services;
using Infrastructure;

namespace Blog.Web.Controllers
{
	public class SiteController : Controller
	{
		private IPostRepository _posts;

		private IPostRepository Posts
		{
			get { return _posts ?? (_posts = new PostRepository(HttpContext.Server.MapPath("~/Content/posts"))); }
		}

		public ViewResult Index()
		{
			return View(Posts.GetAll());
		}

		public ViewResult Post(string slug)
		{
			return View(Posts.GetBySlug(slug));
		}
	}
}