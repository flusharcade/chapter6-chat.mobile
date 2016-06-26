// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Droid.Services
{
	using Chat.Droid.Views;

	using System;

	using Android.Content;

	using Chat.Common;
	using Chat.Common.Presenter;

	public class NavigationService : INavigationService
	{
		private ChatApplication _application;

		public NavigationService(ChatApplication application)
		{
			_application = application;
		}

		public void PushPresenter(BasePresenter presenter)
		{
			var oldPresenter = _application.Presenter as BasePresenter;

			if (presenter != oldPresenter)
			{
				_application.Presenter = presenter;
				Intent intent = null;

				if (presenter is ClientsListPresenter)
				{
					intent = new Intent(_application.CurrentActivity, typeof(ClientsListView));
				}

				if (intent != null)
				{
					_application.CurrentActivity.StartActivity(intent);
				}
			}
		}
	}
}