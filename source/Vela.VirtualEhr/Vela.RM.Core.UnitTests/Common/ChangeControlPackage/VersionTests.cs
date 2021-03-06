﻿//-----------------------------------------------------------------------
// <copyright file="VersionTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.Common.ChangeControlPackage;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.UnitTests.Common.ChangeControlPackage
{
	[TestFixture]
	public class WhenUsingVersion
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetOwnerIdShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.GetOwnerId();
		}

		[Test]
		public void IsBranchShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			Assert.IsFalse(version.IsBranch);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void CanonicalFormShouldThrowException()
		{
			var version = new OriginalVersion<string>();
			var result = version.GetCanonicalForm();
		}
	}

	public class Versiontest : Version<string>
	{
		public override ObjectVersionId Uid { get; set; }
		public override ObjectVersionId PrecedingVersionUid { get; set; }
		public override string Data { get; set; }
		public override CodedText LifecycleState { get; set; }
	}
}