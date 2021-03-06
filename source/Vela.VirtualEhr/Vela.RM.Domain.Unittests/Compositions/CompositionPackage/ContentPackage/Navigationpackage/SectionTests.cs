﻿//-----------------------------------------------------------------------
// <copyright file="SectionTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.NavigationPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage.ContentPackage.Navigationpackage
{
	[TestFixture]
	public class WhenUsingSection
	{
		[Test]
		public void ListsAreNotNull()
		{
			var section = new Section();
			Assert.IsNotNull(section.Items);
		}
	}
}