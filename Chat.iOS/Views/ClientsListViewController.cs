// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientsListViewController.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.iOS.Views
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using UIKit;
	using CoreGraphics;

	using Chat.iOS.Extras;

	using Chat.Common.Presenter;
	using Chat.Common.Events;
	using Chat.Common.Model;

	public class ClientsListViewController : UIViewController, ClientsListPresenter.IClientsListView
	{
		#region Private Properties

		private UITableView _tableView;

		private ClientsTableSource _source;

		private ClientsListPresenter _presenter;

		#endregion

		#region Constructors

		public ClientsListViewController(ClientsListPresenter presenter)
		{
			_presenter = presenter;

			_source = new ClientsTableSource();
			_source.ItemSelected += (sender, e) =>
			{
				if (ClientSelected != null)
				{
					ClientSelected(this, new ClientSelectedEventArgs(e));
				}
			};
		}

		#endregion

		#region Public Methods

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.White;

			_presenter.SetView(this);

			var width = View.Bounds.Width;
			var height = View.Bounds.Height;

			Title = "Welcome";

			var titleLabel = new UILabel()
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				Text = "Welcome to the Chat Room",
				Font = UIFont.FromName("Helvetica-Bold", 22),
				TextAlignment = UITextAlignment.Center
			};

			var descriptionLabel = new UILabel()
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				Text = "Select a client you would like to chat with",
				Font = UIFont.FromName("Helvetica", 18),
				TextAlignment = UITextAlignment.Center
			};

			_tableView = new UITableView(new CGRect(0, 0, width, height))
			{
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			_tableView.AutoresizingMask = UIViewAutoresizing.All;
			_tableView.Source = _source;

			Add(titleLabel);
			Add(descriptionLabel);
			Add(_tableView);

			var views = new DictionaryViews()
			{
				{"titleLabel", titleLabel},
				{"descriptionLabel", descriptionLabel},
				{"tableView", _tableView},
			};

			this.View.AddConstraints(
				NSLayoutConstraint.FromVisualFormat("V:|-100-[titleLabel(30)]-[descriptionLabel(30)]-[tableView]|", NSLayoutFormatOptions.DirectionLeftToRight, null, views)
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|[tableView]|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|-10-[titleLabel]-10-|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.Concat(NSLayoutConstraint.FromVisualFormat("H:|-10-[descriptionLabel]-10-|", NSLayoutFormatOptions.AlignAllTop, null, views))
				.ToArray());
		}

		#endregion

		#region IClientsListView implementation

		public event EventHandler<ClientSelectedEventArgs> ClientSelected;

		public void NotifyConnectedClientsUpdated(IEnumerable<Client> clients)
		{
			if (_source != null)
			{
				IsInProgress = true;

				_source.UpdateClients(clients);
				InvokeOnMainThread(() => _tableView.ReloadData());

				IsInProgress = false;
			}
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
	}
}