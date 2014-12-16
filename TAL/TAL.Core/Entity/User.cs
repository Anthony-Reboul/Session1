using System;

namespace TAL.Core.Entity
{
	public class User
	{
		private string FacebookId;
		private string FacebookToken;
		private string TinderToken;
		private int NumberOfLikes;

		public User (String facebookId, String facebookToken)
		{
			this.FacebookId = facebookId;
			this.FacebookToken = facebookToken;
			this.NumberOfLikes = 0;
			this.TinderToken = null;
		}

		public void IncrementNumberOfLikes()
		{
			this.NumberOfLikes++;
		}

		public int GetNumberOfLikes()
		{
			return this.NumberOfLikes;
		}

		public string GetFacebookToken()
		{
			return this.FacebookToken;
		}

		public string GetFacebookId()
		{
			return this.FacebookId;
		}

		public void SetTinderToken(string tinderToken)
		{
			this.TinderToken = tinderToken;
		}

		public string GetTinderToken()
		{
			return this.TinderToken;
		}

	}
}

