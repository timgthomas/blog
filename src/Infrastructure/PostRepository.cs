using System;
using System.Collections.Generic;
using System.IO;
using Blog.Core.Models;
using Blog.Core.Services;
using MarkdownSharp;
using System.Linq;

namespace Infrastructure
{
	public class PostRepository : IPostRepository
	{
		private readonly Markdown _markdownTransformer;

		private readonly string _rootDirectory;

		public PostRepository(string rootDirectory)
		{
			_rootDirectory = rootDirectory;

			_markdownTransformer = new Markdown();
		}

		public IEnumerable<Post> GetAll()
		{
			return GetStubPosts().Where(p => p.IsActive).OrderByDescending(p => p.Posted);
		}

		public Post GetBySlug(string slug)
		{
			return GetStubPosts().SingleOrDefault(p => string.Equals(p.Slug, slug));
		}

		private IEnumerable<Post> GetStubPosts()
		{
			yield return Transform(new Post
			{
				Title = "Breaking Your Old HTML Habits",
				Slug = "breaking-your-old-html-habits",
				Posted = new DateTime(2011, 07, 01, 14, 51, 24),
				IsActive = true
			});

			yield return Transform(new Post
			{
				Title = "Simple Validation Visuals for Windows Phone 7",
				Slug = "simple-validation-visuals-for-windows-phone-7",
				Posted = new DateTime(2011, 08, 05, 10, 09, 03),
				IsActive = true
			});
		}

		private Post Transform(Post post)
		{
			string fileName = Path.Combine(_rootDirectory, post.Slug + ".md");

			if (!File.Exists(fileName)) return post;

			string fileContents;

			using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
			using (var streamReader = new StreamReader(fileStream))
			{
				fileContents = streamReader.ReadToEnd();
			}

			post.Body = _markdownTransformer.Transform(fileContents);

			return post;
		}
	}
}