// --------------------------------------------------------------------------------------------------
//  <copyright file="SoundHandler.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Droid.Sound
{
	using System;
	using System.Diagnostics;

	using Android.Content.Res;
	using Android.Media;
	using Android.Content;

	using AudioPlayer.Portable.Sound;

	public class SoundHandler : ISoundHandler
	{
		private MediaPlayer mediaPlayer;

		public bool IsPlaying { get; set; }

		public void Load()
		{
			try
			{
				this.mediaPlayer = new MediaPlayer();
				this.mediaPlayer.SetAudioStreamType(Stream.Music);

				AssetFileDescriptor descriptor = Android.App.Application.Context.Assets.OpenFd("Moby - The Only Thing.mp3");
				this.mediaPlayer.SetDataSource(descriptor.FileDescriptor, descriptor.StartOffset, descriptor.Length);

				this.mediaPlayer.Prepare();
				this.mediaPlayer.SetVolume(1f, 1f);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		public void PlayPause()
		{
			if (this.mediaPlayer != null)
			{
				if (this.IsPlaying)
				{
					this.mediaPlayer.Pause();
				}
				else
				{
					this.mediaPlayer.Start();
				}

				this.IsPlaying = !this.IsPlaying;
			}
		}

		public void Stop()
		{
			if (this.mediaPlayer != null)
			{
				this.mediaPlayer.Stop();
				this.mediaPlayer.Reset();
			}
		}

		public double Duration()
		{
			if (this.mediaPlayer != null)
			{
				return this.mediaPlayer.Duration / 1000;
			}

			return 0;
		}

		public void SetPosition(double value)
		{
			if (this.mediaPlayer != null)
			{
				this.mediaPlayer.SeekTo((int)value * 1000);
			}
		}

		public double CurrentPosition()
		{
			if (this.mediaPlayer != null)
			{
				return this.mediaPlayer.CurrentPosition / 1000;
			}

			return 0;
		}

		public void Forward()
		{
			if (this.mediaPlayer != null)
			{
				this.IsPlaying = false;

				this.mediaPlayer.Pause();
				this.mediaPlayer.SeekTo(this.mediaPlayer.Duration);
			}
		}

		public void Rewind()
		{
			if (this.mediaPlayer != null)
			{
				this.IsPlaying = false;

				this.mediaPlayer.Pause();
				this.mediaPlayer.SeekTo(0);
			}
		}
	}
}