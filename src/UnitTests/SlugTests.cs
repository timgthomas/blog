using Blog.Core.Models;
using NUnit.Framework;
using Should;

namespace Blog.UnitTests
{
	[TestFixture]
	public class SlugTests
	{
		[Test]
		public void Should_slugify_a_basic_string()
		{
			var post = new Post { Title = "A Sample Post" };
			post.Slug.ShouldEqual("a-sample-post");
		}

		[Test]
		public void Should_slugify_quotation_marks()
		{
			var post = new Post { Title = "A \"Sample\" Post" };
			post.Slug.ShouldEqual("a-sample-post");
		}

		[Test]
		public void Should_slugify_apostrophes()
		{
			var post = new Post { Title = "A Sample's Post" };
			post.Slug.ShouldEqual("a-samples-post");
		}
	}
}