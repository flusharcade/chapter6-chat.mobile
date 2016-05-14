// --------------------------------------------------------------------------------------------------
//  <copyright file="MainPageViewModel.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Portable.ViewModels
{
	using MvvmCross.Core.ViewModels;

	public class MainPageViewModel : MvxViewModel
	{
		#region Private Properties

		private string title = "Welcome";

		private string descriptionMessage = "Welcome to the Music Room";

		private string audioPlayerTitle = "Audio Player";

		private string exitTitle = "Exit";

		private MvxCommand audioPlayerCommand;

		private MvxCommand exitCommand;

		#endregion

		#region Public Properties

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				if (!value.Equals(title))
				{
					descriptionMessage = value;
					RaisePropertyChanged(() => Title);
				}
			}
		}

		public string DescriptionMessage
		{
			get 
			{ 
				return descriptionMessage; 
			} 
			set 
			{ 
				if (!value.Equals(descriptionMessage))
				{
					descriptionMessage = value;
					RaisePropertyChanged (() => DescriptionMessage);
				}
			}
		}

		public string AudioPlayerTitle
		{
			get 
			{ 
				return audioPlayerTitle; 
			} 
			set 
			{ 
				if (!value.Equals(audioPlayerTitle))
				{
					audioPlayerTitle = value;
					RaisePropertyChanged (() => AudioPlayerTitle);
				}
			}
		}

		public string ExitTitle
		{
			get 
			{ 
				return exitTitle; 
			} 
			set 
			{ 
				if (!value.Equals(exitTitle))
				{
					exitTitle = value;
					RaisePropertyChanged (() => ExitTitle);
				}
			}
		}

		public MvxCommand AudioPlayerCommand
		{
			get
			{
				return this.audioPlayerCommand;
			}

			set
			{
				if (!value.Equals(audioPlayerCommand))
				{
					audioPlayerCommand = value;
					RaisePropertyChanged (() => AudioPlayerCommand);
				}
			}
		}

		public MvxCommand ExitCommand
		{
			get
			{
				return this.exitCommand;
			}

			set
			{
				if (!value.Equals(exitCommand))
				{
					exitCommand = value;
					RaisePropertyChanged (() => ExitCommand);
				}
			}
		}

		#endregion

		#region Constructors

		public MainPageViewModel ()
		{
			this.exitCommand = new MvxCommand (() =>
			{
				Close(this);
			});

			this.audioPlayerCommand = new MvxCommand(() =>
			{
				ShowViewModel<AudioPlayerPageViewModel>();
			});
		}

		#endregion
	}
}