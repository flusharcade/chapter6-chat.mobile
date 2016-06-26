// --------------------------------------------------------------------------------------------------
//  <copyright file="ClientsListViewController.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Chat.Droid
{
	using System;

	using Android.App;
	using Android.Content;
	using Android.Runtime;

	[Application]
	public class ChatApplication : Application
	{
		#region Public Properties

		public object Presenter
		{
			get;
			set;
		}

		public Activity CurrentActivity
		{
			get;
			set;
		}

		#endregion

		#region Constructors

		public ChatApplication()
			: base()
		{
		}

		public ChatApplication(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		#endregion

		#region Public Methods

		public static ChatApplication GetApplication(Context context)
		{
			return (ChatApplication)context.ApplicationContext;
		}

		#endregion
	}
}