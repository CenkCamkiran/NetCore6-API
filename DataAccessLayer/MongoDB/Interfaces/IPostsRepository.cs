namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IPostsRepository
	{
		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts();
	}
}
