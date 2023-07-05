using Design.Patterns.BuilderPattern;
using System;
using System.Collections.Generic;

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


    }
}
