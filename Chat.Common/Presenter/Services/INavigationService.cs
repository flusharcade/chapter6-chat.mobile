// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common
{
	using Chat.Common.Presenter;

	public interface INavigationService
    {
		void PushPresenter(BasePresenter presenter);
    }
}