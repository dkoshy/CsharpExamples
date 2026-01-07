using ChainOFResponsablity.Business.UserRegistartion.Handlers;
using ChainOFResponsablity.Business.UserRegistartion.Models;

namespace ChainOFResponsablity.Business;

public class UserProcessor
{
    private IHandler<User> userRegistartionHadndlers;
    public UserProcessor()
    {
        userRegistartionHadndlers = new SocialSecurityNumberValidatorHandler();
        userRegistartionHadndlers.SetNext(new AgeValidationHandler())
              .SetNext(new NameValidationHandler())
              .SetNext(new CitizenshipRegionValidationHandler());
         
    }

    public bool Register(User user)
    {
        try
        {
            userRegistartionHadndlers.Handle(user);
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception
            return false;
        }
    }
}