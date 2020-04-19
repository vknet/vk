using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;

namespace VkNet.Model.Template
{
	/// <inheritdoc />
	[Serializable]
	[UsedImplicitly]
	public class TemplateBuilder : ITemplateBuilder
	{
		/// <inheritdoc />
		public TemplateType Type { get; private set; }

		/// <inheritdoc />
		public List<ITemplateElement> Elements { get; private set; }

		private string TooMuchElementsExceptionTemplate = "Максимальное количество элементов в шаблоне 10";

		/// <inheritdoc />
		public ITemplateBuilder AddTemplateElement(ITemplateElement element)
		{
			if(Elements.Count >= 10)
			{
				throw new TooMuchElementsInTemplate(TooMuchElementsExceptionTemplate);
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