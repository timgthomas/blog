using System;
using System.Collections.Generic;
using Blog.Core.Models;
using Blog.Core.Services;
using MarkdownSharp;

namespace Infrastructure
{
	public class PostRepository : IPostRepository
	{
		public IEnumerable<Post> GetAll()
		{
			yield return new Post
				{
					Title = "A Sample Post",
					Slug = "a-sample-post",
					Posted = DateTime.Now,
					Body = "<p>This is a sample post.</p>"
				};

			yield return new Post
				{
					Title = "A Blog Post of Some Interest",
					Slug = "a-blog-post-of-some-interest",
					Posted = DateTime.Now,
					Body = new Markdown().Transform(@"
This is a blog post of some interest.

	public class Foo : IFoo
	{
		public void Bar(decimal baz, decimal qux)
		{
			return (baz * qux) / 13.37m;
		}
	}

This is code:

	<!doctype>
	
	<html lang=en>
		<p>This is HTML.</p>
	</html>

This has been a blog post of some interest.")
				};
		}
	}
}