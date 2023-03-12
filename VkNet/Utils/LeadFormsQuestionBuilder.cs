using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Abstractions.Utils;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Utils;

/// <inheritdoc />
[UsedImplicitly]
public class LeadFormsQuestionBuilder : ILeadFormsQuestionBuilder
{
	private readonly List<LeadFormsQuestionInfo> _list = new();

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddStandard(StandardQuestion question)
	{
		_list.Add(new()
		{
			Type = question.ToString().ToSnakeCase()
		});

		return this;
	}

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddInput(string label)
	{
		_list.Add(new()
		{
			Type = NonStandardQuestion.Input.ToString().ToSnakeCase(),
			Label = label
		});

		return this;
	}

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddSelect(string key, string label, QuestionOption[] options)
	{
		_list.Add(new()
		{
			Type = NonStandardQuestion.Select.ToString().ToSnakeCase(),
			Key = key,
			Label = label,
			Options = options
		});

		return this;
	}

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddRadio(string label, QuestionOption[] options)
	{
		_list.Add(new()
		{
			Type = NonStandardQuestion.Radio.ToString().ToSnakeCase(),
			Label = label,
			Options = options
		});

		return this;
	}

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddCheckbox(string key, string label, QuestionOption[] options)
	{
		_list.Add(new()
		{
			Type = NonStandardQuestion.Checkbox.ToString().ToSnakeCase(),
			Key = key,
			Label = label,
			Options = options
		});

		return this;
	}

	/// <inheritdoc />
	public ILeadFormsQuestionBuilder AddTextArea(string label)
	{
		_list.Add(new()
		{
			Type = NonStandardQuestion.Textarea.ToString().ToSnakeCase(),
			Label = label
		});

		return this;
	}

	/// <inheritdoc />
	public string Build(Formatting formatting = Formatting.Indented) => JsonConvert.SerializeObject(_list, formatting);
}