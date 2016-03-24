using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Статус заявки на изменение имени
    /// </summary>
    public sealed class ChangeNameStatus : SafetyEnum<ChangeNameStatus>
    {
        /// <summary>
        /// Заявка рассматривается
        /// </summary>
        public static readonly ChangeNameStatus Processing = RegisterPossibleValue("processing");

        /// <summary>
        /// Заявка отклонена
        /// </summary>
        public static readonly ChangeNameStatus Declined = RegisterPossibleValue("declined");

        /// <summary>
        /// Имя было успешно изменено
        /// </summary>
        public static readonly ChangeNameStatus Success = RegisterPossibleValue("success");

        /// <summary>
        /// Недавно уже была одобрена заявка, повторную заявку можно подать не раньше даты, указанной в поле <see cref="ChangeNameRequest.RepeatDate"/>
        /// </summary>
        public static readonly ChangeNameStatus WasAccepted = RegisterPossibleValue("was_accepted");

        /// <summary>
        /// Предыдущая заявка была отклонена, повторную заявку можно подать не раньше даты, указанной в поле <see cref="ChangeNameRequest.RepeatDate"/>
        /// </summary>
        public static readonly ChangeNameStatus WasDeclined = RegisterPossibleValue("was_declined");


        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        internal static ChangeNameStatus FromJson(VkResponse response)
        {
            switch (response.ToString())
            {
                case "processing":
                    {
                        return Processing;
                    }
                case "declined":
                    {
                        return Declined;
                    }
                case "success":
                    {
                        return Success;
                    }
                case "was_accepted":
                    {
                        return WasAccepted;
                    }
                default:
                    {
                        return WasDeclined;
                    }
            }
        }
    }
}