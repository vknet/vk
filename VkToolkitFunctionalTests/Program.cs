namespace VkToolkitFunctionalTests
{
    using System;

    using VkToolkit;
    using VkToolkit.Enums;

    internal class Program
    {
        #region Методы

        private static void GetWallRecords(VkApi api)
        {
            int totalCount;
//        http://vk.com/photo_309174055
            var wallRecords = api.Wall.Get(136781122, out totalCount);
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