using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

using TAL.Core.Manager;
using TAL.Core.Interface;
using TAL.Core.Entity;

namespace TAL.Core.Behavior
{
	public class UserBehavior
	{
		private TinderManager Manager;
		private GenericInterface Interface;
		private bool IsRunning;

		public UserBehavior (User user, SpecificInterface specificInterface) {
			this.Manager = new TinderManager(user);
			this.Interface = new GenericInterface (specificInterface);
			this.IsRunning = true;
		}

		public async Task<Profile> Test() {
			await this.Manager.Auth ();
			await this.Manager.GetNextProfileListPage ();
			return await this.Manager.LikeNext ();
		}

		public async void StartAutoLiking()
		{
			this.IsRunning = true;
			while (this.IsRunning) {
				if (this.Manager.IsUserAuthenticated ()) {
					if (!this.Manager.HasNext ()) {
						await this.Manager.GetNextProfileListPage ();
					}
					Profile profileJustLiked = await this.Manager.LikeNext ();
					int numberOfLikes = this.Manager.GetCurrentNumberOfLikes ();
					this.Interface.Render (profileJustLiked, numberOfLikes);
				} else {
					await this.Manager.Auth ();
				}
			}
		}

		public void StopAutoLiking()
		{
			this.IsRunning = false;
		}
	}
}

