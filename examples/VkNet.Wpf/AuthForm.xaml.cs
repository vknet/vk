using System.Windows;
using VkNet.Utils;

namespace VkNet.Wpf
{
	/// <summary>
	/// Логика взаимодействия для AuthForm.xaml
	/// </summary>
	public partial class AuthForm : Window
	{
		public VkAuthorization Auth { get; set; }

		public string Tfa { get; set; }

		public AuthForm()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}