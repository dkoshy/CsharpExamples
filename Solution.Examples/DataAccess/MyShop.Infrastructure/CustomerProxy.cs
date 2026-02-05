using MyShop.Domain.Models;

namespace MyShop.Infrastructure;

public class CustomerProxy : Customer
{
    override public byte[] ProfilePicture
    {

        get
        {
            if (base.ProfilePicture == null)
                // Lazy loading the profile picture
                base.ProfilePicture = ProfilePictureService.GetFor(base.Name);
            return base.ProfilePicture;
        }

    }
}
