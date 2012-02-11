using Ninject;

namespace Blog.Web.Initialization
{
	public class NinjectBootstrapper
	{
		public static IKernel Bootstrap()
		{
			return new StandardKernel(new WebModule());
		}
	}
}