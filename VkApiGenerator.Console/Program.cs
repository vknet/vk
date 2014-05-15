namespace VkApiGenerator.Console
{
    class Program
    {
        public const string VkPrefix = "https://vk.com/dev/";

        static void Main(string[] args)
        {
            var parser = new VkApiParser();

            var methodInfo = parser.Parse("notes.get");
            System.Console.WriteLine(methodInfo.Description);

            foreach (var p in methodInfo.Params)
            {
                System.Console.WriteLine("{0} - {1}", p.Name, p.Description);
            }


            System.Console.WriteLine("done.");
        }
    }
}
