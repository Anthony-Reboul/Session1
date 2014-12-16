using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
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

		public TinderManager (User user)
		{
			this.CurrentIndex = 0;
			this.CurrentUser = user;
			this.TinderAPIClient = new TinderAPIClient (this.CurrentUser);
			this.Profiles = new List<Profile> ();
		}

		public bool HasNext() {
			return this.CurrentIndex < this.Profiles.Count;
		}

		public async Task<string> Auth() {
			bool result = true;
			string data = await this.TinderAPIClient.Auth();
			JObject root = JObject.Parse(data);
			this.CurrentUser.SetTinderToken ((string)root["token"]);
			return data;
		}

		public async Task<string> GetNextProfileListPage ()
		{
			// Là on récupère un dictionnaire en JSON
			// puis on transforme avec un builder
			string data = await this.TinderAPIClient.GetProfileList ();
			List<Profile> profiles = ProfileBuilder.BuildList (data);
			this.Profiles.AddRange(profiles);
			return data;
		}

		/**
		 * Return the profile just liked
		 */
		public async Task<Profile> LikeNext()
		{
			Profile result = new Profile ();
			if (this.CurrentIndex < this.Profiles.Count) {
				result = this.Profiles [this.CurrentIndex];
				await this.TinderAPIClient.Like (result.GetIdentifier());
				this.CurrentIndex++;
				this.CurrentUser.IncrementNumberOfLikes ();
			}
			return result;
		}

		public int GetCurrentNumberOfLikes()
		{
			return this.CurrentUser.GetNumberOfLikes();
		}

		public bool IsUserAuthenticated() {
			return this.CurrentUser.GetTinderToken () != null;
		}
	}
}

