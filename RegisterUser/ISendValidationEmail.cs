namespace RegisterUser
{
    public interface ISendValidationEmail
    {
        void SendEmail(string displayName, string email);
    }
}