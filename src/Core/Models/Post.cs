using System;

namespace Blog.Core.Models
{
	public class Post
	{
		public string Title { get; set; }
		public string Slug { get { return GetSlug(); } }
		public DateTime Posted { get; set; }
		public string Body { get; set; }
		public bool IsActive { get; set; }

		private string GetSlug()
		{
			return Title
				.Replace(' ', '-')
				.Replace("\"", "")
				.Replace("'", "")
				.Replace(".", "")
				.ToLower();
		}
	}
}