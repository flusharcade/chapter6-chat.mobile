// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableSource.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.iOS 
{
	using System;
	using System.Collections.Generic;

	using UIKit;
	using Foundation;

	using Chat.Common.Model;

	public class ClientsTableSource : UITableViewSource 
	{
		#region Public Properties

		public event EventHandler<Client> ItemSelected;

		#endregion

		#region Private Properties

		private List<Client> _clients;

		string CellIdentifier = "ClientCell";

		#endregion

		#region Constructors

		public ClientsTableSource ()
		{
			_clients = new List<Client>();
		}

		#endregion

		#region Methods

		public void UpdateClients(IEnumerable<Client> clients)
		{
			_clients.Clear();

			foreach (var client in clients)
			{
				_clients.Add (client);
			}
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _clients.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (ItemSelected != null)
			{
				ItemSelected (this, _clients[indexPath.Row]);
			}

			tableView.DeselectRow (indexPath, true);
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 80;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			var client = _clients[indexPath.Row];

			if (cell == null)
			{ 
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); 
			}

			cell.TextLabel.Text = client.ConnectedId;

			return cell;
		}

		#endregion
	}
}