using System;

using TAL.Core.Manager;
using TAL.Core.Interface;
using TAL.Core.Entity;

namespace TAL.Core.Behavior
{
	public class UserBehavior
	{
		private TinderManager Manager;
		private GenericInterface Interface;

		public UserBehavior (SpecificInterface specificInterface) {
			this.Manager = new TinderManager();
			this.Interface = new GenericInterface (specificInterface);
		}

		public void StartAutoLiking()
		{
			if (!this.Manager.HasNext ()) {
				this.Manager.GetNextProfileListPage ();
			}
			Profile profileJustLiked = this.Manager.LikeNext ();
			int numberOfLikes = this.Manager.GetCurrentNumberOfLikes();
			this.Interface.Render (profileJustLiked, numberOfLikes);
		}


		public void StopAutoLiking()
		{
		}
	}
}

