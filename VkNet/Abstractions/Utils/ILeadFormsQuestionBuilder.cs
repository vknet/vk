using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;

namespace VkNet.Abstractions.Utils
{
	/// <summary>
	/// Построитель вопросов для запросов LeadForms
	/// </summary>
	public interface ILeadFormsQuestionBuilder
	{
		/// <summary>
		/// Добавить стандартный вопрос
		/// </summary>
		/// <param name="question">стандартный вопрос</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddStandard(StandardQuestion question);

		/// <summary>
		/// Добавить текстовое поле.
		/// </summary>
		/// <param name="label">Описание поля.</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddInput(string label);

		/// <summary>
		/// Добавить выпадающий список.
		/// </summary>
		/// <param name="key">Уникальный ключ ответа.</param>
		/// <param name="label">Описание поля.</param>
		/// <param name="options">Массив возможных ответов на вопрос</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddSelect(string key, string label, QuestionOption[] options);

		/// <summary>
		/// Добавить выбор одного из нескольких вариантов
		/// </summary>
		/// <param name="label">Текст ответа.</param>
		/// <param name="options">Массив возможных ответов на вопрос</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddRadio(string label, QuestionOption[] options);

		/// <summary>
		/// Добавить выбор нескольких вариантов
		/// </summary>
		/// <param name="key">Уникальный ключ ответа.</param>
		/// <param name="label">Текст ответа.</param>
		/// <param name="options">Массив возможных ответов на вопрос</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddCheckbox(string key, string label, QuestionOption[] options);

		/// <summary>
		/// Добавить многострочное текстовое поле
		/// </summary>
		/// <param name="label">Описание поля.</param>
		/// <returns>
		/// Построитель вопросов для запросов LeadForms.
		/// </returns>
		ILeadFormsQuestionBuilder AddTextArea(string label);

		/// <summary>
		/// Построить список вопросов.
		/// </summary>
		/// <returns>
		/// Сериализованный в массив список вопросов.
		/// </returns>
		string Build(Formatting formatting = Formatting.Indented);
	}
}