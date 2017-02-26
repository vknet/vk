using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы этого класса позволяют производить действия с опросами.
    /// </summary>
    public class PollsCategory
    {
        /// <summary>
        /// API.
        /// </summary>
        readonly VkApi _vk;

        /// <summary>
        /// Методы для работы с опросами. 
        /// </summary>
        /// <param name="vk">API.</param>
        public PollsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает детальную информацию об опросе по его идентификатору.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        public Poll GetById(PollsGetByIdParams @params)
        {
            return _vk.Call("polls.getById", @params);
        }

        /// <summary>
        /// Позволяет редактировать созданные опросы.
        /// </summary>
        /// <param name="params">Параметры</param>
        /// <returns></returns>
        public bool Edit(PollsEditParams @params)
        {
            return _vk.Call("polls.edit", @params);
        }
    }
}
