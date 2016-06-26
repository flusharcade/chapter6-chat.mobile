// --------------------------------------------------------------------------------------------------
//  <copyright file="AppDelegate.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Chat.iOS
{
	using Foundation;
	using UIKit;

	using Chat.iOS.Views;
	using Chat.iOS.Services;

	using Chat.Common.Presenter;

	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;
		UINavigationController _navigationController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow(UIScreen.MainScreen.Bounds);

			_navigationController = new UINavigationController();

			var state = new ApplicationState();

			var presenter = new ClientsListPresenter(state, new NavigationService(_navigationController));
			var controller = new ClientsListViewController(presenter);

			//var presenter = new ChatPresenter(state, new NavigationService(_navigationController), new Common.Model.Client());
			//var controller = new ChatViewController(presenter);

			_navigationController.PushViewController(controller, false);
			_window.RootViewController = _navigationController;

			// make the window visible
			_window.MakeKeyAndVisible();

			return true;
		}
	}
}