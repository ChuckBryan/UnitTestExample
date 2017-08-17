namespace RegisterUser
{
    using System;
    using System.Linq;
    using Data;
    using EnsureThat;

    public class AddNewUserService
    {
        private readonly RegisteredUserContext _dbContext;
        private readonly ISendValidationEmail _validationEmailService;
        private readonly ILogger _logger;

        public AddNewUserService(RegisteredUserContext dbContext, 
            ISendValidationEmail validationEmailService, 
            ILogger logger)
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

            var registeredUser = RegisteredUser.Create(displayName, email, password);

            if (_dbContext.RegisteredUsers.Any(x => x.Email.Equals(email)))
            {
                throw new DuplicateEmailError();
            }

            try
            {

                _dbContext.RegisteredUsers.Add(registeredUser);

                _validationEmailService.SendEmail(displayName, email);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected Error during RegisterUser");
                throw;
            }
        }
    }
}