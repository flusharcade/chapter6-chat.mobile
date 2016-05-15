// --------------------------------------------------------------------------------------------------
//  <copyright file="AudioPlayerPage.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Droid
{
	using Android.App;
	using Android.Graphics;
	using Android.OS;
	using Android.Views;
	using Android.Widget;

	using MvvmCross.Droid.Views;

	using AudioPlayer.Droid.Controls;

	using AudioPlayer.Portable.ViewModels;

	[Activity(NoHistory = true)]
	public class AudioPlayerPage : MvxActivity
	{
		private bool playing;

		private ImageButton playButton;

		private CustomSeekBar seekBar;

		private AudioPlayerPageViewModel model;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.AudioPlayerPage);

			seekBar = FindViewById<CustomSeekBar>(Resource.Id.seekBar);
			seekBar.ValueChanged += handleValueChanged;

			this.playButton = FindViewById<ImageButton>(Resource.Id.PlayButton);
			this.playButton.SetColorFilter(Color.White);
			this.playButton.Click += handlePlayClick;

			var rewindButton = FindViewById<ImageButton>(Resource.Id.RewindButton);
			rewindButton.SetColorFilter(Color.White);
			rewindButton.Click += handleRewindForwardClick;

			var forwardButton = FindViewById<ImageButton>(Resource.Id.ForwardButton);
			forwardButton.SetColorFilter(Color.White);
			forwardButton.Click += handleRewindForwardClick;

			this.model = (AudioPlayerPageViewModel)this.ViewModel;
		}

		private void handleValueChanged(object sender, System.EventArgs e)
		{
			this.model.UpdateAudioPosition(this.seekBar.Progress);
		}

		private void handlePlayClick(object sender, System.EventArgs e)
		{
			playing = !playing;
			this.playButton.SetImageResource(playing ? Resource.Drawable.pause : Resource.Drawable.play);
		}

		private void handleRewindForwardClick(object sender, System.EventArgs e)
		{
			playing = false;
			this.playButton.SetImageResource(Resource.Drawable.play);
		}

		protected override void OnDestroy()
		{
			this.model.Dispose();

			base.OnDestroy();
		}
	}
}