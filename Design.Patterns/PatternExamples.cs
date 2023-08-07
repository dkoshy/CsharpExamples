using Design.Patterns.BuilderPattern;
using Design.Patterns.StrategyPatern.Strategies.SalesTax;
using Design.Patterns.StrategyPatern;
using System;
using System.Collections.Generic;
using Design.Patterns.StrategyPatern.Strategies.Invoice;

namespace Design.Patterns
{
    public static class PatternExamples
    {

        public static void BuilderPatternExample()
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            var InventoryReportBuilder = new FurnitureInvetoryReportBuilder(items);
            var director = new InventoryReportBuildDirector(InventoryReportBuilder);

            director.BuildCompleteReport();

            var report = InventoryReportBuilder.GetReport();

            Console.WriteLine(report.Debug());
        }

        public static void BuilderPatternWithFluentExample()
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem("Sectional Couch", 55.5, 22.4, 78.6, 35.0),
                new FurnitureItem("Nightstand", 25.0, 12.4, 20.0, 10.0),
                new FurnitureItem("Dining Table", 105.0, 35.4, 100.6, 55.5),
            };

            var inventoryBuiderwithFluent = new FurnitureInvetoryReportFluentBuilder(items);
            var report = inventoryBuiderwithFluent
                            .AddTitle()
                            .AddDimensions()
                            .AddLogistics(DateTime.UtcNow)
                            .GetReport();
            Console.WriteLine(report.Debug());

        }

        public static void StrategyPatternExample()
        {
            var sweedenOrder = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                },
                ShippingStatus = ShippingStatus.WaitingForPayment,
                SalesTaxStrategy = new SweedenSalestaxStrategy(),
                InvoiceStrategy = new PrintOnDemandInvoiceStrategy()
            };

            var usOrder = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "USA",
                    DestinationCountry = "USA",
                    DestinationState="la"
                },
                SalesTaxStrategy = new UASSalestaxStrategy()
            };
            Console.WriteLine("----------Sweedan order tax-----------");
            sweedenOrder.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });
            sweedenOrder.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            sweedenOrder.FinalizeOrder();
            Console.WriteLine(sweedenOrder.GetTax());


            Console.WriteLine("----------USA order tax-----------");

            usOrder.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);

            Console.WriteLine(usOrder.GetTax()); // Console.WriteLine(usOrder.GetTax(new SweedenSalestaxStrategy()));
        }

    }
}
