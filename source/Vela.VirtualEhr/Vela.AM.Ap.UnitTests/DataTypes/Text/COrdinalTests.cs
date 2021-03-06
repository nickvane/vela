﻿//-----------------------------------------------------------------------
// <copyright file="COrdinalTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.AM.Ap.DataTypes.Quantity;

namespace Vela.AM.Ap.UnitTests.DataTypes.Text
{
	[TestFixture]
	public class WhenUsingCOrdinal
	{
		[Test]
		public void ListsAreNotNull()
		{
			var instance = new COrdinal();
			Assert.IsNotNull(instance.Ordinals);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsSubsetOfThrowsException()
		{
			var instance = new COrdinal();
			var result = instance.IsSubsetOf(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidThrowsException()
		{
			var instance = new COrdinal();
			var result = instance.IsValid();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DefaultValueThrowsException()
		{
			var instance = new COrdinal();
			var result = instance.DefaultValue();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsValidValueThrowsException()
		{
			var instance = new COrdinal();
			var result = instance.IsValidValue(null);
		}
	}
}