// --------------------------------------------------------------------------------------------------
//  <copyright file="AndroidSetup.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Droid
{
	using Android.Content;

	using MvvmCross.Droid.Platform;

	using MvvmCross.Core.ViewModels;

	using MvvmCross.Platform.Converters;
	using MvvmCross.Platform.Platform;

	using AudioPlayer.Portable.Logging;
	using AudioPlayer.Portable;

	public class AndroidSetup : MvxAndroidSetup
	{
		public AndroidSetup(Context context) :base(context)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}