﻿using System;
using Vela.RM.Core.DataTypes.BasicPackage;
using Vela.RM.Core.Support;

namespace Vela.RM.Core.DataTypes.QuantityPackage
{
	/// <summary>
	/// Generic class defining an interval (i.e. range) of a comparable type. An interval is a contiguous subrange of a comparable base type.
	/// USE: Used to define intervals of dates, times, quantities (whose units match) and so on. The type parameter, T, must be a descendant of the type <see cref="Ordered"/>, which is necessary (but not sufficient) for instances to be compared (strictly_comparable is also needed).
	/// Without the IntervalType class, quite a few more DataValue classes would be needed to express logical intervals, namely interval versions of all the date/time classes, and of quantity classes. Further, it allows the semantics of intervals to be stated in one place unequivocally, including the conditions for strict comparison.
	/// The basic semantics are derived from the class IntervalType, described in the support RM.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable, OpenEhrName("DV_INTERVAL<T : DV_ORDERED>")]
	public class Interval<T> : DataValue where T : Ordered
	{
		private bool _isLowerIncluded;
		private bool _isUpperIncluded;

		/// <summary>
		/// lower bound
		/// </summary>
		public T Lower
		{
			get;
			set;
		}

		/// <summary>
		/// upper bound
		/// </summary>
		public T Upper
		{
			get;
			set;
		}

		/// <summary>
		/// lower boundary open (i.e. = -infinity)
		/// </summary>
		public bool IsLowerUnbounded
		{
			get
			{
				return Lower == null;
			}
		}

		/// <summary>
		/// upper boundary open (i.e. = +infinity)
		/// </summary>
		public bool IsUpperUnbounded
		{
			get
			{
				return Upper == null;
			}
		}

		/// <summary>
		/// lower boundary value included in range if not lower_unbounded
		/// </summary>
		public bool IsLowerIncluded
		{
			get
			{
				return Lower != null && _isLowerIncluded;
			}
			set
			{
				_isLowerIncluded = value;
			}
		}

		/// <summary>
		/// upper boundary value included in range if not upper_unbounded
		/// </summary>
		public bool IsUpperIncluded
		{
			get
			{
				return Upper != null && _isUpperIncluded;
			}
			set
			{
				_isUpperIncluded = value;
			}
		}

		/// <summary>
		/// True if (lower_unbounded or ((lower_included and v >= lower) or v > lower)) and (upper_unbounded or ((upper_included and v <![CDATA[<]]>= upper or v <![CDATA[<]]> upper)))
		/// </summary>
		public bool HasElement(T element)
		{
			return (IsLowerUnbounded || ((IsLowerIncluded && element >= Lower) || element > Lower)) &&
				   (IsUpperUnbounded || ((IsUpperIncluded && element <= Upper || element < Upper)));
		}
	}
}