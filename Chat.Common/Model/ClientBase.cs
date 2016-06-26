// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientBase.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Chat.Common.Model
{
	using System;
	using System.Net;

	/// <summary>
	/// Represents a 'property search', which can either be a plain-text search term
	/// or a geolocation.
	/// </summary>
	public abstract class ClientBase
	{
		/// <summary>
		/// The text displayed to the user for this search
		/// </summary>
		public string DisplayText { get; set; }

		/// <summary>
		/// Executes the search that this item represents.
		/// </summary>
		//public abstract void FindProperties(PropertyDataSource dataSource,
		//  int pageNumber, Action<PropertyDataSourceResult> callback, Action<Exception> error);
	}
}