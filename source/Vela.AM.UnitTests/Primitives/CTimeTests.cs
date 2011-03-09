﻿//-----------------------------------------------------------------------
// <copyright file="CTimeTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Primitives;

namespace Vela.AM.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCTime
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CTime();
			instance.IsValidValue(null);
		}
	}
}