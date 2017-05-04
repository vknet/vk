﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Categories;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet
{
    public interface IVkApi:IAuth, IAuthAsync, IDisposable
    {
        AccountCategory Account { get; }
        AppsCategory Apps { get; set; }
        AudioCategory Audio { get; }
        AuthCategory Auth { get; set; }
        BoardCategory Board { get; }
        IBrowser Browser { get; set; }
        DatabaseCategory Database { get; }
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