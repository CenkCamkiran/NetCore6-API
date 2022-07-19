using Models.ControllerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MongoDB.Interfaces
{
	public interface IPostsRepository
	{
		public IEnumerable<Models.DataAccessLayerModels.Posts> GetTopPosts();
	}
}
