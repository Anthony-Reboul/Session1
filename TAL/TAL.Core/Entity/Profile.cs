using System;

namespace TAL.Core.Entity
{
	public class Profile
	{
		private String Identifier;
		private String ProfilePicture;
		private String DisplayName;

		public Profile ()
		{
		}

		public String GetProfilePictureURL()
		{
			return this.ProfilePicture;
		}

		public String GetName()
		{
			return this.DisplayName;
		}
	}
}

