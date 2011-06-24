using System;

namespace Blog.Core.Models
{
	public class Post
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public DateTime Posted { get; set; }
		public string Body { get; set; }
	}
}