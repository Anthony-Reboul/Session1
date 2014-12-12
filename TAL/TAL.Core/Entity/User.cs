using System;

namespace TAL.Core.Entity
{
	public class User
	{
		private String FacebookToken;
		private int NumberOfLikes;

		public User ()
		{
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
	}
}

