﻿//-----------------------------------------------------------------------
// <copyright file="CStringTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Aom.Primitives;

namespace Vela.AM.Aom.UnitTests.Primitives
{
	[TestFixture]
	public class WhenUsingCString
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new CString();
			instance.IsValidValue("");
		}
	}
}