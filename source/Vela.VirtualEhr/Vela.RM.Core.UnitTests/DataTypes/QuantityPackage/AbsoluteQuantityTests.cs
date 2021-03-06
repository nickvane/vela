﻿//-----------------------------------------------------------------------
// <copyright file="AbsoluteQuantityTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.QuantityPackage;

namespace Vela.RM.Core.UnitTests.DataTypes.QuantityPackage
{
	[TestFixture]
	public class WhenUsingAbsoluteQuantity
	{
		[Test]
		public void DefaultPropertiesShouldBeSet()
		{
			var absoluteQuantityt1 = new AbsoluteQuantitytTest();
			Assert.IsTrue(absoluteQuantityt1.IsAccuracyUnknown());
			var accuracy = new AmountTest() {Magnitude = 2.5};
			absoluteQuantityt1.Accuracy = accuracy;
			Assert.AreEqual(accuracy, absoluteQuantityt1.Accuracy);
			Assert.IsFalse(absoluteQuantityt1.IsAccuracyUnknown());
		}
	}

	public class AbsoluteQuantitytTest : AbsoluteQuantity<AbsoluteQuantitytTest, AmountTest>
	{
		public override int CompareTo(AbsoluteQuantitytTest other)
		{
			throw new NotImplementedException();
		}

		public override double Magnitude
		{
			get; set; }

		public override AbsoluteQuantitytTest Add(AmountTest value)
		{
			throw new NotImplementedException();
		}

		public override AbsoluteQuantitytTest Subtract(AmountTest value)
		{
			throw new NotImplementedException();
		}

		public override AmountTest Diff(AbsoluteQuantitytTest value)
		{
			throw new NotImplementedException();
		}
	}
}