using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Shared;
using VkNet.Utils;

namespace VkNet.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private VkApi _api;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Initialized(object sender, System.EventArgs e)
		{
			_api = Api.GetInstance(InitDi());

			if (_api.IsAuthorized)
			{
				return;
			}

			_api.Authorize(new ApiAuthParams
			{
				ApplicationId = 4268118,
				Settings = Settings.All
			});
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var tmp = _api.Groups.Get(new GroupsGetParams());
			MessageBox.Show(tmp.TotalCount.ToString());
		}

		private static ServiceCollection InitDi()
		{
			var di = new ServiceCollection();

			di.AddSingleton<IBrowser, WpfAuthorize>();

			return di;
		}
	}
}