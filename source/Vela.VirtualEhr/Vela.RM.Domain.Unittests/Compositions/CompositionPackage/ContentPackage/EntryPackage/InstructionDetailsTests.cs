﻿//-----------------------------------------------------------------------
// <copyright file="InstructionDetailsTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.UnitTests.Compositions.CompositionPackage.ContentPackage.EntryPackage
{
	[TestFixture]
	public class WhenUsingInstructionDetails
	{
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetPathOfItemThrowsException()
		{
			var details = new InstructionDetails();
			details.GetPathOfItem(null);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemAtPathThrowsException()
		{
			var details = new InstructionDetails();
			details.GetItemAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void GetItemsAtPathThrowsException()
		{
			var details = new InstructionDetails();
			details.GetItemsAtPath(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void DoesPathExistsThrowsException()
		{
			var details = new InstructionDetails();
			details.DoesPathExists(string.Empty);
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void IsPathUniqueThrowsException()
		{
			var details = new InstructionDetails();
			details.IsPathUnique(string.Empty);
		}
	}
}