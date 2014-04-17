using System;
using System.Collections.Generic;
using System.Linq;

namespace VkNet.Enums.BaseFilters
{
	public class Filter <TFilter> where TFilter : Filter<TFilter>, new()
	{
		private static readonly Dictionary<ulong, string> PossibleValues = new Dictionary<ulong, string>();
		protected ulong _mask;

		protected Filter()
		{
			_mask = 0;
		}

		protected ulong Mask
		{
			get { return _mask; }
		}

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

		public override string ToString()
		{
			return string.Join(",", PossibleValues.Where(pair => (pair.Key & _mask) != 0).Select(pair => pair.Value));
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
			if (obj.GetType() != GetType()) return false;
			return Equals((Filter<TFilter>) obj);
		}
	}
}