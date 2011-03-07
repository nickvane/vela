﻿using System;
using System.Collections.Generic;
using Vela.RM.Core.Support;

namespace Vela.AM.ConstraintModel
{
	/// <summary>
	/// Constraint on complex objects, i.e. any object that consists of other object constraints.
	/// </summary>
	[OpenEhrName("C_COMPLEX_OBJECT")]
	public class CComplexObject : CDefinedObject
	{
		private HashSet<CAttribute> _attributes;

		/// <summary>
		/// List of constraints on attributes of the reference model type represented by this object.
		/// </summary>
		[OpenEhrName("attributes")]
		public HashSet<CAttribute> Attributes
		{
			get { return _attributes ?? (_attributes = new HashSet<CAttribute>()); }
		}

		#region Overrides of ArchetypeConstraint

		/// <summary>
		/// True if constraints represented by other are narrower than this node. Note: not easily evaluatable for CONSTRAINT_REF nodes.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public override bool IsSubsetOf(ArchetypeConstraint other)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if this node (and all its sub-nodes) is a valid archetype node for its type. This function should be implemented by each subtype to perform semantic validation of itself, and then call the is_valid function in any subparts, and generate the result appropriately
		/// </summary>
		/// <returns></returns>
		public override bool IsValid()
		{
			throw new NotImplementedException();
		}

		#endregion

		/// <summary>
		/// Generate a default value from this constraint object
		/// </summary>
		/// <returns></returns>
		public override object DefaultValue()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if any value of the reference model type being constrained is allowed.
		/// </summary>
		public override bool AnyAllowed()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// True if a_value is valid with respect to constraint expressed in concrete instance of this type.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValidValue(object value)
		{
			throw new NotImplementedException();
		}
	}
}