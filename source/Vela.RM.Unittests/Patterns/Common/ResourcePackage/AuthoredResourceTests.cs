﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vela.RM.Core.DataTypes.TextPackage;
using Vela.RM.Patterns.Common.GenericPackage;
using Vela.RM.Patterns.Common.ResourcePackage;

namespace Vela.RM.Unittests.Patterns.Common.ResourcePackage
{
	[TestFixture]
	public class WhenUsingAuthoredResource
	{
		[Test]
		public void ShouldReturnAllAvailableLanguages()
		{
			var res = new AuthoredResourceTest();
			Assert.AreEqual(0, res.GetAvailableLanguages().Count);
			const string en = "EN";
			const string nl = "NL";
			const string fr = "FR";
			res.OriginalLanguage = new CodePhrase(en);
			Assert.AreEqual(1, res.GetAvailableLanguages().Count);
			res.Translations.Add(nl, new TranslationDetails());
			Assert.AreEqual(2, res.GetAvailableLanguages().Count);
			res.Translations.Add(en, new TranslationDetails());
			Assert.AreEqual(2, res.GetAvailableLanguages().Count);
			res.Translations.Add(fr, new TranslationDetails());
			Assert.AreEqual(3, res.GetAvailableLanguages().Count);
			Assert.IsTrue(res.GetAvailableLanguages().Contains(en));
			Assert.IsTrue(res.GetAvailableLanguages().Contains(fr));
			Assert.IsTrue(res.GetAvailableLanguages().Contains(nl));
			res.Translations = new Dictionary<string, TranslationDetails>();
		}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void ShouldReturnCurrentRevision()
		{
			var res = new AuthoredResourceTest();
			Assert.AreEqual(string.Empty, res.GetCurrentRevision());
			res.IsControlled = true;
			Assert.AreEqual(string.Empty, res.GetCurrentRevision());
			res.RevisionHistory = new RevisionHistory();
			var revision = res.GetCurrentRevision();
		}
	}

	public class AuthoredResourceTest : AuthoredResource
	{
	}
}
