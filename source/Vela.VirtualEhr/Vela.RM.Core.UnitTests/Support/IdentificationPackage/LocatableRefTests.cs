﻿//-----------------------------------------------------------------------
// <copyright file="LocatableRefTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Support.IdentificationPackage
{
	[TestFixture]
	public class WhenUsingLocatableRef
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			var objectVersionId = Guid.NewGuid() + "::" + Guid.NewGuid() + "::" + 1;
			string path = "test";	
			var id = new LocatableRef()
			         	{
							Id = new ObjectVersionId(objectVersionId),
			         		Path = path
			};
			Assert.AreEqual("ehr://" + objectVersionId + "/" + path, id.ToUri());
		}
	}
}