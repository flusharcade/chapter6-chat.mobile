// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IView.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Presenter
{
	public interface IView
	{
		void SetErrorMessage(string message);

		bool IsInProgress { get; set; }
	}
}