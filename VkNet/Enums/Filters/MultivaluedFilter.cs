using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Фильтр, хранящий несколько значений и представляющий их в виде набора строковых представлений каждого возможного значения фильтра.
	/// Аналог enum с атрибутом [Flags].
	/// </summary>
	/// <typeparam name="TFilter">Непосредственно наследник</typeparam>
	public class MultivaluedFilter <TFilter> : SafetyEnum<TFilter> where TFilter : MultivaluedFilter<TFilter>, new()
	{
		/// <summary>
		/// Объединяет наборы фильтров
		/// </summary>
		/// <param name="left">Первый набор фильтров</param>
		/// <param name="right">Второй набор фильтров</param>
		/// <returns>Объединенный набор фильтров</returns>
		public static TFilter operator |(MultivaluedFilter<TFilter> left, MultivaluedFilter<TFilter> right)
		{
			return CreateFromMask(left.Mask | right.Mask);
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