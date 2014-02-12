namespace VkNet.Utils
{
    using VkNet.Enums;

    public interface IBrowser
    {
        string GetJson(string url);

        VkAuthorization Authorize(int appId, string email, string password, Settings settings);
    }
}