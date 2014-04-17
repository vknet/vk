using System;
using System.Collections.Generic;
using System.Linq;

namespace VkNet.Enums.Filters
{
	public class Filter<TFilter> where TFilter : Filter<TFilter>, new()
	{
// ReSharper disable once StaticFieldInGenericType
		private static readonly Dictionary<ulong, string> PossibleValues = new Dictionary<ulong, string>();

		protected static TFilter RegisterPossibleValue(ulong mask, string value)
		{
			if (mask == 0 || (mask & (mask - 1)) != 0)
				throw new ArgumentException("Mask must be a power of 2 (i.e. only one bit must be equal to 1)", "mask");
			PossibleValues.Add(mask, value);

			var filter = new TFilter();
			filter._mask = (mask);
			return filter;
		}

		protected static TFilter RegisterPossibleValue(string value)
		{
			ulong mask = PossibleValues.Select(pair => pair.Key).DefaultIfEmpty().Max();
			mask = (mask == 0) ? 1 : (mask *= 2);

			if (mask == 0 || (mask & (mask - 1)) != 0)
				throw new ArgumentException("Mask must be a power of 2 (i.e. only one bit must be equal to 1)", "mask");
			

			PossibleValues.Add(mask, value);

			var filter = new TFilter();
			filter._mask = (mask);
			return filter;
		}

		private ulong _mask;

		protected ulong Mask
		{
			get { return _mask; }
		}

		protected Filter()
		{
			_mask = 0;
		}

		public override string ToString()
		{
			return string.Join(",", PossibleValues.Where(pair => (pair.Key & _mask) != 0).Select(pair => pair.Value));
		}

		public static TFilter operator |(Filter<TFilter> left, Filter<TFilter> right)
		{
			var filter = new TFilter { _mask = (left._mask | right._mask) };
			return filter;
		}


		public static bool operator ==(Filter<TFilter> left, Filter<TFilter> right)
		{
			if (ReferenceEquals(right, left)) return true;
			if (ReferenceEquals(null, left)) return false;
			if (ReferenceEquals(null, right)) return false;

			return left._mask == right._mask;
		}

		public static bool operator !=(Filter<TFilter> left, Filter<TFilter> right)
		{
			return !(left == right);
		}
		
		protected bool Equals(Filter<TFilter> other)
		{
			return _mask == other._mask;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Filter<TFilter>) obj);
		}
	}


/*	public class SampleFilter : Filter<SampleFilter>
	{
		public static readonly SampleFilter Val0 = RegisterPossibleValue(1L << 0, "val0");

		public static readonly SampleFilter Val1 = RegisterPossibleValue(1L << 1, "val1");

		public static readonly SampleFilter Val2 = RegisterPossibleValue(1L << 2, "val2");

		public static readonly SampleFilter All = Val0 | Val1 | Val2;
	}


	public class SampleUnstrictFilter : Filter<SampleUnstrictFilter>
	{
		public static SampleUnstrictFilter Val0 = RegisterPossibleValue("val0");

		public static SampleUnstrictFilter Val1 = RegisterPossibleValue("val1");

		public static SampleUnstrictFilter Val2 = RegisterPossibleValue("val2");

		public static SampleUnstrictFilter All = Val0 | Val1 | Val2;
	}
 */



}