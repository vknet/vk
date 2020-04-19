using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
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
		public List<ITemplateElement> Elements { get; private set; }

		private string TooMuchElementsExceptionTemplate = "Максимальное количество элементов в шаблоне 10";

		/// <inheritdoc />
		public TemplateBuilder AddTemplateElement(ITemplateElement element)
		{
			if(Elements.Count >= 10)
			{
				throw new TooMuchElementsInTemplate(TooMuchElementsExceptionTemplate);
			}

			Elements.Add(element);

			return this;
		}

		/// <inheritdoc />
		public TemplateBuilder SetType(TemplateType type)
		{
			Type = type;

			return this;
		}

		/// <inheritdoc />
		public TemplateBuilder ClearElements()
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