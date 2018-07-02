using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с опросами.
	/// </summary>
	public interface IPollsCategory : IPollsCategoryAsync
	{
		/// <summary>
		/// Возвращает детальную информацию об опросе по его идентификатору.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.GetById
		/// </remarks>
		Poll GetById(PollsGetByIdParams @params);

		/// <summary>
		/// Позволяет редактировать созданные опросы.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.Edit
		/// </remarks>
		bool Edit(PollsEditParams @params);

		/// <summary>
		/// Отдает голос текущего пользователя за выбранный вариант ответа в указанном
		/// опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns>
		/// 1 — если голос текущего пользователя был отдан за выбранный вариант ответа;
		/// 0 — если текущий пользователь уже голосовал в указанном опросе
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.addVote
		/// </remarks>
		bool AddVote(PollsAddVoteParams @params);

		/// <summary>
		/// Снимает голос текущего пользователя с выбранного варианта ответа в указанном
		/// опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns>
		/// 1 — если голос текущего пользователя был снят с выбранного варианта ответа
		/// 0 — если текущий пользователь еще не голосовал в указанном опросе или указан не
		/// выбранный им вариант ответа
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.DeleteVote
		/// </remarks>
		bool DeleteVote(PollsDeleteVoteParams @params);

		/// <summary>
		/// Получает список идентификаторов пользователей, которые выбрали определенные
		/// варианты ответа в опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.GetVoters
		/// </remarks>
		VkCollection<PollAnswerVoters> GetVoters(PollsGetVotersParams @params);

		/// <summary>
		/// Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на
		/// странице пользователя или
		/// сообщества.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns>
		/// В случае успешного создания опроса в качестве результата возвращается объект
		/// опроса.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/polls.create
		/// </remarks>
		Poll Create(PollsCreateParams @params);
	}
}