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

	using Chat.Common.Events;
	using Chat.Common.Model;

	using Chat.ServiceAccess;

	public class ClientsListPresenter : BasePresenter
	{
		#region Private Properties

		private IClientsListView _view;

		#endregion

		#region IClientsListView

		public interface IClientsListView : IView
		{
			event EventHandler<ClientSelectedEventArgs> ClientSelected;

			void NotifyConnectedClientsUpdated(IEnumerable<Client> clients);
		}

		#endregion

		#region Constructors

		public ClientsListPresenter(ApplicationState state, INavigationService navigationService)
		{
			_navigationService = navigationService;
			_state = state;
		}

		#endregion

		#region Public Methods

		public void SetView(IClientsListView view)
		{
			_view = view;
			_view.ClientSelected -= HandleClientSelected;
			_view.ClientSelected += HandleClientSelected;

			ConnectedClientsUpdated -= HandleConnectedClientsUpdated;
			ConnectedClientsUpdated += HandleConnectedClientsUpdated;
		}

		#endregion

		#region Private Methods

		private void HandleClientSelected(object sender, ClientSelectedEventArgs e)
		{
			var presenter = new ChatPresenter(_state, _navigationService, e.Client);
			_navigationService.PushPresenter(presenter);
		}

		private void HandleConnectedClientsUpdated(object sender, ConnectedClientsUpdatedEventArgs e)
		{
			_view.NotifyConnectedClientsUpdated(e.ConnectedClients);
		}

		#endregion
	}
}