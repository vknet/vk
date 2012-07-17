namespace VkToolkit.Enums
{
    public sealed class Order
    {
        private readonly string _name;

        public static readonly Order Name = new Order("name");
        public static readonly Order Hints = new Order("hints");

        private Order(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

    }
}