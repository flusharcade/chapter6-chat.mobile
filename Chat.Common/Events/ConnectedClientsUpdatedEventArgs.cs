// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectedClientsUpdatedEventArgs.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Events
{
	using System;
	using System.Collections.Generic;

	using Chat.Common.Model;

	public class ConnectedClientsUpdatedEventArgs : EventArgs
	{
		public IList<Client> ConnectedClients { private set; get; }

		public ConnectedClientsUpdatedEventArgs(IEnumerable<Client> connectedClients)
		{
			ConnectedClients = new List<Client>();

			foreach (var client in connectedClients)
			{
				ConnectedClients.Add(client);
			}
		}
	}
}