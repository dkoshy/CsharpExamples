namespace Design.Patterns.ChainofResponsiblity
{
    public class UserProcessor
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator
            = new SocialSecurityNumberValidator();

        public bool Register(User user)
        {
            if (!socialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.CitizenshipRegion))
            {
                return false;
            }
            else if (user.Age < 18)
            {
                return false;
            }
            else if (user.Name.Length <= 1)
            {
                return false;
            }
            else if (user.CitizenshipRegion.TwoLetterISORegionName == "NO")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
