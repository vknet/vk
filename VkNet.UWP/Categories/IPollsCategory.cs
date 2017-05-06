namespace VkNet.Categories
{
    using Model;
    using Model.Attachments;
    using Model.RequestParams;
    using Utils;

    /// <summary>
    /// Методы этого класса позволяют производить действия с опросами.
    /// </summary>
    public interface IPollsCategory
    {
        /// <summary>
        /// Возвращает детальную информацию об опросе по его идентификатору.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        Poll GetById(PollsGetByIdParams @params);

        /// <summary>
        /// Позволяет редактировать созданные опросы.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        bool Edit(PollsEditParams @params);

        /// <summary>
        /// Отдает голос текущего пользователя за выбранный вариант ответа в указанном опросе.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        bool AddVote(PollsAddVoteParams @params);

        /// <summary>
        /// Снимает голос текущего пользователя с выбранного варианта ответа в указанном опросе.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        bool DeleteVote(PollsDeleteVoteParams @params);

        /// <summary>
        /// Получает список идентификаторов пользователей, которые выбрали определенные варианты ответа в опросе.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        VkCollection<PollAnswerVoters> GetVoters(PollsGetVotersParams @params);

        /// <summary>
        /// Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на странице пользователя или сообщества.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        Poll Create(PollsCreateParams @params);
    }
}