using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Utils;

namespace VkApiRunner
{
    public partial class MainForm : Form
    {
        private string _apiUrl;

        public MainForm()
        {
            InitializeComponent();

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMethodName.Text))
            {
                MessageBox.Show("Не указано имя метода!");
                return;
            }

            // get authorization values from app.config
            int appId;
            try
            {
                string appIdValue = ConfigurationManager.AppSettings["appId"];
                appId = Convert.ToInt32(appIdValue);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка в разборе appId из app.config", "Ошибка приложения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string login = ConfigurationManager.AppSettings["login"];
            string password = ConfigurationManager.AppSettings["password"];

            btnRun.Enabled = btnGetTest.Enabled = false;

            // Authorize on vk server
            var api = new VkApi();
            try
            {
                api.Authorize(appId, login, password, Settings.All);
            }
            catch (VkApiException)
            {
                MessageBox.Show("Ошибка авторизации. Проверьте данные в app.config.", "Ошибка приложения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRun.Enabled = btnGetTest.Enabled = true;
                return;
            }

            // Combine parameters
            var parameters = new VkParameters();
            for (int i = 1; i < 11; i++)
            {
                var name = (TextBox) pnlParams.Controls.Find(string.Format("tbParamName{0}", i), false)[0];
                var value = (TextBox)pnlParams.Controls.Find(string.Format("tbParamValue{0}", i), false)[0];

                string paramName = name.Text.Trim();
                string paramValue = value.Text.Trim();

                if (string.IsNullOrEmpty(paramName)) continue;

                parameters.Add(paramName, paramValue);
            }

            string methodName = tbMethodName.Text.Trim();

            VkResponse response;
            try
            {
                response = api.Call(methodName, parameters);
            }
            catch (VkApiException ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message, "Ошибка приложения",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRun.Enabled = btnGetTest.Enabled = true;
                return;
            }

            tbJson.Text = response.RawJson;

            _apiUrl = api.GetApiUrl(methodName, parameters);
            llVkApiUrl.Text = _apiUrl.Length > 80 ? _apiUrl.Substring(0, 80) + "..." : _apiUrl;

            btnRun.Enabled = btnGetTest.Enabled = true;
        }

        private void llVkApiUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_apiUrl))
                Process.Start(_apiUrl);
        }

        private void btnGetTest_Click(object sender, EventArgs e)
        {
            var unitTestForm = new UnitTestForm();
            unitTestForm.MethodName = tbMethodName.Text.Trim();
            unitTestForm.ApiUrl = _apiUrl;
            unitTestForm.ResultJson = tbJson.Text;

            unitTestForm.ShowDialog();
        }
    }
}
