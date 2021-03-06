﻿//-----------------------------------------------------------------------
// <copyright file="ArchetypeIdTests.cs" company="Vela">
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
	public class WhenUsingArchetypeIdWithValidValues
	{
		[Test]
		public void ValueShouldBeSetCorrectly()
		{
			const string referenceModelOriginator = "openEHR";
			const string referenceModelName = "composition";
			const string referenceModelEntity = "OBSERVATION";
			const string qualifiedReferenceModelEntity = referenceModelOriginator + "-" + referenceModelName + "-" + referenceModelEntity;
			const string conceptName = "biochemistry_result";
			const string specialisation = "cholesterol";
			const string domainConcept = conceptName + "-" + specialisation;
			const string versionId = "v1";
			const string value = qualifiedReferenceModelEntity + "." + domainConcept + "." + versionId;
			var id1 = new ArchetypeId(value);
			Assert.AreEqual(value, id1.Value);
			Assert.AreEqual(qualifiedReferenceModelEntity, id1.QualifiedReferenceModelEntity);
			Assert.AreEqual(referenceModelOriginator, id1.ReferenceModelOriginator);
			Assert.AreEqual(referenceModelName, id1.ReferenceModelName);
			Assert.AreEqual(referenceModelEntity, id1.ReferenceModelEntity);
			Assert.AreEqual(domainConcept, id1.DomainConcept);
			Assert.AreEqual(specialisation, id1.Specialisation);
			Assert.AreEqual(versionId, "v" + id1.VersionId);
			Assert.AreEqual(value, id1.ToString());
		}
	}

	[TestFixture]
	public class InValidValuesThrowsException
	{
		[ExpectedException(typeof(ArgumentException))]
		[TestCase("")]
		[TestCase(".")]
		[TestCase("...")]
		[TestCase("-..")]
		[TestCase("-.-.")]
		[TestCase("-.-.1")]
		[TestCase("openEHR-EHR-CLUSTER.exam-generic-lymphnode.v1")]
		public void ShouldThrowException(string value)
		{
			new ArchetypeId(value);
		}
	}
}