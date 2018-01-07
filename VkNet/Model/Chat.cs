using JetBrains.Annotations;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
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
    public ReadOnlyCollection<long> Users { get; set; }

    /// <summary>
    /// Настройки оповещений для диалога..
    /// </summary>
    [CanBeNull]
    public ChatPushSettings PushSettings { get; set; }

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
    /// флаг, указывающий, что пользователь покинул беседу. Всегда содержит 1.
    /// </summary>
    public bool Left { get; set; }

    /// <summary>
    /// флаг, указывающий, что пользователь был исключен из беседы. Всегда содержит 1.
    /// </summary>
    public bool Kicked { get; set; }

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
        Users = response["users"].ToReadOnlyCollectionOf<long>(x => x),
        Left = response.ContainsKey("left") && response["left"],
        Kicked = response["kicked"],
        Photo50 = response["photo_50"],
        Photo100 = response["photo_100"],
        Photo200 = response["photo_200"],
        PushSettings = response["push_settings"]
      };

      return chat;
    }

    #endregion
  }
}