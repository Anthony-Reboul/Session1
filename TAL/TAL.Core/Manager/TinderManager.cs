using System;
using System.Collections.Generic;
using TAL.Core.Entity;

namespace TAL.Core.Manager
{
	public class TinderManager
	{
		private List<Profile> Profiles;
		private int CurrentIndex;
		private User CurrentUser;

		public TinderManager ()
		{
			CurrentIndex = 0;
		}

		public void GetPaginatedProfileList ()
		{

		}

		/**
		 * Return the profile just liked
		 */
		public Profile LikeNext()
		{
			if (this.CurrentIndex < this.Profiles.Count) {
				this.CurrentIndex++;
				this.CurrentUser.IncrementNumberOfLikes ();
			}
			return new Profile ();
		}

		public int GetCurrentNumberOfLikes()
		{
			return this.CurrentUser.GetNumberOfLikes();
		}
	}
}

