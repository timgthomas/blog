using System;
using System.Collections.Generic;
using Blog.Core.Models;
using Blog.Core.Services;
using System.Linq;

namespace Infrastructure
{
	public class PostRepository : IPostRepository
	{
		private readonly IPostContentRepository _contentRepository;

		public PostRepository(string rootDirectory)
		{
			_contentRepository = new PostContentRepository(rootDirectory);
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
			var post = new Post
				{
					Title = "Disable \"Track Changes\" in SQL Server Management Studio",
					Posted = new DateTime(2011, 12, 30, 11, 50, 00),
					IsActive = true
				};
			post.Body = _contentRepository.GetPostBody(post.Slug);
			yield return post;

			post = new Post
				{
					Title = "Recreating the CTXNA Button Style in Pure CSS",
					Posted = new DateTime(2011, 10, 2, 16, 40, 00),
					IsActive = true
				};
			post.Body = _contentRepository.GetPostBody(post.Slug);
			yield return post;

			post = new Post
				{
					Title = "Binding to a UserControl's Dependency Property",
					Posted = new DateTime(2011, 09, 30, 11, 09, 00),
					IsActive = true
				};
			post.Body = _contentRepository.GetPostBody(post.Slug);
			yield return post;

			post = new Post
				{
					Title = "Breaking Your Old HTML Habits",
					Posted = new DateTime(2011, 07, 01, 14, 51, 24),
					IsActive = true
				};
			post.Body = _contentRepository.GetPostBody(post.Slug);
			yield return post;

			post = new Post
				{
					Title = "Simple Validation Visuals for Windows Phone 7",
					Posted = new DateTime(2011, 08, 05, 10, 09, 03),
					IsActive = true
				};
			post.Body = _contentRepository.GetPostBody(post.Slug);
			yield return post;
		}
	}
}