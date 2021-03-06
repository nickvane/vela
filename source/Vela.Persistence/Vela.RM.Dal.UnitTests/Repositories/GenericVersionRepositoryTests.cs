﻿//-----------------------------------------------------------------------
// <copyright file="GenericVersionRepositoryTests.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Raven.Client;
using Rhino.Mocks;
using Vela.Common;
using Vela.Common.Dal;
using Vela.RM.Core.Common.ChangeControlPackage;
using Vela.RM.Core.Common.GenericPackage;
using Vela.RM.Core.Support.IdentificationPackage;
using Vela.RM.Dal.Repositories;
using Vela.RM.Dal.UnitTests.Repositories;
using Vela.RM.Domain.Entities;

namespace Vela.RM.Dal.UnitTests.Repositories
{
	[TestFixture]
	public class WhenUsingGenericVersionRepository
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_mocks = new MockRepository();
			_session = _mocks.StrictMock<IDocumentSession>();

			_collection = new List<VersionContainerTest>
			              	{
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id1),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id6),
			              				          		CommitAudit = new AuditDetails
			              				          		              	{
			              				          		              		TimeCommitted = new DateTime(2011, 3, 1)
			              				          		              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id7),
			              				          		CommitAudit = new AuditDetails
			              				          		              	{
			              				          		              		TimeCommitted = new DateTime(2010, 12, 24)
			              				          		              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id3),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id8),
			              				          		CommitAudit = new AuditDetails
			              				          		              	{
			              				          		              		TimeCommitted = new DateTime(2011, 2, 15)
			              				          		              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new OriginalVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id9),
			              				          		CommitAudit = new AuditDetails
			              				          		              	{
			              				          		              		TimeCommitted = new DateTime(2010, 5, 1)
			              				          		              	}
			              				          	}
			              			},
			              		new VersionContainerTest
			              			{
			              				Uid = new HierObjectId(_id2),
			              				Version = new ImportedVersion<VersionTest>
			              				          	{
			              				          		Uid = new ObjectVersionId(Id10),
			              				          		CommitAudit = new AuditDetails
			              				          		              	{
			              				          		              		TimeCommitted = new DateTime(2011, 2, 25)
			              				          		              	}
			              				          	}
			              			},
			              	}.AsQueryable();
			_repository = new GenericVersionRepository<VersionContainerTest, VersionTest>(_collection);
		}

		#endregion

		private MockRepository _mocks;
		private IDocumentSession _session;
		private IQueryable<VersionContainerTest> _collection;
		private GenericVersionRepository<VersionContainerTest, VersionTest> _repository;
		private readonly string _id1 = Guid.NewGuid().ToString();
		private readonly string _id2 = Guid.NewGuid().ToString();
		private readonly string _id3 = Guid.NewGuid().ToString();
		private const string Id6 = "ED378EAC-FDE9-4B50-9631-EE57992EA6FB::798061F2-09EC-4784-997B-FD5454127D16::1";
		private const string Id7 = "FE771BF3-9EB5-4DFA-A3F7-418BD8DD5A3C::0F9A6B36-EE9C-4D97-8BFB-CF097CEA53DB::1";
		private const string Id8 = "A780376B-1A1D-4FB3-BBC1-27B53D4D3B7B::7E5E85F8-40E2-4840-9F87-81EAAB76ED0F::1";
		private const string Id9 = "EABD7E2B-CAC5-454A-9150-BA2198419128::EC5C9FE8-1DF6-4762-8BFD-6BE0F083D0E6::1.1.2";
		private const string Id10 = "8B614C9C-9E29-4BDC-9696-5833E48093D5::0C5EDDB4-6312-4D56-858B-CD76D6AE37E0::1.2.2";


		[Test]
		public void GetAllVersions()
		{
			using (new DocumentSessionScope(_session))
			{
				IQueryable<VersionContainerTest> res = from v in _repository.Collection where v.Id == Id7 select v;
				List<VersionContainerTest> res2 = res.ToList();

				IList<VersionContainerTest> result = _repository.GetAllVersions(_id2);
				Assert.AreEqual(3, result.Count);

				result = _repository.GetAllVersions(_id1);
				Assert.AreEqual(1, result.Count);

				result = _repository.GetAllVersions(_id3);
				Assert.AreEqual(1, result.Count);
			}
		}

		[Test]
		public void GetLatestVersion()
		{
			using (new DocumentSessionScope(_session))
			{
				VersionContainerTest result = _repository.GetLatestVersion(_id2);
				Assert.AreEqual(Id10, result.Id);

				result = _repository.GetLatestVersion(_id1);
				Assert.AreEqual(Id6, result.Id);

				result = _repository.GetLatestVersion("foo");
				Assert.IsNull(result);
			}
		}

		[Test]
		public void GetLatestVersionFromTrunk()
		{
			using (new DocumentSessionScope(_session))
			{
				VersionContainerTest result = _repository.GetLatestVersionFromTrunk(_id2);
				Assert.AreEqual(Id7, result.Id);

				result = _repository.GetLatestVersionFromTrunk("foo");
				Assert.IsNull(result);
			}
		}

		[Test]
		public void GetVersionAndHasVersion()
		{
			Expect.Call(_session.Load<VersionContainerTest>(Id6)).Return(new VersionContainerTest());
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(_session))
			{
				Assert.IsTrue(_repository.HasVersion(Id6));
			}
			
			_mocks.VerifyAll();

			Assert.IsFalse(_repository.HasVersion(string.Empty));
		}

		[Test]
		public void IsOriginalVersionTrue()
		{
			Expect.Call(_session.Load<VersionContainerTest>(Id6)).Return(new VersionContainerTest
			{
				Version = new OriginalVersion<VersionTest>()
			});
			Expect.Call(() => _session.SaveChanges());
			Expect.Call(() => _session.Dispose());
			_mocks.ReplayAll();

			using (new DocumentSessionScope(_session))
			{
				Assert.IsTrue(_repository.IsOriginalVersion(Id6));
			}
			
			_mocks.VerifyAll();
		}
	}

	public class VersionTest : IDocument
	{
		#region IDocument Members

		public string Id { get; set; }

		public bool IsDeleted { get; set; }

		#endregion
	}
}

public class VersionContainerTest : GenericVersion<VersionTest>
{
}