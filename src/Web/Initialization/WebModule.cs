using System.Web;
using Blog.Core.Services;
using Infrastructure;
using Ninject.Modules;

namespace Blog.Web.Initialization
{
	public class WebModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IPostRepository>().To<PostRepository>();
			Bind<IPostContentRepository>().To<PostContentRepository>()
				.WithConstructorArgument("rootDirectory", context => HttpContext.Current.Server.MapPath("~/Content/posts"));
		}
	}
}