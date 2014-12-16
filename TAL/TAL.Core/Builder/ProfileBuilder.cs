using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

using TAL.Core.Entity;

namespace TAL.Core.Builder
{
	public class ProfileBuilder
	{
		public static List<Profile> BuildList (string data)
		{
			JObject root = JObject.Parse(data);
			JArray results = (JArray)root["results"];
			List<Profile> profiles = new List<Profile> ();
			foreach (JObject result in results) {
				Profile profile = ProfileBuilder.Build (result);
				profiles.Add (profile);
			}
			return profiles;
		}

		private static Profile Build (JObject data)
		{
			Profile profile = new Profile ();
			JArray photos = (JArray)data ["photos"];
			if (photos.Count > 0) {
				JObject photo = (JObject)photos [0];
				JArray processedFiles = (JArray)photo ["processedFiles"];
				if (processedFiles.Count > 0) {
					JObject processedFile = (JObject)processedFiles [0];
					profile.SetProfilePictureURL ((string)processedFile["url"]);
				}
			}
			profile.SetName ((string)data["name"]);
			profile.SetIdentifier ((string)data["_id"]);
			return profile;
		}
	}
}

