#if NET40

// TODO: Если namespace System.Reflection то везде где используется GetTypeInfo() он будет добавлен и Net4.5 будет прозрачно. Хорошее решение - хз ??
namespace System.Reflection
{
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