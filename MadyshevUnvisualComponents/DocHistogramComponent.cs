using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadyshevUnvisualComponents.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace MadyshevUnvisualComponents
{
    public partial class DocHistogramComponent : Component
    {
        public DocHistogramComponent()
        {
            InitializeComponent();
        }

        public DocHistogramComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDoc(string FileName, string Title, string diagramName, LegendLocation legendLocation, List<ChartData> data)
        {
            if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(diagramName) || data.Count == 0)
            {
                throw new Exception("Wrong data, some fields empty");
            }
            using (var document = DocX.Create(FileName))
            {
                document.InsertParagraph(Title).FontSize(35).SpacingAfter(50d).Bold().Alignment = Alignment.center;

                var barChart = document.AddChart<BarChart>();
                barChart.AddLegend((ChartLegendPosition)legendLocation, false);
                Series series = new Series(diagramName);
                series.Bind(data, "Category", "Expenses");
                barChart.AddSeries(series);
                document.InsertChart(barChart);
                document.Save();
            }
        }
    }
}
