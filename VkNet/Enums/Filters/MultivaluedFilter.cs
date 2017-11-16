using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Utils;

namespace VkNet.Enums.Filters
{
    /// <summary>
    /// Фильтр, хранящий несколько значений и представляющий их в виде набора строковых представлений каждого возможного значения фильтра.
    /// Аналог enum с атрибутом [Flags].
    /// </summary>
    /// <typeparam name="TFilter">Непосредственно наследник</typeparam>
    public class MultivaluedFilter<TFilter> where TFilter : MultivaluedFilter<TFilter>, new()
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
        protected internal List<string> Selected { get; private set; } = new List<string>();

        /// <summary>
		/// Реализация оператора ==.
		/// </summary>
		/// <param name="left">Левая часть.</param>
		/// <param name="right">Правая часть.</param>
		/// <returns>
		/// Результат.
		/// </returns>
        public static bool operator ==([NotNull] MultivaluedFilter<TFilter> left, [NotNull] MultivaluedFilter<TFilter> right)
        {
            if (ReferenceEquals(right, left))
            { return true; }
            if (ReferenceEquals(null, left))
            { return false; }
            if (ReferenceEquals(null, right))
            { return false; }

            return left.Selected.SequenceEqual(right.Selected);
        }

        /// <summary>
		/// Реализация оператора !=.
		/// </summary>
		/// <param name="left">Левая часть.</param>
		/// <param name="right">Правая часть.</param>
		/// <returns>
		/// Результат.
		/// </returns>

        public static bool operator !=(MultivaluedFilter<TFilter> left, MultivaluedFilter<TFilter> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Регистрирует возможное значение.
        /// </summary>
        /// <param name="mask">Маска.</param>
        /// <param name="value">Значение.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Mask must be left power of 2 (i.e. only one bit must be equal to 1);mask</exception>
        protected static TFilter RegisterPossibleValue(ulong mask, string value)
        {
            return FromJson(value);
        }

        /// <summary>
        /// Регистрирует возможное значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Mask must be left power of 2 (i.e. only one bit must be equal to 1);mask</exception>
        protected static TFilter RegisterPossibleValue(string value)
        {
            return FromJson(value);
        }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Объект перечисления типа TFilter Непосредственно наследник</returns>
		public static TFilter FromJson(VkResponse response)
        {
            var value = response.ToString();
            return FromJson(value);
        }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="val">Ответ сервера.</param>
        /// <returns></returns>
        public static TFilter FromJson(string val)
        {
            var vals = val.Split(',').Select(x => x.Trim());

            var result = new TFilter();

            result.Selected.AddRange(vals.OrderBy(x => x));

            return result;
        }

        /// <summary>
        /// Преобразовать в строку.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",", Selected.ToArray());
        }

        /// <summary>
        /// Объединяет наборы фильтров
        /// </summary>
        /// <param name="a">Первый набор фильтров</param>
        /// <param name="b">Второй набор фильтров</param>
        /// <returns>Объединенный набор фильтров</returns>
        public static TFilter operator |(MultivaluedFilter<TFilter> a, MultivaluedFilter<TFilter> b)
        {
            return new TFilter { Selected = a.Selected.Union(b.Selected).OrderBy(x => x).ToList() };
        }

        /// <summary>
        /// Сравнить с элементом
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected bool Equals(MultivaluedFilter<TFilter> other)
        {
            return this == other;
        }

        /// <summary>
        /// Сравнить с элементом
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //if (ReferenceEquals(null, obj))
            //{
            //    return false;
            //}
            //if (ReferenceEquals(this, obj))
            //{
            //    return true;
            //}
            return obj.GetType() == GetType() && Equals((MultivaluedFilter<TFilter>)obj);
        }

        /// <summary>
        /// Полушить Хеш код
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Selected?.GetHashCode() ?? 0;
        }
    }
}