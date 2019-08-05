using System.Reflection;
using System.Windows.Controls;

namespace VkNet.Wpf
{
	public static class WebBrowserExtensions
	{
		public static void SetSilent(this WebBrowser wb)
		{
			var fiComWebBrowser = typeof(WebBrowser)
				.GetField("_axIWebBrowser2",
					BindingFlags.Instance|BindingFlags.NonPublic);

			if (fiComWebBrowser == null)
			{
				return;
			}

			var objComWebBrowser = fiComWebBrowser.GetValue(wb);

			objComWebBrowser?.GetType()
				.InvokeMember("Silent",
					BindingFlags.SetProperty,
					null,
					objComWebBrowser,
					new object[]
					{
						true
					});
		}
	}
}