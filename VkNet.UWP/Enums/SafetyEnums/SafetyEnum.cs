using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{

    /// <summary>
    /// Аналог enum, типобезопасен.
    /// </summary>
    /// <typeparam name="TFilter">Непосредственно наследник</typeparam>
    [DataContract]
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public abstract class SafetyEnum <TFilter> where TFilter : SafetyEnum<TFilter>, new()
	{
		/// <summary>
		/// Аналог enum, типобезопасен.
		/// </summary>
		protected SafetyEnum()
		{
		}

		///// <summary>
		///// Возможные значения
		///// </summary>
		//private static readonly IList<string> PossibleValues = new List<string>();

		private string _mask;


		protected string Value => _mask;

		/// <summary>
		/// Регистрирует возможное значение.
		/// </summary>
		/// <param name="value">Значение.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Mask must be a power of 2 (i.e. only one bit must be equal to 1);mask</exception>
		protected static TFilter RegisterPossibleValue(string value)
		{
			return new TFilter { _mask = value };
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			return _mask;
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
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns>Объект перечисления типа <typeparam name="TFilter">Непосредственно наследник</typeparam></returns>
		public static TFilter FromJson(VkResponse response)
	    {
		    var value = response.ToString();
            var result = FromJson(value);
	        Activator.CreateInstance(result.GetType());
	        return result;

	    }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns>Объект перечисления типа <typeparam name="TFilter">Непосредственно наследник</typeparam></returns>
        public static TFilter FromJson(string response)
		{
		    if (string.IsNullOrWhiteSpace(response))
		    {
		        return null;
		    }
			var result = new TFilter { _mask = response };
            Activator.CreateInstance(result.GetType());
            return result;
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