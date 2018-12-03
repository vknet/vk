using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using VkNet.Abstractions.Authorization;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.NLog.Extensions.Logging;
using VkNet.NLog.Extensions.Logging.Extensions;
using VkNet.Utils;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

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
			_api = new VkApi(InitDi());

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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var tmp = _api.Groups.Get(new GroupsGetParams());
			MessageBox.Show(tmp.TotalCount.ToString());
		}

		private static ServiceCollection InitDi()
		{
			var di = new ServiceCollection();

			di.AddSingleton<IBrowser, WpfAuthorize>();
			di.AddSingleton<ILoggerFactory, LoggerFactory>();
			di.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
			di.AddLogging(builder =>
			{
				builder.ClearProviders();
				builder.SetMinimumLevel(LogLevel.Trace);
				builder.AddNLog(new NLogProviderOptions
				{
					CaptureMessageProperties = true,
					CaptureMessageTemplates = true
				});
			});
			LogManager.LoadConfiguration("nlog.config");

			return di;
		}
	}
}