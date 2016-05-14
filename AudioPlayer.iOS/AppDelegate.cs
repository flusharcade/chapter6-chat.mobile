// --------------------------------------------------------------------------------------------------
//  <copyright file="AppDelegate.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.iOS
{
	using Foundation;
	using UIKit;

	using MvvmCross.iOS.Platform;

	using MvvmCross.Core.ViewModels;

	using MvvmCross.Platform;

	using AudioPlayer.iOS;
	using AudioPlayer.iOS.Sound;

	using AudioPlayer.Shared;

	using AudioPlayer.Portable.Sound;

	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		/// <summary>
		/// The window.
		/// </summary>
		protected UIWindow window;

		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="application">Application.</param>
		/// <param name="launchOptions">Launch options.</param>
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			this.window = new UIWindow (UIScreen.MainScreen.Bounds);

			var setup = new IosSetup(this, window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();
			this.setupIoC();

			this.window.MakeKeyAndVisible ();

			return true;
		}

		/// <summary>
		/// Setups the registrations.
		/// </summary>
		/// <returns>The registrations.</returns>
		private void setupIoC()
		{
			Mvx.RegisterType<ISoundHandler, SoundHandler>();

			SharedMvxIoCRegistrations.InitIoC();
		}
	}
}