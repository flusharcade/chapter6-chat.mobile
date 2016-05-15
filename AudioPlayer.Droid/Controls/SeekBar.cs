// --------------------------------------------------------------------------------------------------
//  <copyright file="CustomSeekBar.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace AudioPlayer.Droid.Controls
{
	using System;

	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Util;
	using Android.Runtime;
	using Android.Views;
	using Android.Widget;

	public class CustomSeekBar : SeekBar
	{
		public event EventHandler ValueChanged;

		protected CustomSeekBar(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public CustomSeekBar(Context context)
			: base(context)
		{

		}

		public CustomSeekBar(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public CustomSeekBar(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
		}

		public override bool OnTouchEvent(MotionEvent evt)
		{
			if (!Enabled)
				return false;

			switch (evt.Action)
			{
				// only fire value change events when the touch is released
				case MotionEventActions.Up:
					{
						if (this.ValueChanged != null)
						{
							this.ValueChanged(this, EventArgs.Empty);
						}
					}
					break;
			}

			// we also want to fire all base motion events
			base.OnTouchEvent(evt);

			return true;
		}
	}
}