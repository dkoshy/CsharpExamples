using ChainOFResponsablity.Business.Handlers;
using ChainOFResponsablity.Business.Models;
using ChainOFResponsablity.Business.Validators;

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