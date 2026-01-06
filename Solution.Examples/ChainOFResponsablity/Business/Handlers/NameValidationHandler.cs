using ChainOFResponsablity.Business.Exceptions;
using ChainOFResponsablity.Business.Models;

namespace ChainOFResponsablity.Business.Handlers;

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
