namespace VkWikiGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using VkWikiGenerator.DocGen;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), "VkNet.dll"));
            var gen = new DocGenFramework();
            string xml = DocGenFramework.ReadFile("VkNet.xml");
            gen.Parse(xml);

            Application.Run(new DocForm(gen.Types.OrderBy(t => t.FullName)));
        }
    }
}