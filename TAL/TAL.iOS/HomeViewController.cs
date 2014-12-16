
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using TAL.Core.Interface;
using TAL.Core.Behavior;

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
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void SetNumberOfLikes(String numberOfLikes) {
			Console.WriteLine("Number of like : "+numberOfLikes);
		}

		public void AddNewProfile(String profilePicture, String name) {
			Console.WriteLine("Name : "+name);
		}

		public void SetBehavior(UserBehavior behavior) {
			this.Behavior = behavior;
		}
	}
}

