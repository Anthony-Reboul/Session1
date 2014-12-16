using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using TAL.Core.Interface;
using TAL.Core.Behavior;
using TAL.Core.Entity;

namespace TAL.iOS
{
	public partial class HomeViewController : UIViewController,SpecificInterface
	{
		private UserBehavior Behavior;
		private UILabel nbLikeLabel;
		private UILabel nameLabel;
		private UIButton start;
		private UIButton stop;
		private UIImageView avatarView;

		public HomeViewController () : base ("HomeViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			start = new UIButton (new RectangleF (10, 20, 100, 30));
			start.BackgroundColor = UIColor.Yellow;
			start.SetTitle ("Start !",UIControlState.Normal);
			start.SetTitleColor (UIColor.Black,UIControlState.Normal);
			start.TouchUpInside += (o,s) => {
				this.Behavior.StartAutoLiking ();
			};
			this.Add (start);

			stop = new UIButton (new RectangleF (200, 20, 100, 30));
			stop.BackgroundColor = UIColor.Yellow;
			stop.SetTitle ("Stop !",UIControlState.Normal);
			stop.SetTitleColor (UIColor.Black,UIControlState.Normal);
			stop.TouchUpInside += (o,s) => {
				this.Behavior.StopAutoLiking ();
			};
			this.Add (stop);

			nameLabel = new UILabel (new RectangleF (10, 50, 300, 20));
			nameLabel.TextAlignment = UITextAlignment.Center;
			this.Add (nameLabel);

			nbLikeLabel = new UILabel (new RectangleF (10, 90, 300, 20));
			nbLikeLabel.TextAlignment = UITextAlignment.Center;
			this.Add (nbLikeLabel);

			avatarView = new UIImageView(new RectangleF (10, 130, 300, 300));
			this.Add (avatarView);
		}

		public void SetNumberOfLikes(string numberOfLikes) {
			nbLikeLabel.Text = numberOfLikes;
		}

		public async void AddNewProfile(string profilePicture, string name) {
			Console.WriteLine (name + "( " + profilePicture + " )");
			nameLabel.Text = name;
			avatarView.Image = await this.LoadImage (profilePicture);
		}

		public void SetBehavior(UserBehavior behavior) {
			this.Behavior = behavior;
		}

		public async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}
	}
}

