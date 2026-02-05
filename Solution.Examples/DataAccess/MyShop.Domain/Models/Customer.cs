using MyShop.Domain.Lazy;
using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        // private byte[] _profilePicture;

        // public Lazy<byte[]> ProfilePictureValueHolder { get; set; }
        //public IValueHolder<byte[]> ProfilePictureValueHolder { get; set; }
        public virtual byte[] ProfilePicture
        {
            //get
            //{
            //    return ProfilePictureValueHolder.Value;
            //}

            //get
            //{
            //    return ProfilePictureValueHolder.GetValue(this.CustomerId);
            //}

            get; set;
        }


        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
