using System;

namespace Design.Patterns.ChainofResponsiblity
{
    public class UserValidationException: Exception
    {
        public UserValidationException(string message)
            :base(message)
        {
                
        }
    }
}
