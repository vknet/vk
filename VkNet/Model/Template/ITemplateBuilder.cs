using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Template
{
	/// <summary>
	/// Конструктор шаблона
	/// </summary>
	public interface ITemplateBuilder
	{
		/// <summary>
		/// Тип шаблона, по умолчанию карусель
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		TemplateType Type { get; }

		/// <summary>
		/// Список элементов шаблона
		/// </summary>
		List<ITemplateElement> Elements { get; }

		/// <summary>
		/// Добавить элемент шаблона
		/// </summary>
		/// <param name="element">Элемент шаблона</param>
		/// <exception cref="TooMuchElementsInTemplate">Максимальное количество элементов не больше 10</exception>
		/// <returns>Конструктор шаблона</returns>
		TemplateBuilder AddTemplateElement(ITemplateElement element);

		/// <summary>
		/// Установить тип шаблона
		/// </summary>
		/// <param name="type">Тип шаблона</param>
		/// <returns>Конструктор шаблона</returns>
		TemplateBuilder SetType(TemplateType type);

		/// <summary>
		/// Очистить все добавленные шаблоны
		/// </summary>
		/// <returns>Конструктор шаблона</returns>
		TemplateBuilder ClearElements();

		/// <summary>
		/// Построить шаблон
		/// </summary>
		/// <returns>Шаблон</returns>
		MessageTemplate Build();
	}
}
