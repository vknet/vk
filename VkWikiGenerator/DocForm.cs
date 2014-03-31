namespace VkWikiGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using VkWikiGenerator.DocGen;

    internal partial class DocForm : Form
    {
        private readonly IList<VkDocType> _types;

        public DocForm(IEnumerable<VkDocType> types)
        {
            _types = new List<VkDocType>(types);
            InitializeComponent();

            lbTypes.SelectedIndexChanged += TypeChanged;
            lbMethods.SelectedIndexChanged += MethodChanged;

            lbTypes.DataSource = _types;
            lbTypes.SelectedIndex = 0;

            if (_types.Count > 0)
            {
                lbMethods.DataSource = _types[0].Methods;
                if (lbMethods.Items.Count > 0)
                    lbMethods.SelectedIndex = 0;
            }
        }

        public void MethodChanged(object sender, EventArgs args)
        {
            var method = lbMethods.SelectedItem as VkDocMethod;
            if (method != null)
            {
                string doc = DocGenFramework.GenerateVkMethod(method);
                txtDoc.Text = doc;
            }
            else
            {
                txtDoc.Text = string.Empty;
            }
        }

        public void TypeChanged(object sender, EventArgs args)
        {
            var type = lbTypes.SelectedItem as VkDocType;
            if (type != null)
            {   
                if (type.Methods.Count > 0)
                {
                    lbMethods.SelectedIndex = 0;
                    lbMethods.DataSource = type.Methods;
                }
                else
                {
                    lbMethods.DataSource = null;
                    lbMethods.Items.Clear();
                    lbMethods.Items.Add("Тип не имеет методов");
                }
            }
        }
    }
}
