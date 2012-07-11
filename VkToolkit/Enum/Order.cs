namespace VkToolkit.Enum
{
    public sealed class Order
    {
        private readonly string _name;
        private readonly int _value;

        public static readonly Order Name = new Order(1, "name");
        public static readonly Order Hints = new Order(2, "hints");

        private Order(int value, string name)
        {
            _name = name;
            _value = value;
        }

        public override string ToString()
        {
            return _name;
        }

    }
}