﻿using System;
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
        DocsCategory Docs { get; }
        ExecuteCategory Execute { get; }
        FaveCategory Fave { get; }
        FriendsCategory Friends { get; }
        GiftsCategory Gifts { get; set; }
        GroupsCategory Groups { get; }
        DateTimeOffset? LastInvokeTime { get; }
        TimeSpan? LastInvokeTimeSpan { get; }
        LikesCategory Likes { get; }
        MarketsCategory Markets { get; set; }
        int MaxCaptchaRecognitionCount { get; set; }
        MessagesCategory Messages { get; }
        NewsFeedCategory NewsFeed { get; set; }
        PagesCategory Pages { get; set; }
        PhotoCategory Photo { get; }
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

        event VkApiDelegate OnTokenExpires;

        VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false);
        string GetApiUrlAndAddToken(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
        void RefreshToken(Func<string> code = null);
        Task RefreshTokenAsync(Func<string> code = null);
    }
}