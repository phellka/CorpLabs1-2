using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadyshevUnvisualComponents.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Reflection;

namespace MadyshevUnvisualComponents
{
    public partial class MadyshevCustomTableComponent : Component
    {
        private WordprocessingDocument wordDocument;
        private Body docBody;
        public MadyshevCustomTableComponent()
        {
            InitializeComponent();
        }

        public MadyshevCustomTableComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDoc<T>(CustomTableData<T> tableData)
        {
            CheckData(tableData);
            CreateWord(tableData.FileName);
            AddParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (tableData.Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            CreateTable(tableData);
            SaveWord();
        }
        private static JustificationValues GetJustificationValues(WordJustificationType type)
        {
            if (type == WordJustificationType.Both)
            {
                return JustificationValues.Both;
            }
            if (type == WordJustificationType.Center)
            {
                return JustificationValues.Center;
            }
            return JustificationValues.Left;
        }
        private static SectionProperties CreateSectionProperties()
        {
            var properties = new SectionProperties();
            var pageSize = new PageSize
            {
                Orient = PageOrientationValues.Portrait
            };
            properties.AppendChild(pageSize);
            return properties;
        }
        private static ParagraphProperties CreateParagraphProperties(WordTextProperties paragraphProperites)
        {
            if (paragraphProperites != null)
            {
                var properites = new ParagraphProperties();
                properites.AppendChild(new Justification() { Val = GetJustificationValues(paragraphProperites.JustificationType) });
                properites.AppendChild(new SpacingBetweenLines { LineRule = LineSpacingRuleValues.Auto });
                properites.AppendChild(new Indentation());
                var paragraphMarkRunProperties = new ParagraphMarkRunProperties();
                if (!string.IsNullOrEmpty(paragraphProperites.Size))
                {
                    paragraphMarkRunProperties.AppendChild(new FontSize { Val = paragraphProperites.Size });
                }
                properites.AppendChild(paragraphMarkRunProperties);
                return properites;
            }
            return null;
        }
        protected void CreateWord(string FileName)
        {
            wordDocument = WordprocessingDocument.Create(FileName, WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            docBody = mainPart.Document.AppendChild(new Body());
        }
        protected void AddParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                var docParagraph = new Paragraph();
                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    var docRun = new Run();
                    var properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                docBody.AppendChild(docParagraph);
            }
        }
        protected Paragraph CreateParagraph(WordParagraph paragraph)
        {
            if (paragraph != null)
            {
                var docParagraph = new Paragraph();
                docParagraph.AppendChild(CreateParagraphProperties(paragraph.TextProperties));
                foreach (var run in paragraph.Texts)
                {
                    var docRun = new Run();
                    var properties = new RunProperties();
                    properties.AppendChild(new FontSize { Val = run.Item2.Size });
                    if (run.Item2.Bold)
                    {
                        properties.AppendChild(new Bold());
                    }
                    docRun.AppendChild(properties);
                    docRun.AppendChild(new Text
                    {
                        Text = run.Item1,
                        Space = SpaceProcessingModeValues.Preserve
                    });
                    docParagraph.AppendChild(docRun);
                }
                return docParagraph;
            }
            else
            {
                return null;
            }
        }
        protected void CreateTable<T>(CustomTableData<T> tableData)
        {
            Table table = new Table();
            TableProperties tblProperties = new TableProperties();
            TableBorders tblBorders = new TableBorders();
            TopBorder topBorder = new TopBorder();
            topBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            topBorder.Color = "#000000";
            tblBorders.AppendChild(topBorder);
            BottomBorder bottomBorder = new BottomBorder();
            bottomBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            bottomBorder.Color = "#000000";
            tblBorders.AppendChild(bottomBorder);
            RightBorder rightBorder = new RightBorder();
            rightBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            rightBorder.Color = "#000000";
            tblBorders.AppendChild(rightBorder);
            LeftBorder leftBorder = new LeftBorder();
            leftBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            leftBorder.Color = "#000000";
            tblBorders.AppendChild(leftBorder);
            InsideHorizontalBorder insideHBorder = new InsideHorizontalBorder();
            insideHBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            insideHBorder.Color = "#000000";
            tblBorders.AppendChild(insideHBorder);
            InsideVerticalBorder insideVBorder = new InsideVerticalBorder();
            insideVBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
            insideVBorder.Color = "#000000";
            tblBorders.AppendChild(insideVBorder);
            tblProperties.AppendChild(tblBorders);
            table.AppendChild(tblProperties);


            TableRow rowHeader = new TableRow();
            TableRowHeight rowHeaderHeight = new TableRowHeight();
            rowHeaderHeight.Val = Convert.ToUInt32(tableData.HeaderHeight);
            rowHeader.AddChild(new TableRowProperties(rowHeaderHeight));
            for (int j = 0; j < tableData.ColumnsHeaders.Count; ++j)
            {
                TableCell cell = new TableCell();
                Paragraph paragraph = new Paragraph(new Run(new Text(tableData.ColumnsHeaders[j])));
                cell.Append(paragraph);

                TableCellWidth tableCellWidth = new TableCellWidth();
                tableCellWidth.Width = tableData.ColumnsWidth[j].ToString();
                tableCellWidth.Type = TableWidthUnitValues.Dxa;
                cell.AddChild(new TableCellProperties(tableCellWidth, new Bold()));

                cell.AddChild(CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { (tableData.ColumnsHeaders[j], new
                        WordTextProperties {Bold = true, Size = "24", } ) }
                }));
                rowHeader.Append(cell);
            }
            table.Append(rowHeader);

