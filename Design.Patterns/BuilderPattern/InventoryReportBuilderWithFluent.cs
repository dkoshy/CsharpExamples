using System;
using System.Collections.Generic;
using System.Linq;

namespace Design.Patterns.BuilderPattern
{
    public interface IInventoryReportFluentBuilder
    {
        IInventoryReportFluentBuilder AddTitle();
        IInventoryReportFluentBuilder AddDimensions();
        IInventoryReportFluentBuilder AddLogistics(DateTime dateTime);
        InventoryReport GetReport();
    }

    public class FurnitureInvetoryReportFluentBuilder : IInventoryReportFluentBuilder
    {
        private InventoryReport _report;
        private readonly IEnumerable<FurnitureItem> _items;

        public FurnitureInvetoryReportFluentBuilder(IEnumerable<FurnitureItem> items)
        {
            ResetReport();
           _items=items;
        }

        private void ResetReport()
        {
            _report = new InventoryReport();
        }

        public IInventoryReportFluentBuilder AddTitle()
        {
            _report.TitleSection = "------Furniture Inventory Report------\n\n";
            return this;
        }
        public IInventoryReportFluentBuilder AddDimensions()
        {
            _report.DimensionsSection = String.Join(Environment.NewLine, _items.Select(p =>

                  $"Product: {p.Name} \n Price: {p.Price} \n" +
                  $"Height: {p.Height} X Width : {p.Width} -> Weight: {p.Weight} lbs \n"
              ));
            return this;
        }

        public IInventoryReportFluentBuilder AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";
            return this;
        }

        public InventoryReport GetReport()
        {
            var finalReport = _report;
            ResetReport();
            return finalReport;
        }
    }


}
