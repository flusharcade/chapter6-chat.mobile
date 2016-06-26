// --------------------------------------------------------------------------------------------------
//  <copyright file="ChatViewController.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Chat.iOS.Views
{
	using System;
	using System.Linq;

	using Foundation;
	using UIKit;
	using CoreGraphics;

	using Chat.iOS.Extras;
	using Chat.iOS.Extensions;

	using Chat.Common.Presenter;

	public class ChatViewController : UIViewController, ChatPresenter.IChatView
	{
		#region Private Properties

		private ChatPresenter _presenter;

		private UITextField _chatField;

		private UIScrollView _scrollView;

		private int _currentTop = 20;

		private nfloat _width;

		#endregion

		#region Constructors

		public ChatViewController(ChatPresenter presenter)
		{
			_presenter = presenter;
		}

		#endregion

		#region Public Methods

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Chat Room";

			_presenter.SetView(this);

			View.BackgroundColor = UIColor.White;

			_width = View.Bounds.Width;

			var _sendButton = new UIButton(UIButtonType.RoundedRect)
			{
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			_sendButton.SetTitle("Send", UIControlState.Normal);
			_sendButton.TouchUpInside += HandleSendButton;

			_chatField = new UITextField()
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
			};

			_scrollView = new UIScrollView()
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
			};

			Add(_chatField);
			Add(_sendButton);
			Add(_scrollView);

			var views = new DictionaryViews()
			{
				{"sendButton", _sendButton},
				{"chatField", _chatField},
				{"scrollView", _scrollView},
			};

			this.View.AddConstraints(
				NSLayoutConstraint.FromVisualFormat("V:|-62-[chatField(60)]-[scrollView]|", NSLayoutFormatOptions.DirectionLeftToRight, null, views)
				.Concat(NSLayoutConstraint.FromVisualFormat("V:|-62-[sendButton(60)]-20-[scrollView]|", NSLayoutFormatOptions.DirectionLeftToRight, null, views))
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|-5-[chatField]-[sendButton(60)]-5-|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|[scrollView]|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.ToArray());
		}

		#endregion

		#region IChatView implementation

		public void NotifyChatMessageReceived(string message)
		{
			InvokeOnMainThread(() => CreateChatBox(true, message));
		}

		#endregion

		#region IView implementation

		public void SetErrorMessage(string message)
		{
			var alert = new UIAlertView()
			{
				Title = "Chat",
				Message = message
			};
			alert.AddButton("OK");
			alert.Show();
		}

		public bool IsInProgress { get; set; }

		#endregion

		#region Private Properties

		private void HandleSendButton(object sender, EventArgs e)
		{
			_presenter.SendChat(_chatField.Text).ConfigureAwait(false);
			CreateChatBox(false, _chatField.Text);
		}

		private void CreateChatBox(bool received, string message)
		{
			_scrollView.ContentSize = new CGSize(_width, _currentTop);

			_scrollView.AddSubview(new ChatBoxView(message)
			{
				//Frame = new CGRect(received ? _width - 120 : 20, _currentTop, 100, 60),
				Frame = new CGRect(20, _currentTop, 100, 60),
				BackgroundColor = UIColor.Clear.FromHex(received ? "#4CD964" : "#5AC8FA")
			});

			_currentTop += 80;
		}

		#endregion
	}
}