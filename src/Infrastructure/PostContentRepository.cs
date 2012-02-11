using System.IO;
using Blog.Core.Services;
using MarkdownSharp;

namespace Infrastructure
{
	public class PostContentRepository : IPostContentRepository
	{
		private readonly string _rootDirectory;
		private readonly Markdown _markdownTransformer;

		public PostContentRepository(string rootDirectory)
		{
			_rootDirectory = rootDirectory;
			_markdownTransformer = new Markdown();
		}

		public string GetPostBody(string slug)
		{
			string fileName = Path.Combine(_rootDirectory, slug + ".md");

			if (!File.Exists(fileName)) return string.Empty;

			string fileContents;

			using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
			using (var streamReader = new StreamReader(fileStream))
			{
				fileContents = streamReader.ReadToEnd();
			}

			return _markdownTransformer.Transform(fileContents);
		}
	}
}