using ChainOFResponsablity.Business;
using ChainOFResponsablity.Business.PaymnetProcessing.Handlers;
using ChainOFResponsablity.Business.PaymnetProcessing.Models;
using ChainOFResponsablity.Business.PaymnetProcessing.Receivers;
using ChainOFResponsablity.Business.UserRegistartion.Models;
using System.Globalization;



public class Program
{
    private static void Main(string[] args)
    {
        PaymentProcess();

        static void UserProcessRegisterUser()
        {
            var user = new User("Deepak Koshy",
                    "",
                    new RegionInfo("SE"),
                    new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));


            Console.WriteLine(user.Age);
            var processor = new UserProcessor();

            var ressult = processor.Register(user);

            Console.WriteLine(ressult);
        }

        static void PaymentProcess()
        {
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);

            /*
            var handler = new CreditCardHandler();
            handler.SetNext(new PaypalHandler())
                   .SetNext(new InvoiceHandler());*/

            var handler = new PaymentHandlerWithReceiveers();
            handler.Addreceiver(new CardHabdlerReceiver());
            handler.Addreceiver(new PaypalHandlerReceiver());
            handler.Addreceiver(new InvoiceHandlerReceiver());

            handler.Handle(order);
     

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}