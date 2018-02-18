using System.Windows;
using VkNet.Enums.Filters;
using VkNet.Shared;

namespace VkNet.Wpf
{
	/// <summary>
	/// Логика взаимодействия для AuthForm.xaml
	/// </summary>
	public partial class AuthForm : Window
	{
		private VkApi _api;

		public string TFCode { get; set; }
		
		public AuthForm()
		{
			InitializeComponent();
			_api = Api.GetInstance();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_api.Authorize(new ApiAuthParams
			{
				ApplicationId = 4268118,
				Settings = Settings.All,
				Login = loginTb.Text,
				Password = passwordTb.Text,
				TwoFactorAuthorization = () =>
				{
					var tfa = new TwoFactorAuthorization {Owner = this};
					var dlg = tfa.ShowDialog();
					if (dlg.HasValue && dlg.Value)
					{
						
					}
					return TFCode;
				}
			});
			Close();
		}
	}
}
