// --------------------------------------------------------------------------------------------------
//  <copyright file="App.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Portable
{
	using System;

	using MvvmCross.Core.ViewModels;

	using MvvmCross.Platform.IoC;

	using AudioPlayer.Portable.ViewModels;

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<MainPageViewModel>();
        }
    }
}