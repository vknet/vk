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
            var wallRecords = api.Wall.Get(12312, out totalCount);
            foreach (var wallRecord in wallRecords)
            {
                if (wallRecord.Comments.Count > 0)
                {
                    int totalCommentsCount;
                    var comments = api.Wall.GetComments(12312, wallRecord.Id, out totalCommentsCount, CommentsSort.Ascending, true);
                }
            }
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