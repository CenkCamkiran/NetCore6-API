﻿using Models.ControllerModels;

namespace ServiceLayer.Interfaces
{
	public interface IPostsService
	{
		public IEnumerable<Posts> GetTopPostsCache(string key);
		public void SetTopPostsCache(string key, string data, TimeSpan ttl);
		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts();
	}
}
