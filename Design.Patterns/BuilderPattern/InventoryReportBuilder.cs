using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Patterns.BuilderPattern
{
    public interface IInventoryReportBuilder
    {
        void AddTitle();
        void AddDimensions();
        void AddLogistics(DateTime dateTime);
        InventoryReport GetReport();
    }


    public class FurnitureInvetoryReportBuilder : IInventoryReportBuilder
    {
        private InventoryReport _report;
        private readonly IEnumerable<FurnitureItem> _items;

        public FurnitureInvetoryReportBuilder(IEnumerable<FurnitureItem> items)
        {
            ResetReport();
            _items=items;
        }


        public void ResetReport()
        {
            _report = new InventoryReport();
        }

        public void AddDimensions()
        {
            _report.DimensionsSection = String.Join(Environment.NewLine, _items.Select(p =>

                 $"Product: {p.Name} \n Price: {p.Price} \n" +
                 $"Height: {p.Height} X Width : {p.Width} -> Weight: {p.Weight} lbs \n"
             ));
        }

        public void AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";

        }

        public void AddTitle()
        {
            _report.TitleSection = "------Furniture Inventory Report------\n\n";
        }

        public InventoryReport GetReport()
        {
            InventoryReport finishedReport = _report;
            ResetReport();
            return finishedReport;
        }
    }

    public class InventoryReportBuildDirector
    {
        private readonly IInventoryReportBuilder _builder;

        public InventoryReportBuildDirector(IInventoryReportBuilder builder)
        {
            _builder=builder;
        }

        public void BuildCompleteReport()
        {
            _builder.AddTitle();
            _builder.AddDimensions();
            _builder.AddLogistics(DateTime.Now);
        }
    }

}
