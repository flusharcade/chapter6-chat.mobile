// --------------------------------------------------------------------------------------------------
//  <copyright file="SoundHandler.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.iOS.Sound
{
	using System;
	using System.Diagnostics;

	using AudioPlayer.Portable.Sound;
	using AVFoundation;
	using Foundation;

	public class SoundHandler : ISoundHandler
	{
		private AVAudioPlayer audioPlayer;

		public bool IsPlaying { get; set; }

		public void Load()
		{
			this.audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename("Moby - The Only Thing.mp3"));
			//this.audioPlayer.NumberOfLoops = -1;
		}

		public void PlayPause()
		{
			if (this.audioPlayer != null)
			{
				if (this.IsPlaying)
				{
					this.audioPlayer.Stop();
				}
				else
				{
					this.audioPlayer.Play();
				}

				this.IsPlaying = !this.IsPlaying;
			}
		}

		public void Stop()
		{
			if (this.audioPlayer != null)
			{
				this.audioPlayer.Stop();
			}
		}

		public double Duration()
		{
			if (this.audioPlayer != null)
			{
				return this.audioPlayer.Duration;
			}

			return 0;
		}

		public void SetPosition(double value)
		{
			if (this.audioPlayer != null)
			{
				this.audioPlayer.CurrentTime = value;
			}
		}

		public double CurrentPosition()
		{
			if (this.audioPlayer != null)
			{
				return this.audioPlayer.CurrentTime;
			}

			return 0;
		}

		public void Forward()
		{
			if (this.audioPlayer != null)
			{
				this.IsPlaying = false;

				this.audioPlayer.Stop();
				this.audioPlayer.CurrentTime = this.audioPlayer.Duration;
			}
		}

		public void Rewind()
		{
			if (this.audioPlayer != null)
			{
				this.IsPlaying = false;

				this.audioPlayer.Stop();
				this.audioPlayer.CurrentTime = 0;
			}
		}
	}
}