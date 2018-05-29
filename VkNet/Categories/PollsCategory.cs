using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с опросами.
	/// </summary>
	public partial class PollsCategory : IPollsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с опросами.
		/// </summary>
		/// <param name="vk"> API. </param>
		public PollsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает детальную информацию об опросе по его идентификатору.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public Poll GetById(PollsGetByIdParams @params)
		{
			return _vk.Call(methodName: "polls.getById", parameters: @params);
		}

		/// <summary>
		/// Позволяет редактировать созданные опросы.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public bool Edit(PollsEditParams @params)
		{
			return _vk.Call(methodName: "polls.edit", parameters: @params);
		}

		/// <summary>
		/// Отдает голос текущего пользователя за выбранный вариант ответа в указанном
		/// опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public bool AddVote(PollsAddVoteParams @params)
		{
			return _vk.Call(methodName: "polls.addVote", parameters: @params);
		}

		/// <summary>
		/// Снимает голос текущего пользователя с выбранного варианта ответа в указанном
		/// опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public bool DeleteVote(PollsDeleteVoteParams @params)
		{
			return _vk.Call(methodName: "polls.deleteVote", parameters: @params);
		}

		/// <summary>
		/// Получает список идентификаторов пользователей, которые выбрали определенные
		/// варианты ответа в опросе.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public VkCollection<PollAnswerVoters> GetVoters(PollsGetVotersParams @params)
		{
			return _vk.Call(methodName: "polls.getVoters", parameters: @params).ToVkCollectionOf<PollAnswerVoters>(selector: x => x);
		}

		/// <summary>
		/// Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на
		/// странице пользователя или
		/// сообщества.
		/// </summary>
		/// <param name="params"> Параметры </param>
		/// <returns> </returns>
		public Poll Create(PollsCreateParams @params)
		{
			return _vk.Call(methodName: "polls.create", parameters: @params);
		}
	}
}