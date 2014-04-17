namespace VkNet.Enums.BaseFilters
{
	public class MultivaluedFilter <TFilter> : Filter<TFilter> where TFilter : MultivaluedFilter<TFilter>, new()
	{
// ReSharper disable once StaticFieldInGenericType

		public static TFilter operator |(MultivaluedFilter<TFilter> left, MultivaluedFilter<TFilter> right)
		{
			var filter = new TFilter { _mask = (left._mask | right._mask) };
			return filter;
		}
	}


/*	public class SampleFilter : MultivaluedFilter<SampleFilter>
	{
		public static readonly SampleFilter Val0 = RegisterPossibleValue(1L << 0, "val0");

		public static readonly SampleFilter Val1 = RegisterPossibleValue(1L << 1, "val1");

		public static readonly SampleFilter Val2 = RegisterPossibleValue(1L << 2, "val2");

		public static readonly SampleFilter All = Val0 | Val1 | Val2;
	}


	public class SampleUnstrictFilter : MultivaluedFilter<SampleUnstrictFilter>
	{
		public static SampleUnstrictFilter Val0 = RegisterPossibleValue("val0");

		public static SampleUnstrictFilter Val1 = RegisterPossibleValue("val1");

		public static SampleUnstrictFilter Val2 = RegisterPossibleValue("val2");

		public static SampleUnstrictFilter All = Val0 | Val1 | Val2;
	}
 */
}