using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Categories;
using VkNet.Utils;

namespace VkNet
{
    public interface IVkApi:IAuth, IAuthAsync, IDisposable
    {
        /// <summary>
		/// API для работы с аккаунтом пользователя.
		/// </summary>
        IAccountCategory Account { get; }

        /// <summary>
        /// API для работы с приложениями.
        /// </summary>
        IAppsCategory Apps { get; set; }

        /// <summary>
        /// API для работы с аудио записями.
        /// </summary>
        IAudioCategory Audio { get; }

        /// <summary>
        /// API для работы с Авторизацией.
        /// </summary>
        IAuthCategory Auth { get; set; }

        /// <summary>
        /// API для работы со темами групп.
        /// </summary>
        IBoardCategory Board { get; }

        /// <summary>
        /// Браузер.
        /// </summary>
        IBrowser Browser { get; set; }

        /// <summary>
        /// API для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
        /// </summary>
        IDatabaseCategory Database { get; }

        /// <summary>
        /// API для работы с документами
        /// </summary>
        IDocsCategory Docs { get; }

        /// <summary>
        /// API для работы с универсальным методом.
        /// </summary>
        IExecuteCategory Execute { get; }

        /// <summary>
        /// API для работы с закладками.
        /// </summary>
        IFaveCategory Fave { get; }

        /// <summary>
        /// API для работы с друзьями.
        /// </summary>
        IFriendsCategory Friends { get; }

        /// <summary>
        /// API для работы с подарками.
        /// </summary>
        IGiftsCategory Gifts { get; set; }

        /// <summary>
        /// API для работы с .
        /// </summary>
        IGroupsCategory Groups { get; }
       
        /// <summary>
        /// API для работы с лайками
        /// </summary>
        ILikesCategory Likes { get; }

        /// <summary>
        /// API для работы с товарами.
        /// </summary>
        IMarketsCategory Markets { get; set; }

        /// <summary>
        /// API для работы с сообщениями.
        /// </summary>
        IMessagesCategory Messages { get; }

        /// <summary>
        /// API для работы с новостной лентой.
        /// </summary>
        INewsFeedCategory NewsFeed { get; set; }

        /// <summary>
        /// API для работы с wiki.
        /// </summary>
        IPagesCategory Pages { get; set; }

        /// <summary>
        /// API для работы с фотографиями
        /// </summary>
        IPhotoCategory Photo { get; }
        PollsCategory PollsCategory { get; }
        float RequestsPerSecond { get; set; }
        StatsCategory Stats { get; set; }
        StatusCategory Status { get; }
        string Token { get; }
        long? UserId { get; set; }
        UsersCategory Users { get; }
        UtilsCategory Utils { get; }
        VideoCategory Video { get; }
        WallCategory Wall { get; }
        DateTimeOffset? LastInvokeTime { get; }
        TimeSpan? LastInvokeTimeSpan { get; }
        int MaxCaptchaRecognitionCount { get; set; }

        event VkApiDelegate OnTokenExpires;

        VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false);
        string GetApiUrlAndAddToken(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        void RefreshToken(Func<string> code = null);
        Task RefreshTokenAsync(Func<string> code = null);
    }
}