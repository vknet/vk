using System;
using JetBrains.Annotations;

namespace VkNet.Model
{
  using System.Collections.ObjectModel;

  using Utils;

  /// <summary>
  /// Информация о беседе (мультидиалоге, чате).
  /// См. описание http://vk.com/dev/chat_object
  /// </summary>
  public class Chat
  {
    /// <summary>
    /// Идентификатор беседы.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Тип диалога.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Название беседы.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Идентификатор пользователя, который является создателем беседы.
    /// </summary>
    public long? AdminId { get; set; }

    /// <summary>
    /// Список идентификаторов участников беседы.
    /// </summary>
    public Collection<long> Users { get; set; }

    /// <summary>
    /// флаг, указывающий, что пользователь покинул беседу. Всегда содержит 1.
    /// </summary>
    public bool Left { get; set; }

    /// <summary>
    /// флаг, указывающий, что пользователь был исключен из беседы. Всегда содержит 1.
    /// </summary>
    public bool Kicked { get; set; }

    /// <summary>
    /// URL изображения-обложки чата шириной 50 px (если доступно).
    /// </summary>
    public string Photo50 { get; set; }

    /// <summary>
    /// URL изображения-обложки чата шириной 100 px (если доступно).
    /// </summary>
    public string Photo100 { get; set; }

    /// <summary>
    /// URL изображения-обложки чата шириной 200 px (если доступно).
    /// </summary>
    public string Photo200 { get; set; }

    /// <summary>
    /// Настройки оповещений для диалога..
    /// </summary>
    [CanBeNull]
    public ChatPushSettings PushSettings { get; set; }

    #region Поля найденые експерементально

    /// <summary>
    /// Неизвестно что за поле, но оно есть в некоторых диалогах (Вроде не влияет на звоковое уведомление о новых сообщениях)
    /// </summary>
    [Obsolete("Используйте поле PushSettings")]
    public bool? Sound { get; set; }
    /// <summary>
    /// Неизвестно что за поле, но оно есть в некоторых диалогах (При отключенных звуковых уведомлениях равняеться -1)
    /// </summary>
    [Obsolete("Используйте поле PushSettings")]
    public int? DisabledUntil { get; set; }

    #endregion

    #region Методы
    /// <summary>
    /// Разобрать из json.
    /// </summary>
    /// <param name="response">Ответ сервера.</param>
    /// <returns></returns>
    public static Chat FromJson(VkResponse response)
    {
      var chat = new Chat
      {
        Id = response["id"],
        Type = response["type"],
        Title = response["title"],
        AdminId = Utilities.GetNullableLongId(response["admin_id"]),
        Users = response["users"],
        Left = response.ContainsKey("left") && response["left"],
        Kicked = response["kicked"],
        Photo50 = response["photo_50"],
        Photo100 = response["photo_100"],
        Photo200 = response["photo_200"],
        PushSettings = response["push_settings"]
      };

      #region Поля найденые експерементально
      if (response.ContainsKey("push_settings"))
      {
        chat.Sound = response["push_settings"]["sound"];
        chat.DisabledUntil = response["push_settings"]["disabled_until"];
      }
      else
      {
        chat.Sound = null;
        chat.DisabledUntil = null;
      }
      #endregion

      return chat;
    }

    #endregion
  }
}