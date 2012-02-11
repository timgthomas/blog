namespace Blog.Core.Services
{
	public interface IPostContentRepository
	{
		string GetPostBody(string slug);
	}
}