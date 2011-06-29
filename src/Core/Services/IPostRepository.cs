using System.Collections.Generic;
using Blog.Core.Models;

namespace Blog.Core.Services
{
	public interface IPostRepository
	{
		IEnumerable<Post> GetAll();
		Post GetBySlug(string slug);
	}
}