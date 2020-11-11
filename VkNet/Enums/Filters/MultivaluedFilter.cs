using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Utils;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Фильтр, хранящий несколько значений и представляющий их в виде набора строковых
	/// представлений каждого возможного
	/// значения фильтра.
	/// Аналог enum с атрибутом [Flags].
	/// </summary>
	/// <typeparam name="TFilter"> Непосредственно наследник </typeparam>
	public class MultivaluedFilter<TFilter> : IEqualityComparer<MultivaluedFilter<TFilter>>, IEquatable<MultivaluedFilter<TFilter>>
			where TFilter : MultivaluedFilter<TFilter>, new()
	{
		/// <summary>
		/// Аналог enum, типобезопасен.
		/// </summary>
		protected MultivaluedFilter()
		{
		}

		/// <summary>
		/// Выбранные элементы
		/// </summary>
		private List<string> Selected { get; set; } = new List<string>();

		/// <inheritdoc />
		public bool Equals(MultivaluedFilter<TFilter> x, MultivaluedFilter<TFilter> y)
		{
			if (x is null)
			{
				return false;
			}

			if (y is null)
			{
				return false;
			}

			if (ReferenceEquals(objA: y, objB: x))
			{
				return true;
			}

			return x.Selected.SequenceEqual(second: y.Selected);
		}

		/// <inheritdoc />
		public int GetHashCode(MultivaluedFilter<TFilter> obj)
		{
			return Selected != null ? Selected.GetHashCode() : 0;
		}

		/// <inheritdoc />
		public bool Equals(MultivaluedFilter<TFilter> other)
		{
			return Equals(x: this, y: other);
		}

		/// <summary>
		/// Регистрирует возможное значение.
		/// </summary>
		/// <param name="mask"> Маска. </param>
		/// <param name="value"> Значение. </param>
		/// <returns> </returns>
		/// <exception cref="System.ArgumentException">
		/// Mask must be left power of 2 (i.e.
		/// only one bit must be equal to 1);mask
		/// </exception>
		protected static TFilter RegisterPossibleValue(ulong mask, string value)
		{
			return FromJsonString(val: value);
		}

		/// <summary>
		/// Регистрирует возможное значение.
		/// </summary>
		/// <param name="value"> Значение. </param>
		/// <returns> </returns>
		/// <exception cref="System.ArgumentException">
		/// Mask must be left power of 2 (i.e.
		/// only one bit must be equal to 1);mask
		/// </exception>
		protected static TFilter RegisterPossibleValue(string value)
		{
			return FromJsonString(val: value);
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Объект перечисления типа TFilter Непосредственно наследник </returns>
		public static TFilter FromJson(VkResponse response)
		{
			var value = response.ToString();

			return FromJsonString(val: value);
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="val"> Ответ сервера. </param>
		/// <returns> </returns>
		public static TFilter FromJsonString(string val)
		{
			var vals = val.Split(',').Select(selector: x => x.Trim());

			var result = new TFilter();

			result.Selected.AddRange(collection: vals.OrderBy(keySelector: x => x));

			return result;
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			return string.Join(separator: ",", value: Selected.ToArray());
		}

		/// <summary>
		/// Объединяет наборы фильтров
		/// </summary>
		/// <param name="a"> Первый набор фильтров </param>
		/// <param name="b"> Второй набор фильтров </param>
		/// <returns> Объединенный набор фильтров </returns>
		public static TFilter operator |(MultivaluedFilter<TFilter> a, MultivaluedFilter<TFilter> b)
		{
			return new TFilter { Selected = a.Selected.Union(second: b.Selected).OrderBy(keySelector: x => x).ToList() };
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return obj?.GetType() == GetType() && Equals(x: this, y: (MultivaluedFilter<TFilter>) obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return GetHashCode(obj: this);
		}
	}
}