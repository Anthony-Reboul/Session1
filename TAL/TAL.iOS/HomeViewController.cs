using System;
using System.Drawing;
using System.Threading.Tasks;

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

			this.View.BackgroundColor = UIColor.Blue;

			UIButton button = new UIButton (new RectangleF (10, 20, 100, 20));
			button.BackgroundColor = UIColor.Yellow;
			button.TouchUpInside += (o,s) => {
				this.Behavior.StartAutoLiking ();
			};
			this.Add (button);
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void SetNumberOfLikes(string numberOfLikes) {
			Console.WriteLine("Number of like : "+numberOfLikes);
		}

		public void AddNewProfile(string profilePicture, string name) {
			Console.WriteLine("Name : "+name);
		}

		public void SetBehavior(UserBehavior behavior) {
			this.Behavior = behavior;
		}
	}
}

