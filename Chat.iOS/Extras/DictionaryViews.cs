// --------------------------------------------------------------------------------------------------
//  <copyright file="DictionaryViews.cs" company="Flush Arcade.">
//    Copyright (c) 2014 Flush Arcade. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Chat.iOS.Extras
{
	using System.Collections;

	using Foundation;
	using UIKit;

	public class DictionaryViews : IEnumerable
	{
		private readonly NSMutableDictionary nsDictionary;

		public DictionaryViews()
		{
			nsDictionary = new NSMutableDictionary();
		}

		public void Add(string name, UIView view)
		{
			nsDictionary.Add(new NSString(name), view);
		}

		public static implicit operator NSDictionary(DictionaryViews us)
		{
			return us.ToNSDictionary();
		}

		public NSDictionary ToNSDictionary()
		{
			return nsDictionary;
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)nsDictionary).GetEnumerator();
		}
	}
}