using System.Web.Mvc;
using Blog.Core.Services;

namespace Blog.Web.Controllers
{
	public class SiteController : Controller
	{
		private readonly IPostRepository _postRepository;

		public SiteController(IPostRepository postRepository)
		{
			_postRepository = postRepository;
		}

		public ViewResult Index()
		{
			return View(_postRepository.GetAll());
		}

		public ViewResult Post(string slug)
		{
			return View(_postRepository.GetBySlug(slug));
		}

		public ViewResult Rss()
		{
			Response.ContentType = "application/rss+xml";
			return View(_postRepository.GetAll());
		}
	}
}