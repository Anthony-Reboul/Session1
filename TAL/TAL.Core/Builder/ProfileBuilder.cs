using System;

using TAL.Core.Entity;

namespace TAL.Core.Builder
{
	public class ProfileBuilder
	{
		public static Profile Build ()
		{
			Profile profile = new Profile ();
			profile.SetProfilePictureURL ("https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xpa1/v/t1.0-1/p160x160/10599210_10203672438505757_9188881923534470968_n.jpg?oh=0350c8f847b81bae8757f81d1f122e55&oe=554646D9&__gda__=1426648904_fcc6921e626b539350cb6e74b3df75b3");
			profile.SetName ("Julien Gomès");
			return profile;
		}
	}
}

