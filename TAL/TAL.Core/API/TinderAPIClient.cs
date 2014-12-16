using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TAL.Core.Entity;

namespace TAL.Core.API
{
	public class TinderAPIClient
	{
		private User CurrentUser;

		public TinderAPIClient (User user)
		{
			this.CurrentUser = user;
		}

		public async Task<bool> Auth() {
			HttpClient httpClient = new HttpClient(); // Xamarin supports HttpClient!
			Task<string> contentsTask = httpClient.GetStringAsync("https://api.gotinder.com");
			string contents = await contentsTask;
			return true;
		}

		public void Like(string identifier)
		{

		}

		public void GetProfileList(string identifier)
		{

		}

		public async Task<int> DownloadHomepage()
		{
			/*
			var httpClient = new HttpClient(); // Xamarin supports HttpClient!

			Task<string> contentsTask = httpClient.GetStringAsync("http://xamarin.com"); // async method!

			// await! control returns to the caller and the task continues to run on another thread
			string contents = await contentsTask;

			ResultEditText.Text += "DownloadHomepage method continues after async call. . . . .\n";

			// After contentTask completes, you can calculate the length of the string.
			int exampleInt = contents.Length;

			ResultEditText.Text += "Downloaded the html and found out the length.\n\n\n";

			ResultEditText.Text += contents; // just dump the entire HTML

			return exampleInt; // Task<TResult> returns an object of type TResult, in this case int
			*/
			return 0;
		}
	}
}

