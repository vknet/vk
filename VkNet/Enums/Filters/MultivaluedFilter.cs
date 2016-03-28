using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Объект перечисления типа <typeparam name="TFilter">Непосредственно наследник</typeparam></returns>
		public static TFilter FromJson(VkResponse response)
		{
			var value = response.ToString();
			return FromJson(value);
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Объект перечисления типа <typeparam name="TFilter">Непосредственно наследник</typeparam></returns>
		public static TFilter FromJson(string response)
		{
			var result = new TFilter();
			var items = response.Split(new []{ ',' }, StringSplitOptions.RemoveEmptyEntries);
			var isFirst = true;
			foreach (var item in items)
			{
				if (isFirst)
				{
					result = CreateFromMask(RegisterPossibleValue(item).Mask);
					isFirst = false;
				}
				else
				{
					result = result | CreateFromMask(RegisterPossibleValue(item).Mask);
				}
			}

			return result;
		}
	}
}