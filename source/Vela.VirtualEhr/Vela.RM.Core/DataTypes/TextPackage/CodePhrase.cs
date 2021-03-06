﻿//-----------------------------------------------------------------------
// <copyright file="CodePhrase.cs" company="Vela">
//     Copyright © Vela. All rights reserved.
// </copyright>
// <author>Nick Van Eeckhout</author>
//-----------------------------------------------------------------------

using System;
using Vela.RM.Core.Support;
using Vela.RM.Core.Support.IdentificationPackage;

namespace Vela.RM.Core.DataTypes.TextPackage
{
	/// <summary>
	/// A fully coordinated (i.e. all “coordination” has been performed) term from a terminology service (as distinct from a particular terminology).
	/// </summary>
	[Serializable]
	[OpenEhrName("CODE_PHRASE")]
	public class CodePhrase
	{
		/// <summary>
		/// Identifier of the distinct terminology from which the code_string (or its elements) was extracted.
		/// </summary>
		/// <param name="value"></param>
		public CodePhrase(string value)
		{
			CodeString = value;
		}

		/// <summary>
		/// Identifier of the distinct terminology from which the code_string (or its elements) was extracted.
		/// </summary>
		[OpenEhrName("code_string")]
		public string CodeString
		{
			get;
			set;
		}
		/// <summary>
		/// The key used by the terminology service to identify a concept or coordination of concepts. This string is most likely parsable inside the terminology service, but nothing can be assumed about its syntax outside that context.
		/// </summary>
		[OpenEhrName("terminology_id")]
		public TerminologyId TerminologyId
		{
			get;
			set;
		}
	}
}