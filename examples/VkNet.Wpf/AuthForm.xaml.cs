using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using VkNet.Model;

namespace VkNet.Wpf
{
	/// <summary>
	/// Логика взаимодействия для AuthForm.xaml
	/// </summary>
	public partial class AuthForm : Window
	{
		public AuthorizationResult Auth { get; set; }

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