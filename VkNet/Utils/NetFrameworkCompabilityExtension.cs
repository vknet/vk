using JetBrains.Annotations;

#if NET40
// ReSharper disable once CheckNamespace
namespace System.Reflection
{
	/// <summary>
	/// Методы расширения для <see cref="Type"/>
	/// </summary>
	[UsedImplicitly]
	public static class TypesCompabilityExtension
	{
		/// <summary>
		/// Получить информацию о типе
		/// </summary>
		/// <param name="type"> Тип </param>
		/// <returns> Тип </returns>
		public static Type GetTypeInfo(this Type type)
		{
			return type;
		}
	}
}
#endif