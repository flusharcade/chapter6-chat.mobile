// --------------------------------------------------------------------------------------------------
//  <copyright file="ISoundHandler.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Shared
{
	using MvvmCross.Platform;

	using AudioPlayer.Portable.ViewModels;

	public static class SharedMvxIoCRegistrations
	{
		public static void InitIoC()
		{
			Mvx.IocConstruct<MainPageViewModel>();
			Mvx.IocConstruct<AudioPlayerPageViewModel>();
		}
	}
}

