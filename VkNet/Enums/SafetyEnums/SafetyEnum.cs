using System;
using System.Collections.Generic;
using System.Linq;

namespace VkNet.Enums.SafetyEnums
{

    /// <summary>
    /// Аналог enum, типобезопасен.
    /// </summary>
    /// <typeparam name="TFilter">Непосредственно наследник</typeparam>
    [Serializable]
    public class SafetyEnum <TFilter> where TFilter : SafetyEnum<TFilter>, new()
	{
// ReSharper disable once StaticFieldInGenericType
		private static readonly Dictionary<ulong, string> PossibleValues = new Dictionary<ulong, string>();

		private ulong _mask;

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

		protected SafetyEnum()
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

			return CreateFromMask(mask);
		}

		protected static TFilter RegisterPossibleValue(string value)
		{
			var mask = PossibleValues.Select(pair => pair.Key).DefaultIfEmpty().Max();
			mask = (mask == 0) ? 1 : (mask *= 2);

			if (mask == 0 || (mask & (mask - 1)) != 0)
				throw new ArgumentException("Mask must be a power of 2 (i.e. only one bit must be equal to 1)", "mask");


			PossibleValues.Add(mask, value);

			return CreateFromMask(mask);
		}

		public override string ToString()
		{
			return string.Join(",", PossibleValues.Where(pair => (pair.Key & _mask) != 0).Select(pair => pair.Value).ToArray());
		}

		public static bool operator ==(SafetyEnum<TFilter> left, SafetyEnum<TFilter> right)
		{
			if (ReferenceEquals(right, left)) return true;
			if (ReferenceEquals(null, left)) return false;
			if (ReferenceEquals(null, right)) return false;

			return left._mask == right._mask;
		}

		public static bool operator !=(SafetyEnum<TFilter> left, SafetyEnum<TFilter> right)
		{
			return !(left == right);
		}

		protected bool Equals(SafetyEnum<TFilter> other)
		{
			return _mask == other._mask;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((SafetyEnum<TFilter>) obj);
		}

		public override int GetHashCode()
		{
			return _mask.GetHashCode();
		}
	}
}