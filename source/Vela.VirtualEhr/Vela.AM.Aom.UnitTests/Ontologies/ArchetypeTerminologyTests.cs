﻿//-----------------------------------------------------------------------
// <copyright file="ArchetypeTerminologyTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using NUnit.Framework;
using Vela.AM.Aom.Ontologies;

namespace Vela.AM.Aom.UnitTests.Ontologies
{
	[TestFixture]
	public class WhenUsingArchetypeTerminology
	{
		[Test]
		public void ListsAreNotNull()
		{
			var archetypeTerminology = new ArchetypeTerminology();
			Assert.IsNotNull(archetypeTerminology.Items);
		}
	}
}