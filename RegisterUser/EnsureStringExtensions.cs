namespace RegisterUser
{
    using System.Text.RegularExpressions;
    using EnsureThat;

    public static class EnsureStringExtensions
    {
        private static string emailPattern =
            "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
            + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

        public static Param<string> IsEmailAddress(this Param<string> param)
        {
            return !Ensure.IsActive ? param : param.Matches(new Regex(emailPattern));
        }
    }
}