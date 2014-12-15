using System;
using System.Collections.Generic;
using TAL.Core.Entity;
using TAL.Core.API;
using TAL.Core.Builder;

namespace TAL.Core.Manager
{
	public class TinderManager
	{
		private List<Profile> Profiles;
		private int CurrentIndex;
		private User CurrentUser;
		private TinderAPIClient TinderAPIClient;

		public TinderManager ()
		{
			this.CurrentIndex = 0;
		}

		public bool HasNext() {
			return this.CurrentIndex < this.Profiles.Count;
		}

		public void GetNextProfileListPage ()
		{
			// Là on récupère un dictionnaire en JSON
			// puis on transforme avec un builder
			this.TinderAPIClient.GetProfileList (this.CurrentUser.GetFacebookToken());
			Profile profile = ProfileBuilder.Build ();
			this.Profiles.Add(profile);
		}

		/**
		 * Return the profile just liked
		 */
		public Profile LikeNext()
		{
			if (this.CurrentIndex < this.Profiles.Count) {
				Profile profile = this.Profiles [this.CurrentIndex];
				this.TinderAPIClient.Like (profile.GetIdentifier());
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

