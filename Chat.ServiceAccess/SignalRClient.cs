// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignalRClient.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.ServiceAccess
{
	using System;
	using System.Net;
	using System.Threading.Tasks;
	using System.Linq;
	using System.Collections.Generic;

	using Microsoft.AspNet.SignalR.Client;

	public class SignalRClient
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;
 
        public event EventHandler<Tuple<string, string>> OnDataReceived;
 
        public SignalRClient()
        {
			_connection = new HubConnection("http://172.20.10.10:52786/");
            _proxy = _connection.CreateHubProxy("ChatHub");
        }
 
        public async Task Connect()
        {
			await _connection.Start();

			_proxy.On<string, string>("displayMessage", (id, data) =>
			{
				if (OnDataReceived != null)
				{
					OnDataReceived(this, new Tuple<string, string>(id, data));
				}
			});
		}

		public async Task SendMessageToClient(string connectionId, string message)
		{
			await _proxy.Invoke("SendChat", new object[]
			{
				connectionId,
				message
			});
		}
    }
}