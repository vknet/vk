using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Настройки уведомлений в формате «название события» : «статус»
    /// ( 0 — уведомления о событии выключены, 1 — уведомления о событии включены). 
    /// </summary>
    [Serializable]
    public class CallbackSettings
    {
        /// <summary>
        /// новое сообщение  
        /// </summary> 
        [JsonProperty("message_new")]
        public bool? MessageNew { get; set; }

        /// <summary>
        /// новое исходящее сообщение  
        /// </summary> 
        [JsonProperty("message_reply")]
        public bool? MessageReply { get; set; }

        /// <summary>
        /// редактирование сообщения
        /// </summary> 
        [JsonProperty("message_edit")]
        public bool? MessageEdit { get; set; }

        /// <summary>
        /// новая подписка на сообщения  
        /// </summary> 
        [JsonProperty("message_allow")]
        public bool? MessageAllow { get; set; }

        /// <summary>
        /// новый запрет сообщений  
        /// </summary> 
        [JsonProperty("message_deny")]
        public bool? MessageDeny { get; set; }

        /// <summary>
        /// добавление новой фотографии  
        /// </summary> 
        [JsonProperty("photo_new")]
        public bool? PhotoNew { get; set; }

        /// <summary>
        /// добавление новой аудиозаписи  
        /// </summary> 
        [JsonProperty("audio_new")]
        public bool? AudioNew { get; set; }

        /// <summary>
        /// добавление новой видеозаписи  
        /// </summary> 
        [JsonProperty("video_new")]
        public bool? VideoNew { get; set; }

        /// <summary>
        /// добавление нового комментария на стене  
        /// </summary> 
        [JsonProperty("wall_reply_new")]
        public bool? WallReplyNew { get; set; }

        /// <summary>
        /// редактирование комментария на стене  
        /// </summary> 
        [JsonProperty("wall_reply_edit")]
        public bool? WallReplyEdit { get; set; }

        /// <summary>
        /// восстановление комментария на стене 
        /// </summary> 
        [JsonProperty("wall_reply_restore")]
        public bool? WallReplyRestore { get; set; }

        /// <summary>
        /// удаление комментария на стене  
        /// </summary> 
        [JsonProperty("wall_reply_delete")]
        public bool? WallReplyDelete { get; set; }

        /// <summary>
        /// добавление новой записи на стене  
        /// </summary> 
        [JsonProperty("wall_post_new")]
        public bool? WallPostNew { get; set; }

        /// <summary>
        /// новый репост записи на стене  
        /// </summary> 
        [JsonProperty("wall_repost")]
        public bool? WallRepost { get; set; }

        /// <summary>
        /// добавление нового комментария в обсуждении  
        /// </summary> 
        [JsonProperty("board_post_new")]
        public bool? BoardPostNew { get; set; }

        /// <summary>
        /// редактирование комментария в обсуждении  
        /// </summary> 
        [JsonProperty("board_post_edit")]
        public bool? BoardPostEdit { get; set; }

        /// <summary>
        /// удаление комментария в обсуждении  
        /// </summary> 
        [JsonProperty("board_post_delete")]
        public bool? BoardPostDelete { get; set; }

        /// <summary>
        /// восстановление комментария в обсуждении  
        /// </summary> 
        [JsonProperty("board_post_restore")]
        public bool? BoardPostRestore { get; set; }

        /// <summary>
        /// добавление нового комментария к фото 
        /// </summary> 
        [JsonProperty("photo_comment_new")]
        public bool? PhotoCommentNew { get; set; }

        /// <summary>
        /// редактирование комментария к фото 
        /// </summary> 
        [JsonProperty("photo_comment_edit")]
        public bool? PhotoCommentEdit { get; set; }

        /// <summary>
        /// удаление комментария к фото 
        /// </summary> 
        [JsonProperty("photo_comment_delete")]
        public bool? PhotoCommentDelete { get; set; }

        /// <summary>
        /// восстановление комментария к фото 
        /// </summary> 
        [JsonProperty("photo_comment_restore")]
        public bool? PhotoCommentRestore { get; set; }

        /// <summary>
        /// добавление нового комментария к видео 
        /// </summary> 
        [JsonProperty("video_comment_new")]
        public bool? VideoCommentNew { get; set; }

        /// <summary>
        /// редактирование комментария к видео 
        /// </summary> 
        [JsonProperty("video_comment_edit")]
        public bool? VideoCommentEdit { get; set; }

        /// <summary>
        /// удаление комментария к видео 
        /// </summary> 
        [JsonProperty("video_comment_delete")]
        public bool? VideoCommentDelete { get; set; }

        /// <summary>
        /// восстановление комментария к видео 
        /// </summary> 
        [JsonProperty("video_comment_restore")]
        public bool? VideoCommentRestore { get; set; }

        /// <summary>
        /// добавление нового комментария к товару 
        /// </summary> 
        [JsonProperty("market_comment_new")]
        public bool? MarketCommentNew { get; set; }

        /// <summary>
        /// редактирование комментария к товару 
        /// </summary> 
        [JsonProperty("market_comment_edit")]
        public bool? MarketCommentEdit { get; set; }

        /// <summary>
        /// удаление комментария к товару 
        /// </summary> 
        [JsonProperty("market_comment_delete")]
        public bool? MarketCommentDelete { get; set; }

        /// <summary>
        /// восстановление удалённого комментария к товару 
        /// </summary> 
        [JsonProperty("market_comment_restore")]
        public bool? MarketCommentRestore { get; set; }

        /// <summary>
        /// новый голос в публичном опросе 
        /// </summary> 
        [JsonProperty("poll_vote_new")]
        public bool? PollVoteNew { get; set; }

        /// <summary>
        /// вступление в сообщество  
        /// </summary> 
        [JsonProperty("group_join")]
        public bool? GroupJoin { get; set; }

        /// <summary>
        /// выход участника из сообщества  
        /// </summary> 
        [JsonProperty("group_leave")]
        public bool? GroupLeave { get; set; }

        /// <summary>
        /// занесение пользователя в черный список  
        /// </summary> 
        [JsonProperty("user_block")]
        public bool? UserBlock { get; set; }

        /// <summary>
        /// удаление пользователя из черного списка  
        /// </summary> 
        [JsonProperty("user_unblock")]
        public bool? UserUnblock { get; set; }

        /// <summary>
        /// изменение настроек сообщества  
        /// </summary> 
        [JsonProperty("group_change_settings")]
        public bool? GroupChangeSettings { get; set; }

        /// <summary>
        /// изменение главной фотографии  
        /// </summary> 
        [JsonProperty("group_change_photo")]
        public bool? GroupChangePhoto { get; set; }

        /// <summary>
        /// изменение руководства сообщества  
        /// </summary> 
        [JsonProperty("group_officers_edit")]
        public bool? GroupOfficersEdit { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static CallbackSettings FromJson(VkResponse response)
        {
            return new CallbackSettings
            {
                MessageNew = response["message_new"],

                MessageReply = response["message_reply"],

                MessageAllow = response["message_allow"],

                MessageDeny = response["message_deny"],

                PhotoNew = response["photo_new"],

                AudioNew = response["audio_new"],

                VideoNew = response["video_new"],

                WallReplyNew = response["wall_reply_new"],

                WallReplyEdit = response["wall_reply_edit"],

                WallReplyDelete = response["wall_reply_delete"],

                WallPostNew = response["wall_post_new"],

                WallRepost = response["wall_repost"],

                BoardPostNew = response["board_post_new"],

                BoardPostEdit = response["board_post_edit"],

                BoardPostDelete = response["board_post_delete"],

                BoardPostRestore = response["board_post_restore"],

                PhotoCommentNew = response["photo_comment_new"],

                PhotoCommentEdit = response["photo_comment_edit"],

                PhotoCommentDelete = response["photo_comment_delete"],

                PhotoCommentRestore =
                    response["photo_comment_restore"],

                VideoCommentNew = response["video_comment_new"],

                VideoCommentEdit = response["video_comment_edit"],

                VideoCommentDelete = response["video_comment_delete"],

                VideoCommentRestore =
                    response["video_comment_restore"],

                MarketCommentNew = response["market_comment_new"],

                MarketCommentEdit = response["market_comment_edit"],

                MarketCommentDelete =
                    response["market_comment_delete"],

                MarketCommentRestore =
                    response["market_comment_restore"],

                PollVoteNew = response["poll_vote_new"],

                GroupJoin = response["group_join"],

                GroupLeave = response["group_leave"],

                UserBlock = response["user_block"],

                UserUnblock = response["user_unblock"],

                GroupChangeSettings =
                    response["group_change_settings"],

                GroupChangePhoto = response["group_change_photo"],

                GroupOfficersEdit = response["group_officers_edit"]
            };
        }
    }
}