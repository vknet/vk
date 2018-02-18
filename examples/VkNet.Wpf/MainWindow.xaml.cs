using System.Windows;
using VkNet.Model.RequestParams;
using VkNet.Shared;

namespace VkNet.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
	    private readonly VkApi _api;
	    public MainWindow()
        {
	        InitializeComponent();
	        _api = Api.GetInstance();
	        if (_api.IsAuthorized)
	        {
		        return;
	        }

	        var auth = new AuthForm();
	        var dlg = auth.ShowDialog();
	        if (dlg.HasValue && dlg.Value)
	        {
	        }
        }

		private void Window_Initialized(object sender, System.EventArgs e)
		{
			
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var tmp = _api.Groups.Get(new GroupsGetParams());
			MessageBox.Show(tmp.TotalCount.ToString());
		}
	}
}