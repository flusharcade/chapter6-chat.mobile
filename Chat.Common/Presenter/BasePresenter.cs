// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientsListPresenter.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Presenter
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	using Newtonsoft.Json;

	using Chat.ServiceAccess;

	using Chat.Common.Events;
	using Chat.Common.Model;

	public abstract class BasePresenter
	{
		#region Private Properties

		private IDictionary<string, Action<string>> _signalREvents;

		#endregion

		#region Protected Properties

		protected INavigationService _navigationService;

		protected ApplicationState _state;

		protected SignalRClient _signalRClient;

		#endregion

		#region Events

		public event EventHandler<ConnectedClientsUpdatedEventArgs> ConnectedClientsUpdated;

		public event EventHandler<ChatEventArgs> ChatReceived;

		#endregion

		#region Constructors

		public BasePresenter()
		{
			_signalREvents = new Dictionary<string, Action<string>>()
			{
				{"clients", (data) => 
					{
						var list = JsonConvert.DeserializeObject<HashSet<string>>(data);

						if (ConnectedClientsUpdated != null)
						{
							ConnectedClientsUpdated(this, new ConnectedClientsUpdatedEventArgs(list.Select(connId => new Client()
							{
								ConnectedId = connId
							})));
						}
					}
				},
				{"chat", (data) => 
					{
						if (ChatReceived != null)
						{
							ChatReceived(this, new ChatEventArgs(data));
						}
					}
				},
			};

			_signalRClient = new SignalRClient();
			_signalRClient.OnDataReceived += HandleSignalRDataReceived;
			_signalRClient.Connect().ConfigureAwait(false);
		}

		#endregion

		#region Private Methods

		private void HandleSignalRDataReceived(object sender, Tuple<string, string> e)
		{
			_signalREvents[e.Item1](e.Item2);
		}

		#endregion
	}
}