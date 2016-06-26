// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientsListView.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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

	[Activity(MainLauncher = true, Label = "Chat", ScreenOrientation = ScreenOrientation.Portrait)]
	public class ClientsListView : ListActivity, ClientsListPresenter.IClientsListView
	{
		#region Private Properties

		private ClientsListPresenter _presenter;

		private ClientsListAdapter _adapter;

		#endregion

		#region IClientsListView implementation

		public event EventHandler<ClientSelectedEventArgs> ClientSelected;

		public void NotifyConnectedClientsUpdated(IEnumerable<Client> clients)
		{
			if (_adapter != null)
			{
				_adapter.UpdateClients(clients);

				// perform action on UI thread
				Application.SynchronizationContext.Post(state => 
				{ 
					_adapter.NotifyDataSetChanged(); 
				}, null);
			}
		}

		#endregion

		#region IView implementation

		public void SetErrorMessage(string message)
		{
		}

		public bool IsInProgress { get; set; }

		#endregion

		#region Protected Methods

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			var state = new ApplicationState();

			var app = ChatApplication.GetApplication(this);
			app.CurrentActivity = this;

			var presenter = new ClientsListPresenter(state, new NavigationService(app));
			presenter.SetView(this);

			_adapter = new ClientsListAdapter(this);
			ListAdapter = _adapter;
		}

		protected override void OnResume()
		{
			base.OnResume();

			if (_presenter != null)
			{
				_presenter.SetView(this);
			}
		}

		protected override void OnListItemClick(ListView l, Android.Views.View v, int position, long id)
		{
			var item = _adapter[position];

			if (ClientSelected != null)
			{
				ClientSelected(this, new ClientSelectedEventArgs(item));
			}
		}

		#endregion
	}
}