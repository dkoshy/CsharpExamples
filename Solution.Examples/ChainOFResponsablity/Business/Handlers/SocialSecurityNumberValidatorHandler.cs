using ChainOFResponsablity.Business.Exceptions;
using ChainOFResponsablity.Business.Models;
using ChainOFResponsablity.Business.Validators;


namespace ChainOFResponsablity.Business.Handlers;

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
