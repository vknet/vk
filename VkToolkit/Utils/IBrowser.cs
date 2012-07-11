using System;
using WatiN.Core;

namespace VkToolkit.Utils
{
    public interface IBrowser
    {
        // properties
        Uri Uri { get; }

        string GetRawHtml(string path);
        void ClearCookies();
        void GoTo(string url);
        void Close();
        void Authorize(string email, string password);

        // special functions
        TextField TextField(WatiN.Core.Constraints.Constraint findBy);
        Button Button(WatiN.Core.Constraints.Constraint findBy);
        bool ContainsText(string text);
    }
}