// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationState.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Presenter
{
	using System.Collections.Generic;
	using System;

	using Chat.Common.Model;

	public class ApplicationState
	{
		#region Private Properties

		private IApplicationStateService _applicationStateService;

		#endregion

		#region Public Properties

		public IApplicationStateService ApplicationStateService
		{
			set 
			{ 
				_applicationStateService = value; 
			}
		}

		public List<Client> ConnectedClients { get; set; }

		#endregion

		#region Constructors

		public ApplicationState()
		{
			ConnectedClients = new List<Client>();
		}

		#endregion

		public ApplicationState(IApplicationStateService applicationStateService) : this()
		{
			_applicationStateService = applicationStateService;
		}

		public void UpdateConnectedClients(IEnumerable<Client> clients)
		{
			ConnectedClients.Clear();

			_applicationStateService.SaveState(this);
		}

		private void SaveApplicationState()
		{
			_applicationStateService.SaveState(this);
		}
	}
}