using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VkNet.Wpf
{
	/// <summary>
	/// Логика взаимодействия для TwoFactorAuthorization.xaml
	/// </summary>
	public partial class TwoFactorAuthorization : Window
	{
		public TwoFactorAuthorization()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (Owner is AuthForm auth)
			{
				auth.TFCode = Code.Text;
			}

			Close();
		}
	}
}