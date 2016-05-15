// --------------------------------------------------------------------------------------------------
//  <copyright file="SplashScreenActivity.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Droid
{
	using Android.App;
	using Android.OS;
	using Android.Widget;

	using MvvmCross.Droid.Views;

	using AudioPlayer.Portable.ViewModels;
	using MvvmCross.Platform;
	using AudioPlayer.Portable.Sound;
	using AudioPlayer.Droid.Sound;
	using AudioPlayer.Portable;

	[Activity(Label = "Audio Player")]
	public class MainPage : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			this.setupIoC();

			this.SetContentView(Resource.Layout.MainPage);
		}

		/// <summary>
		/// Sets up all IoC registrations.
		/// </summary>
		/// <returns>The io c.</returns>
		private void setupIoC()
		{
			Mvx.RegisterType<ISoundHandler, SoundHandler>();
			PortableMvxIoCRegistrations.InitIoC();
		}
	}
}