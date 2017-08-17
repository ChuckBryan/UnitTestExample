namespace RegisterUser.Data
{
    using System;

    public class RegisteredUser
    {

        private RegisteredUser()
        {
            Id = Guid.NewGuid();
        }

        public static RegisteredUser Create(string displayName, string email, string password)
        {
            return new RegisteredUser
            {
                DisplayName = displayName,
                Email = email,
                Password = password
            };
        }


        public Guid Id { get; }

        public string DisplayName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
        
    }
}