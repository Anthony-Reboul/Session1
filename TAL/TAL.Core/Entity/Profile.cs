using System;

namespace TAL.Core.Entity
{
	public class Profile
	{
		private string Identifier;
		private string ProfilePicture;
		private string DisplayName;

		public void SetIdentfier (string identifier)
		{
			this.Identifier = identifier;
		}

		public void SetProfilePictureURL (string url)
		{
			this.ProfilePicture = url;
		}

		public void SetName (string name)
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

