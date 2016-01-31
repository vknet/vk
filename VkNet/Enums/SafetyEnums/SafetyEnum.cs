using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace VkNet.Enums.SafetyEnums
{

    /// <summary>
    /// Аналог enum, типобезопасен.
    /// </summary>
    /// <typeparam name="TFilter">Непосредственно наследник</typeparam>
    [Serializable]
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class SafetyEnum <TFilter> where TFilter : SafetyEnum<TFilter>, new()
	{
		/// <summary>
		/// Аналог enum, типобезопасен.
		/// </summary>
		protected SafetyEnum()
		{
			_mask = 0;
		}

		/// <summary>
		/// Возможные значения
		/// </summary>
		private static readonly Dictionary<ulong, string> PossibleValues = new Dictionary<ulong, string>();

		/// <summary>
		/// Маска.
		/// </summary>
		private ulong _mask;

		/// <summary>
		/// Создать из маски.
		/// </summary>
		/// <param name="mask">Маска.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">mask</exception>
		protected static TFilter CreateFromMask(ulong mask)
		{
			//Если в маске находятся незарегистрированные в словаре биты
			if(PossibleValues.Select(pair => pair.Key)
				.Where(key => (mask & key) != 0)
				.DefaultIfEmpty((ulong)0)
				.Aggregate(mask, (current, @ulong) => current - @ulong)
				!= 0)
				throw new ArgumentException(string.Format("Mask contains value(s) that not defined for type {0} (mask except known values: {1:x8})", typeof (TFilter).FullName, PossibleValues.Select(pair => pair.Key).Where(key => (mask & key) != 0).Aggregate(mask, (current, @ulong) => current - @ulong)), "mask");

			return new TFilter { _mask = mask };
		}



		/// <summary>
		/// Маска.
		/// </summary>
		protected ulong Mask
		{
			get { return _mask; }
		}

		/// <summary>
		/// Регистрирует возможное значение.
		/// </summary>
		/// <param name="mask">Маска.</param>
		/// <param name="value">Значение.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Mask must be a power of 2 (i.e. only one bit must be equal to 1);mask</exception>
		protected static TFilter RegisterPossibleValue(ulong mask, string value)
		{
			if (mask == 0 || (mask & (mask - 1)) != 0)
			{
				throw new ArgumentException("Mask must be a power of 2 (i.e. only one bit must be equal to 1)", "mask");
			}
			PossibleValues.Add(mask, value);

			return CreateFromMask(mask);
		}

		/// <summary>
		/// Регистрирует возможное значение.
		/// </summary>
		/// <param name="value">Значение.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Mask must be a power of 2 (i.e. only one bit must be equal to 1);mask</exception>
		protected static TFilter RegisterPossibleValue(string value)
		{
			var mask = PossibleValues.Select(pair => pair.Key).DefaultIfEmpty().Max();
			mask = (mask == 0) ? 1 : (mask*2);

			if (mask == 0 || (mask & (mask - 1)) != 0)
			{
				throw new ArgumentException("Mask must be a power of 2 (i.e. only one bit must be equal to 1)", "mask");
			}

			PossibleValues.Add(mask, value);

			return CreateFromMask(mask);
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			return string.Join(",", PossibleValues.Where(pair => (pair.Key & _mask) != 0).Select(pair => pair.Value).ToArray());
		}

		/// <summary>
		/// Реализация оператора ==.
		/// </summary>
		/// <param name="left">Левая часть.</param>
		/// <param name="right">Правая часть.</param>
		/// <returns>
		/// Результат.
		/// </returns>
		public static bool operator ==(SafetyEnum<TFilter> left, SafetyEnum<TFilter> right)
		{
			if (ReferenceEquals(right, left)) { return true;}
			if (ReferenceEquals(null, left)) { return false;}
			if (ReferenceEquals(null, right)) { return false;}

			return left._mask == right._mask;
		}

		/// <summary>
		/// Реализация оператора !=.
		/// </summary>
		/// <param name="left">Левая часть.</param>
		/// <param name="right">Правая часть.</param>
		/// <returns>
		/// Результат.
		/// </returns>
		public static bool operator !=(SafetyEnum<TFilter> left, SafetyEnum<TFilter> right)
		{
			return !(left == right);
		}

		/// <summary>
		/// Сравнение с другим перечислением.
		/// </summary>
		/// <param name="other">Другое перечисление.</param>
		/// <returns></returns>
		protected bool Equals(SafetyEnum<TFilter> other)
		{
			return _mask == other._mask;
		}

		/// <summary>
		/// Сравнение с другим перечислением.
		/// </summary>
		/// <param name="obj">Другое перечисление.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) { return false;}
			if (ReferenceEquals(this, obj)) { return true;}
			if (obj.GetType() != GetType()) { return false;}
			return Equals((SafetyEnum<TFilter>) obj);
		}

		/// <summary>
		/// Возвращает хэш-код для этого экземпляра.
		/// </summary>
		/// <returns>
		/// Хэш-код для этого экземпляра, подходит для использования в алгоритмах хэширования и структуры данных, как хэш-таблицы.
		/// </returns>
		public override int GetHashCode()
		{
			return _mask.GetHashCode();
		}
	}
}