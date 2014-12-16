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

			User user = new User ("10203672438505757","CAAGm0PX4ZCpsBADvnK9sIT4imTABgOSnFDhZB32VVK0yl0cSJuTP04OWeUYTYutFQSC27Qk4bkMH6sSL18WTW3XPKCs4fruOmMPBm9zPzi3AAv0tGZCnSYt05unmls3FpzKpFIvsPIzhOsEegkVNmjKMzlHZC9l1pxNZBtrxcSh9fwkDGIst2uECkF14LEmcZD");

			UserBehavior behavior = new UserBehavior (user, viewController);
			viewController.SetBehavior (behavior);
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

