﻿//-----------------------------------------------------------------------
// <copyright file="ElementTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataStructures.RepresentationPackage;

namespace Vela.RM.Core.UnitTests.DataStructures.RepresentationPackage
{
	[TestFixture]
	public class WhenUsingElement
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsNullShouldThrowException()
		{
			var element = new Element();
			var result = element.IsNull();
		}
	}
}