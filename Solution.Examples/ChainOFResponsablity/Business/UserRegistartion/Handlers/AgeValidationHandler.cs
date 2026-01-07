using ChainOFResponsablity.Business.UserRegistartion.Exceptions;
using ChainOFResponsablity.Business.UserRegistartion.Models;

namespace ChainOFResponsablity.Business.UserRegistartion.Handlers;

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
