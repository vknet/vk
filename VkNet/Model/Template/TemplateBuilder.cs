using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Enums.StringEnums;
using VkNet.Exception;

namespace VkNet.Model;

/// <inheritdoc cref="ITemplateBuilder" />
[Serializable]
[UsedImplicitly]
public class TemplateBuilder : ITemplateBuilder
{
	/// <inheritdoc />
	public TemplateType? Type { get; private set; } = TemplateType.Carousel;

	/// <inheritdoc />
	public List<CarouselElement> Elements { get; private set; } = new();

	private string _tooMuchElementsExceptionTemplate = "Максимальное количество элементов в шаблоне 10";

	/// <inheritdoc />
	public ITemplateBuilder AddTemplateElement(CarouselElement element)
	{
		if (Elements.Count >= 10)
		{
			throw new TooMuchElementsInTemplateException(_tooMuchElementsExceptionTemplate);
		}

		Elements.Add(element);

		return this;
	}

	/// <inheritdoc />
	public ITemplateBuilder SetType(TemplateType type)
	{
		Type = type;

		return this;
	}

	/// <inheritdoc />
	public ITemplateBuilder ClearElements()
	{
		Elements.Clear();

		return this;
	}

	/// <inheritdoc />
	public MessageTemplate Build() => new()
	{
		Type = Type,
		Elements = Elements
	};
}