using ChainOFResponsablity.Business.UserRegistartion.Exceptions;
using ChainOFResponsablity.Business.UserRegistartion.Models;

namespace ChainOFResponsablity.Business.UserRegistartion.Handlers;

public class NameValidationHandler : Handler<User>
{

    public override void Handle(User request)
    {
        if (request.Name.Length <= 1)
        {
            throw new UserValidationException("Name could not be validated.");
        }
        base.Handle(request);
    }
}
