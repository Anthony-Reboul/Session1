using System;

using TAL.Core.Entity;

namespace TAL.Core.Interface
{
	public class GenericInterface
	{
		private SpecificInterface SpecificInterface;

		public GenericInterface ()
		{
		}

		public void Render(Profile profile, int numberOfLikes) 
		{
			this.SpecificInterface.AddNewProfile (profile.GetProfilePictureURL (), profile.GetName ());
			this.SpecificInterface.SetNumberOfLikes (numberOfLikes.ToString());
		}
	}
}

