// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientsListView.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using Android.Graphics;

namespace Chat.Droid.Views
{
	using System;
	using System.Collections.Generic;

	using Android.App;
	using Android.Content.PM;
	using Android.OS;
	using Android.Widget;

	using Chat.Droid.Services;

	using Chat.Common.Model;
	using Chat.Common.Presenter;

	using Common.Events;

	[Activity(Label = "Chat", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ChatView : ListActivity, ChatPresenter.IChatView
	{
		#region Private Properties

		private ChatPresenter _presenter;

		private ScrollView _scrollView;

		private EditText _editText;

		private float _currentTop;

		#endregion

		#region Protected Methods

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			_scrollView = FindViewById<ScrollView>(Resource.Id.scrollView);
			var sendButton = FindViewById<Button>(Resource.Id.sendButton);

			sendButton.Touch += HandleSendButton;

			SetContentView(Resource.Layout.ChatView);

			var app = ChatApplication.GetApplication(this);
			_presenter = (ChatPresenter)app.Presenter;
			_presenter.SetView(this);
			app.CurrentActivity = this;
		}

		#endregion

		#region IChatView implementation

		public void NotifyChatMessageReceived(string message)
		{
			// perform action on UI thread
			Application.SynchronizationContext.Post(state =>
			{
				CreateChatBox(true, message);
			}, null);
		}

		#endregion

		#region IView implementation

		public void SetErrorMessage(string message)
		{

		}

		public bool IsInProgress { get; set; }

		#endregion

		#region Private Properties

		private void HandleSendButton(object sender, TouchEventArgs e)
		{
			_presenter.SendChat(_editText.Text).ConfigureAwait(false);
			CreateChatBox(false, _editText.Text);
		}

		private void CreateChatBox(bool received, string message)
		{
			var view = LayoutInflater.Inflate(Resource.Layout.ChatBoxView, null);
			view.SetX(20);
			view.SetY(_currentTop);
			view.SetMinimumWidth(100);
			view.SetMinimumHeight(60);

			var messageTextView = view.FindViewById<TextView>(Resource.Id.messageTextView);
			messageTextView.Text = message;

			view.SetBackgroundColor(received ? new Color("#4CD964") : new Color("#5AC8FA"));

			_scrollView.AddView(view);

			_currentTop += 80;
		}

		#endregion
	}
}