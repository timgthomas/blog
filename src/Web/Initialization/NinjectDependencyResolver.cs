using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace Blog.Web.Initialization
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private readonly IKernel _kernel;

		public NinjectDependencyResolver(IKernel kernel)
		{
			_kernel = kernel;
		}

		public object GetService(Type serviceType)
		{
			if (serviceType == null) return null;

			try
			{
				return serviceType.IsAbstract || serviceType.IsInterface
					? _kernel.TryGet(serviceType)
					: _kernel.Get(serviceType);
			}
			catch
			{
				return null;
			}
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return _kernel.GetAll(serviceType);
		}
	}
}