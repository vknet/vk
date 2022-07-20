using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class LeadFormsQuestionBuilder : ILeadFormsQuestionBuilder
	{
		private readonly List<LeadFormsQuestionInfo> _list = new List<LeadFormsQuestionInfo>();

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddStandard(StandardQuestion question)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = question.ToString()
			});

			return this;
		}

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddInput(string label)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = NonStandardQuestion.Input.ToString(),
				Label = label
			});

			return this;
		}

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddSelect(string key, string label, QuestionOption[] options)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = NonStandardQuestion.Select.ToString(),
				Key = key,
				Label = label,
				Options = options
			});

			return this;
		}

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddRadio(string label, QuestionOption[] options)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = NonStandardQuestion.Radio.ToString(),
				Label = label,
				Options = options
			});

			return this;
		}

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddCheckbox(string key, string label, QuestionOption[] options)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = NonStandardQuestion.Checkbox.ToString(),
				Key = key,
				Label = label,
				Options = options
			});

			return this;
		}

		/// <inheritdoc />
		public ILeadFormsQuestionBuilder AddTextArea(string label)
		{
			_list.Add(new LeadFormsQuestionInfo
			{
				Type = NonStandardQuestion.Textarea.ToString(),
				Label = label
			});

			return this;
		}

		/// <inheritdoc />
		public string Build(Formatting formatting = Formatting.Indented)
		{
			return JsonConvert.SerializeObject(_list, formatting);
		}
	}
}