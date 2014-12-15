using System;

namespace TAL.Core.Entity
{
	public class User
	{
		private String FacebookToken;
		private int NumberOfLikes;

		public User (String facebookToken)
		{
			this.FacebookToken = facebookToken;
			this.NumberOfLikes = 0;
		}

		public void IncrementNumberOfLikes()
		{
			this.NumberOfLikes++;
		}

		public int GetNumberOfLikes()
		{
			return this.NumberOfLikes;
		}

		public String GetFacebookToken()
		{
			return this.FacebookToken;
		}
	}
}

