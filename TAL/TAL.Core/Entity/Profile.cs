using System;

namespace TAL.Core.Entity
{
	public class Profile
	{
		private String Identifier;
		private String ProfilePicture;
		private String DisplayName;

		public void SetIdentfier (String identifier)
		{
			this.Identifier = identifier;
		}

		public void SetProfilePictureURL (String url)
		{
			this.ProfilePicture = url;
		}

		public void SetName (String name)
		{
			this.DisplayName = name;
		}

		public String GetProfilePictureURL()
		{
			return this.ProfilePicture;
		}

		public String GetName()
		{
			return this.DisplayName;
		}

		public String GetIdentifier()
		{
			return this.Identifier;
		}
	}
}

