using ChainOFResponsablity.Business.UserRegistartion.Exceptions;
using ChainOFResponsablity.Business.UserRegistartion.Models;
using ChainOFResponsablity.Business.UserRegistartion.Validators;

namespace ChainOFResponsablity.Business.UserRegistartion.Handlers;

public class SocialSecurityNumberValidatorHandler :Handler<User>
{
    private SocialSecurityNumberValidator socialSecurityNumberValidator
        = new SocialSecurityNumberValidator();
    override public void Handle(User user)
    {
        if (!socialSecurityNumberValidator.Validate(user.SocialSecurityNumber, user.CitizenshipRegion))
        {
            throw new UserValidationException("Social security number could not be validated.");
        }
        base.Handle(user);
    }

}
