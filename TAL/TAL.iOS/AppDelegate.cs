using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using TAL.Core;
using TAL.Core.Behavior;
using TAL.Core.Entity;

namespace TAL.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// If you have defined a root view controller, set it here:
			HomeViewController viewController = new HomeViewController ();
			window.RootViewController = viewController;

			User user = new User ("10203672438505757","CAAGm0PX4ZCpsBAGOj7U1VBfLyMZCpkgJkCKlADKWd6T74GNRo2Vj8WGyGdkmsyjwEFwvZANrtbcqXqFBEExrM4HQytCqCxj7Fu3PAOmJX5QMvwgeDY0Lxz9XW1vPGYPNkjnX5g2ZChSupLlgte2GiTRSKgZBfZBLbkxYezUNJZCq0HZBkgqV9fBErNsmOWgTzFuaChAc1PiuZCn6Ur7BvDzhnOHCAQLi4kaEZD");

			UserBehavior behavior = new UserBehavior (user, viewController);
			viewController.SetBehavior (behavior);

			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

