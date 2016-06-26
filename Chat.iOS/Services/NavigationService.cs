// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.iOS.Services
{
	using UIKit;

	using Chat.iOS.Views;

	using Chat.Common;
	using Chat.Common.Presenter;
	using System.Collections.Generic;

	public class NavigationService : INavigationService
	{
		#region Private Properties

		private UINavigationController _navigationController;

		#endregion

		#region Constructors

		public NavigationService(UINavigationController navigationController)
		{
			_navigationController = navigationController;
		}

		#endregion

		#region INavigationService implementation

		public void PushPresenter(BasePresenter presenter)
		{
			if (presenter is ClientsListPresenter)
			{
				var viewController = new ClientsListViewController(presenter as ClientsListPresenter);
				_navigationController.PushViewController(viewController, true);
			}
			else if (presenter is ChatPresenter)
			{
				var viewController = new ChatViewController(presenter as ChatPresenter);
				_navigationController.PushViewController(viewController, true);
			}
		}

		#endregion
	}
}

