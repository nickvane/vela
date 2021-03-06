﻿//-----------------------------------------------------------------------
// <copyright file="CompositionVersionRepositoryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.RM.Dal.Repositories;

namespace Vela.RM.Dal.UnitTests.Repositories
{
	[TestFixture]
	public class WhenUsingCompositionVersionRepository
	{
		[Test]
		public void TestConstructor()
		{
			var repository = new CompositionVersionRepository(null);
		}
	}
}