namespace VkApiGenerator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var methods = new[]
            {
                "notes.get",
                "notes.getById",
                "notes.getFriendsNotes",
                "notes.add",
                "notes.edit",
                "notes.delete",
                "notes.getComments",
                "notes.createComment",
                "notes.editComment",
                "notes.deleteComment",
                "notes.restoreComment"
            };
            var parser = new VkApiParser();
            
            foreach (string methodName in methods)
            {
                System.Console.WriteLine("*** {0} ***", methodName);
                var methodInfo = parser.Parse(methodName);
                System.Console.WriteLine("DESCRIPTION: {0}", methodInfo.Description);
                System.Console.WriteLine("RETURN TEXT: {0}", methodInfo.ReturnText);
                System.Console.WriteLine("RETURN TYPE: {0}", methodInfo.ReturnType);

                System.Console.WriteLine("PAPAMETERS:");
                foreach (var p in methodInfo.Params)
                {
                    System.Console.WriteLine("    {0} - {1}", p.Name, p.Description);
                }

                System.Console.WriteLine("\n========================================\n");
                System.Console.ReadLine();
            }

            System.Console.WriteLine("done.");
        }
    }
}
