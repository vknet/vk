namespace VkToolkitFunctionalTests
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Schema;

    using VkToolkit;
    using VkToolkit.Enums;

    internal class Program
    {
        #region Методы

        private static void GetWallRecords(VkApi api)
        {

            int totalCount;
            var wallRecords = api.Wall.Get(1, out totalCount);
            var posts = new List<string>();
            foreach (var wallRecord in wallRecords)
                posts.Add("1_" + wallRecord.Id);

            var records = api.Wall.GetById(posts);
        }

        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: VkToolkitFunctionalTests.exe login password");
                return;
            }

            try
            {
                var api = new VkApi();
                var login = args[0];
                var password = args[1];
                api.Authorize(1, login, password, Settings.Wall);
                
                GetWallRecords(api);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion
    }
}