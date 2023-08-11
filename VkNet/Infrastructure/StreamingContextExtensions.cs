using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VkNet.Infrastructure;

/// <summary>
/// Класс для кэширования данных в StreamingContext
/// </summary>
public static class StreamingContextExtensions
{

	/// <summary>
	/// Добавить данные в контекст
	/// </summary>
	/// <param name="context">Контекст данных</param>
	/// <param name="type">Тип</param>
	/// <param name="data">Данные</param>
	/// <returns>
	/// Контекст
	/// </returns>
	public static StreamingContext AddTypeData(this StreamingContext context, Type type, [CanBeNull] object data)
	{
		var dictionary = context.Context switch
		{
			null => new StreamingContextTypeDataDictionary(),
			IStreamingContextTypeDataDictionary d => d,
			_ => throw new InvalidOperationException($"context.Context is already populated with {context.Context}")
		};

		dictionary.AddData(type, data);
		return new(context.State, dictionary);
	}

	/// <summary>
	/// Попытка получения данных из контекста
	/// </summary>
	/// <param name="context">Контекст</param>
	/// <param name="type">Тип</param>
	/// <param name="data">Данные</param>
	/// <returns>
	/// Успешность получения данных
	/// </returns>
	public static bool TryGetTypeData(this StreamingContext context, Type type, [CanBeNull] out object data)
	{
		if (context.Context is IStreamingContextTypeDataDictionary dictionary)
		{
			return dictionary.TryGetData(type, out data);
		}

		data = null;
		return false;
	}
}