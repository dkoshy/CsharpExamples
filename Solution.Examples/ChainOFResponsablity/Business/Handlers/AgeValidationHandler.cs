using ChainOFResponsablity.Business.Exceptions;
using ChainOFResponsablity.Business.Models;

namespace ChainOFResponsablity.Business.Handlers;

public class AgeValidationHandler:Handler<User>
{
    public override void Handle(User request)
    {
        if (request.Age < 18)
        {
            throw new UserValidationException("user age is desn't match the requirement");
        }
       base.Handle(request);
    }
}
