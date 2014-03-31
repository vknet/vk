namespace VkWikiGenerator
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var gen = new DocGenFramework();
            string xml = DocGenFramework.ReadFile("Vk.Net.xml");
            gen.Parse(xml);

            Application.Run(new DocForm(gen.Types.OrderBy(t => t.FullName)));
        }
    }
}