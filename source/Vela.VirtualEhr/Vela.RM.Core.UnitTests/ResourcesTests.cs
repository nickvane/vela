﻿//-----------------------------------------------------------------------
// <copyright file="ResourcesTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;

namespace Vela.RM.Core.UnitTests
{
	[TestFixture]
	public class WhenUsingResources
	{
		[Test]
		public void ThereShouldBeNoErrors()
		{
			var culture = Properties.Resources.Culture;
			Properties.Resources.Culture = culture;

			var resources = new Properties.Resources();
			Assert.IsNotNullOrEmpty(Properties.Resources.InvalidVersionId);
		}
	}
}