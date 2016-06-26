// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientsListAdapter.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Droid.Views
{
	using System.Collections.Generic;

	using Android.App;
	using Android.Widget;
	using Android.Views;

	using Chat.Common.Model;

	public class ClientsListAdapter : BaseAdapter<Client>
	{
		private List<Client> _clients;

		private Activity _context;

		public ClientsListAdapter(Activity context) : base()
		{
			_context = context;
			_clients = new List<Client>();
		}
			
		public override Client this[int position]
		{
			get
			{
				return _clients[position];
			}
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get 
			{ 
				return _clients.Count; 
			} 
		}

		public void UpdateClients(IEnumerable<Client> clients)
		{
			foreach (var client in clients)
			{
				_clients.Add(client);
			}
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available

			if (view == null)
			{ 
				// otherwise create a new one
				view = _context.LayoutInflater.Inflate(Resource.Layout.CustomCell, null);
			}

			// set labels
			var connectionIdTextView = view.FindViewById<TextView> (Resource.Id.connectionId);
			connectionIdTextView.Text = _clients[position].ConnectedId;

			return view;
		}
	}
}