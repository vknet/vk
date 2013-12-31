namespace VkToolkit.Utils
{
    using VkToolkit.Enums;

    public interface IBrowser
    {
        string GetJson(string url);

        VkAuthorization Authorize(int appId, string email, string password, Settings settings);
    }
}