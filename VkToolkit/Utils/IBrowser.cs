using System;

namespace VkToolkit.Utils
{
    public interface IBrowser
    {
        // properties
        Uri Url { get; }

        string GetJson(string url);
        void GoTo(string url);
        void Authorize(string email, string password);
        void GainAccess();

        // special functions
        bool ContainsText(string text);
    }
}