using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
	public static StreamingContext AddTypeData(this StreamingContext context, Type type, object? data)
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
	public static bool TryGetTypeData(this StreamingContext context, Type type, out object? data)
	{
		IStreamingContextTypeDataDictionary? dictionary = context.Context as IStreamingContextTypeDataDictionary;

		if (dictionary is not null)
		{
			return dictionary.TryGetData(type, out data);
		}

		data = null;
		return false;
	}
}

/// <summary>
/// Интерфейс словаря контекста
/// </summary>
public interface IStreamingContextTypeDataDictionary
{

	/// <summary>
	/// Добавить данные
	/// </summary>
	/// <param name="type">Тип</param>
	/// <param name="data">Данные</param>
	public void AddData(Type type, object? data);

	/// <summary>
	/// Попытка получения данных
	/// </summary>
	/// <param name="type">Тип</param>
	/// <param name="data">Данные</param>
	/// <returns>
	/// Успешность получения данных
	/// </returns>
	public bool TryGetData(Type type, out object? data);
}

/// <inheritdoc cref="IStreamingContextTypeDataDictionary" />
class StreamingContextTypeDataDictionary : IStreamingContextTypeDataDictionary
{
	readonly Dictionary<Type, object> dictionary = new ();

	/// <inheritdoc />
	public void AddData(Type type, object? data) => dictionary.Add(type, data);

	/// <inheritdoc />
	public bool TryGetData(Type type, out object? data) => dictionary.TryGetValue(type, out data);
}