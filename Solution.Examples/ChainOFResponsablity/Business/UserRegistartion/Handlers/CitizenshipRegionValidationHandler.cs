using ChainOFResponsablity.Business.UserRegistartion.Models;

namespace ChainOFResponsablity.Business.UserRegistartion.Handlers;

public  class CitizenshipRegionValidationHandler:Handler<User>
{

    public override void Handle(User request)
    {
        if (request.CitizenshipRegion.TwoLetterISORegionName == "NO")
        {
           throw new Exception("Users from Norway are not allowed.");
        }
       base.Handle(request);
    }

}
