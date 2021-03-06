﻿//-----------------------------------------------------------------------
// <copyright file="Section.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;
using Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.EntryPackage;

namespace Vela.RM.Domain.Compositions.CompositionPackage.ContentPackage.NavigationPackage
{
	/// <summary>
	/// Represents a heading in a heading structure, or “section tree”.
	/// Created according to archetyped structures for typical headings such as SOAP, physical examination, but also pathology result heading structures.
	/// Should not be used instead of ENTRY hierarchical structures.
	/// </summary>
	[Serializable]
	[OpenEhrName("SECTION")]
	public class Section : ContentItem	
	{
		private IList<ContentItem> _items;

		/// <summary>
		/// Ordered list of content items under this section, which may include:
		/// more <see cref="Section"/>s or <see cref="Entry"/>s
		/// </summary>
		[OpenEhrName("items")]
		public IList<ContentItem> Items
		{
			get
			{
				return _items ?? (_items = new List<ContentItem>());
			}
		}
	}
}