using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TAL.Core.Entity;

namespace TAL.Core.API
{
	public class TinderAPIClient
	{
		private User CurrentUser;
		private string BaseURL = "https://api.gotinder.com";

		public TinderAPIClient (User user)
		{
			this.CurrentUser = user;
		}

		public async Task<string> Auth() {
			HttpClient httpClient = new HttpClient();

			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Tinder/4.0.4 (iPhone; iOS 7.1.1; Scale/2.00)");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
			var variables = new FormUrlEncodedContent(new[] 
				{
					new KeyValuePair<string, string>("facebook_token", this.CurrentUser.GetFacebookToken()),
					new KeyValuePair<string, string>("facebook_id", this.CurrentUser.GetFacebookId()),
				});
			var contentsTask = httpClient.PostAsync(this.BaseURL+"/auth",variables);
			HttpResponseMessage contents = await contentsTask;
			return contents.Content.ReadAsStringAsync().Result;
		}

		public async Task<string> Like(string identifier)
		{
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Tinder/4.0.4 (iPhone; iOS 7.1.1; Scale/2.00)");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Auth-Token", this.CurrentUser.GetTinderToken());
			var contentsTask = httpClient.GetAsync(this.BaseURL+"/like/"+identifier);
			HttpResponseMessage contents = await contentsTask;
			return contents.Content.ReadAsStringAsync().Result;
		}

		public async Task<string> GetProfileList()
		{
			HttpClient httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Tinder/4.0.4 (iPhone; iOS 7.1.1; Scale/2.00)");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Auth-Token", this.CurrentUser.GetTinderToken());
			var contentsTask = httpClient.PostAsync(this.BaseURL+"/user/recs",null);
			HttpResponseMessage contents = await contentsTask;
			return contents.Content.ReadAsStringAsync().Result;
		}
	}
}
