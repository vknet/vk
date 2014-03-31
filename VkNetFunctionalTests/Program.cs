namespace VkNetFunctionalTests
{
    using System;
    using System.Collections.Generic;

    using VkNet;
    using VkNet.Enums;

    internal class Program
    {
        #region Методы

        private static void GetWallRecords(VkApi api)
        {
            api.Audio.GetCount(20);

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
                Console.WriteLine("Usage: VkNetFunctionalTests.exe login password");
                return;
            }

            try
            {
                var api = new VkApi();
                var login = args[0];
                var password = args[1];
                api.Authorize(1, login, password, Settings.Wall | Settings.Audio);
                
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