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
}