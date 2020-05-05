using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Template.Carousel;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Template
{
	/// <inheritdoc />
	[Serializable]
	[UsedImplicitly]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class TemplateBuilder : ITemplateBuilder
	{
		/// <inheritdoc />
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public TemplateType Type { get; private set; } = TemplateType.Carousel;

		/// <inheritdoc />
		public List<CarouselElement> Elements { get; private set; } = new List<CarouselElement>();

		private string _tooMuchElementsExceptionTemplate = "Максимальное количество элементов в шаблоне 10";

		/// <inheritdoc />
		public ITemplateBuilder AddTemplateElement(CarouselElement element)
		{
			if(Elements.Count >= 10)
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
		public MessageTemplate Build()
		{
			return new MessageTemplate()
			{
				Type = Type,
				Elements = Elements
			};
		}
	}
}