using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VkToolkit.Utils;

namespace VkApiRunner
{
    public partial class UnitTestForm : Form
    {
        public string MethodName { get; set; }
        public string ApiUrl { get; set; }
        public string ResultJson { get; set; }

        private const string UnitTestTemplatePath = "unit_test_template.txt";

        public UnitTestForm()
        {
            InitializeComponent();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbUnitTest.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal string GetCapitalMethodName(string methodName)
        {
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException("methodName");

            // TODO add contracts check
            string[] parts = methodName.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);

            string method = parts.Length > 1 ? parts[1] : parts[0];

            return Char.ToUpper(method[0]) + method.Substring(1, method.Length - 1);
        }

        internal string TruncateAccessToken(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");

            int pos = url.IndexOf("access_token=", StringComparison.InvariantCulture);
            Debug.Assert(pos > -1);

            string result = url.Substring(0, pos) + "access_token=token";
            return result;
        }

        private void UnitTestForm_Load(object sender, EventArgs e)
        {
            // TODO add contracts
            if (!File.Exists(UnitTestTemplatePath))
            {
                MessageBox.Show("Не найден файл с шаблоном для юнит теста.", "Ошибка приложения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            string apiUrl = TruncateAccessToken(ApiUrl);

            var template = new StringBuilder(File.ReadAllText(UnitTestTemplatePath));

            template.Replace(Placeholder.MethodName, GetCapitalMethodName(MethodName));
            template.Replace(Placeholder.Json, Utilities.PreetyPrintJson(ResultJson));
            template.Replace(Placeholder.Url, Utilities.PreetyPrintApiUrl(apiUrl));

            tbUnitTest.Text = template.ToString();
        }
    }
}
