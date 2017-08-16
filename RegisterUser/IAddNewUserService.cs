namespace RegisterUser
{
    using System;
    using System.Linq;
    using EnsureThat;

    public interface IAddNewUserService
    {
        void AddUser(string displayName, string email, string password);

    }

    public class AddNewUserService : IAddNewUserService
    {
        private readonly RegisteredUserContext _dbContext;
        private readonly ISendValidationEmail _validationEmailService;
        private readonly ILogger _logger;

        public AddNewUserService(RegisteredUserContext dbContext, ISendValidationEmail validationEmailService, ILogger logger)
        {
            _dbContext = dbContext;
            _validationEmailService = validationEmailService;
            _logger = logger;
        }

        public void AddUser(string displayName, string email, string password)
        {
            Ensure.That(displayName).IsNotNullOrEmpty();
            Ensure.That(email).IsEmailAddress();
            Ensure.That(password).IsNotNullOrEmpty();

            if (_dbContext.RegisteredUsers.Any(x => x.Email.Equals(email)))
            {
                throw new DuplicateEmailError();
            }

            try
            {
                _dbContext.RegisteredUsers.Add(
                    new RegisteredUser {DisplayName = displayName, Email = email, Password = password});

                _validationEmailService.SendEmail(displayName, email);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected Error during RegisterUser");
                throw;
            }
        }
    }
}