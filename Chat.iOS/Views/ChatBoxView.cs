// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatBoxView.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.iOS.Views
{
	using System;
	using System.Linq;

	using UIKit;

	using Chat.iOS.Extras;

	public class ChatBoxView : UIView
	{
		private UILabel messageLabel;

		public ChatBoxView(string message)
		{
			Layer.CornerRadius = 10;

			messageLabel = new UILabel()
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				Text = message
			};

			Add(messageLabel);

			var views = new DictionaryViews()
			{
				{"messageLabel", messageLabel},
			};

			AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[messageLabel]|", NSLayoutFormatOptions.AlignAllTop, null, views)
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|-5-[messageLabel]-5-|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.ToArray());
		}
	}
}