// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatPresenter.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Presenter
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Chat.Common.Events;
	using Chat.Common.Model;

	public class ChatPresenter : BasePresenter
	{
		#region Private Properties

		private Client _client;

		private IChatView _view;

		#endregion

		#region IChatView

		public interface IChatView : IView
		{
			void NotifyChatMessageReceived(string message);

			void CreateChatBox(bool received, string message);
		}

		#endregion

		#region Constructors

		public ChatPresenter(ApplicationState state, INavigationService navigationService, Client client)
		{
			_navigationService = navigationService;
			_state = state;
			_client = client;
		}

		#endregion

		#region Public Methods

		public void SetView(IChatView view)
		{
			_view = view;

			ChatReceived -= HandleChatReceived;
			ChatReceived += HandleChatReceived;
		}

		public async Task SendChat(string message)
		{
			await _signalRClient.SendMessageToClient(_client.ConnectedId, message);
		}

		#endregion

		#region Private Methods

		private void HandleChatReceived(object sender, ChatEventArgs e)
		{
			_view.NotifyChatMessageReceived(e.Message);
		}

		#endregion
	}
}