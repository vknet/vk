using System;
using JetBrains.Annotations;

namespace VkNet.Infrastructure;

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
	public void AddData(Type type, [CanBeNull] object data);

	/// <summary>
	/// Попытка получения данных
	/// </summary>
	/// <param name="type">Тип</param>
	/// <param name="data">Данные</param>
	/// <returns>
	/// Успешность получения данных
	/// </returns>
	public bool TryGetData(Type type, [CanBeNull] out object data);
}