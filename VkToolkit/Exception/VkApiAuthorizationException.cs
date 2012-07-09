namespace VkToolkit.Exception
{
    class VkApiAuthorizationException : VkApiException
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public VkApiAuthorizationException(string message) : base(message) { }
        public VkApiAuthorizationException(string message, string email, string password) : this(message)
        {
            Email = email;
            Password = password;
        }
    }
}
