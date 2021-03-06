﻿//-----------------------------------------------------------------------
// <copyright file="ResourceDescriptionItemTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.RM.Core.Common.ResourcePackage;

namespace Vela.RM.Core.UnitTests.Common.ResourcePackage
{
	[TestFixture]
	public class WhenUsingResourceDescriptionItem
	{
		[Test]
		public void ListPropertiesAreNotNull()
		{
			var item = new ResourceDescriptionItem();
			Assert.IsNotNull(item.Keywords);
			Assert.IsNotNull(item.OriginalResourceUri);
			Assert.IsNotNull(item.OtherDetails);
		}
	}
}