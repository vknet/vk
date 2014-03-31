namespace VkWikiGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using VkWikiGenerator.DocGen;

    internal partial class DocForm : Form
    {
        public DocForm(IEnumerable<VkDocType> types)
        {
            InitializeComponent();

            var typesList = new List<VkDocType>(types);

            lbTypes.DataSource = typesList;
            lbTypes.SelectedIndex = 0;

            if (typesList.Count > 0)
            {
                lbMethods.DataSource = typesList[0].Methods;
                if (lbMethods.Items.Count > 0)
                    lbMethods.SelectedIndex = 0;
            }
        }

        public void MethodChanged(object sender, EventArgs args)
        {
            var method = lbMethods.SelectedItem as VkDocMethod;
            if (method != null)
            {
                string doc = DocGenFramework.GenerateWikiMethod(method);
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
