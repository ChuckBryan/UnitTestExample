namespace RegisterUser
{
    using System;

    public interface ILogger
    {
        void Error(Exception exception, string message);
    }
}