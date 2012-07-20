using System;
using WatiN.Core;

namespace VkToolkit.Utils
{
    public interface IBrowser
    {
        // properties
        Uri Uri { get; }
        bool Visible { get; set; }

        string GetJson(string url);
        void ClearCookies();
        void GoTo(string url);
        void Close();
        void Authorize(string email, string password);
        void GainAccess();

        // special functions
        TextField TextField(WatiN.Core.Constraints.Constraint findBy);
        Button Button(WatiN.Core.Constraints.Constraint findBy);
        bool ContainsText(string text);
    }
}