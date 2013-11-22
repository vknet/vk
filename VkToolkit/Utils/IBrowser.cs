using VkToolkit.Enums;

namespace VkToolkit.Utils
{
    public interface IBrowser
    {
        string GetJson(string url);

        VkAuthorization Authorize(int appId, string email, string password, Settings settings);
    }
}