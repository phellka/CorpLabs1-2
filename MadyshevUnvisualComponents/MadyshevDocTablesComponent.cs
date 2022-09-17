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
    public partial class MadyshevDocTablesComponent : Component
    {
        private WordprocessingDocument wordDocument;
        private Body docBody;
        public MadyshevDocTablesComponent()
        {
            InitializeComponent();
        }

        public MadyshevDocTablesComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateDoc(string FileName, string Title, List<String[,]> tables)
        {
            if (!CheckTableIsNull(tables))
            {
                throw new Exception("Wrong data, some cell empty");
            }
            CreateWord(FileName);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (Title, new WordTextProperties { Bold = true, Size = "24" }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            for (int i = 0; i < tables.Count; ++i)
            {
                CreateTable(tables[i]);
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)>(),
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Center
                    }
                });
            }
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
        protected void CreateParagraph(WordParagraph paragraph)
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
        protected void CreateTable(String[,] strings)
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
            for (int i = 0; i < strings.GetLength(0); ++i)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < strings.GetLength(1); ++j)
                {
                    TableCell cell = new TableCell();
                    Paragraph paragraph = new Paragraph(new Run(new Text(strings[i, j])));
                    cell.Append(paragraph);
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
        private bool CheckTableIsNull(List<string[,]> tables)
        {
            foreach (string[,] table in tables)
            {
                for (int i = 0; i < table.GetLength(0); ++i)
                {
                    for (int j = 0; j < table.GetLength(1); ++j)
                    {
                        if (table[i, j] == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