            var property = new List<PropertyInfo>();
            var type = typeof(T);

            for (int i = 0; i < tableData.ColumnsProperties.Count; ++i)
            {
                var propInfo = type.GetProperty(tableData.ColumnsProperties[i]);
                if (propInfo == null)
                {
                    throw new Exception("propery doesnt exists" + tableData.ColumnsProperties[i]);
                }
                property.Add(propInfo);
            }


            for (int i = 0; i < tableData.Data.Count; ++i)
            {
                TableRow row = new TableRow();
                TableRowHeight rowHeight = new TableRowHeight();
                rowHeight.Val = Convert.ToUInt32(tableData.RowsHeight);
                row.AddChild(new TableRowProperties(rowHeight));
                for (int j = 0; j < tableData.ColumnsProperties.Count; ++j)
                {
                    TableCell cell = new TableCell();
                    TableCellWidth tableCellWidth = new TableCellWidth();
                    tableCellWidth.Width = tableData.ColumnsWidth[j].ToString();
                    tableCellWidth.Type = TableWidthUnitValues.Dxa;
                    cell.AddChild(new TableCellProperties(tableCellWidth));
                    cell.AddChild(CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { (property[j].GetValue(tableData.Data[i]).ToString(), new
                            WordTextProperties {Bold = (j == 0), Size = "24", } ) }
                    }));
                    row.Append(cell);
                }
                table.Append(row);
            }

            docBody.AppendChild(table);
        }
        protected void SaveWord()
        {
            docBody.AppendChild(CreateSectionProperties());
            wordDocument.MainDocumentPart.Document.Save();
            wordDocument.Close();
        }
        private void CheckData<T>(CustomTableData<T> tableData)
        {
            if (tableData.Data == null || tableData.Data.Count == 0)
            {
                throw new Exception("table data is empty");
            }
            if (tableData.ColumnsWidth == null || tableData.ColumnsWidth.Count == 0)
            {
                throw new Exception("table ColumnsWidth data is empty");
            }
            if (tableData.ColumnsHeaders == null || tableData.ColumnsHeaders.Count == 0)
            {
                throw new Exception("table ColumnsHeaders data is empty");
            }
            if (tableData.ColumnsProperties == null || tableData.ColumnsProperties.Count == 0)
            {
                throw new Exception("table ColumnsProperties data is empty");
            }
            if (tableData.RowsHeight == null || tableData.HeaderHeight == null)
            {
                throw new Exception("some table row height is emty");
            }
            if (tableData.ColumnsWidth.Count != tableData.ColumnsHeaders.Count ||
                tableData.ColumnsHeaders.Count != tableData.ColumnsProperties.Count)
            {
                throw new Exception("lack of data");
            }
        }
    }
}
