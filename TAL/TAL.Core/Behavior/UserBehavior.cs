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
		//private Timer aTimer;

		public void StartAutoLiking()
		{
			Profile profileJustLiked = this.Manager.LikeNext ();
			int numberOfLikes = this.Manager.GetCurrentNumberOfLikes();
			this.Interface.Render (profileJustLiked, numberOfLikes);
		}


		public void StopAutoLiking()
		{
		}
	}
}

