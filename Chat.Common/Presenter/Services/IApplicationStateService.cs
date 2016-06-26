// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IApplicationStateService.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Presenter
{
	public interface IApplicationStateService
	{
		void SaveState(ApplicationState state);

		ApplicationState LoadState();
	}
}