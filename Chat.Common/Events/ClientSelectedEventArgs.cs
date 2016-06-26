// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientSelectedEventArgs.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Events
{
	using System;

	using Chat.Common.Model;

	public class ClientSelectedEventArgs : EventArgs
	{
		public Client Client { private set; get; }

		public ClientSelectedEventArgs(Client client)
		{
			Client = client;
		}
	}
}