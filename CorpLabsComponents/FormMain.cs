using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadyshevVisualComponents.models;
using CorpLabsComponents.models;
using MadyshevUnvisualComponents;
using MadyshevUnvisualComponents.Models;

namespace CorpLabsComponents
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            madyshevListBox.AddItem("1");
            madyshevListBox.AddItem("Two");
            madyshevListBox.AddItem("3");
            madyshevListBox.AddItem("4");
            madyshevListBox.AddItem("Five");
            madyshevListBox.AddItem("6");

            madyshevDataGridView.AddColumns(new List<TableData>() {
                new TableData() { Header = "Age", PropertyName = "Age", Visible = true, Width = 50},
                new TableData() { Header = "Name", PropertyName = "Name", Visible = true, Width = 100},
                new TableData() { Header = "Surname", PropertyName = "Surname", Visible = true, Width = 200},
                new TableData() { Header = "Id", PropertyName = "Id", Visible = true, Width = 20 } });
            madyshevDataGridView.AddRow(new Human() { Id = 1, Age = 15, Name = "Pavel", Surname = "Pavlov" });
            madyshevDataGridView.AddRow(new Human() { Id = 2, Age = 24, Name = "Artem", Surname = "Artemov" });
            madyshevDataGridView.AddRow(new Human() { Id = 3, Age = 38, Name = "Ivan", Surname = "Ivanov" });
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            madyshevListBox.ClearItems();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            string select = madyshevListBox.ListBoxValue;
            MessageBox.Show(select, "selected item");
        }

        private void buttonSetSelected_Click(object sender, EventArgs e)
        {
            madyshevListBox.ListBoxValue = textBoxSelectedItem.Text;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                double? value = madyshevTextBox.TextBoxValue;
                MessageBox.Show(value?.ToString(), "value");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClearGrid_Click(object sender, EventArgs e)
        {
            madyshevDataGridView.ClearRows();
        }

        private void buttonGetSelectedIndexGrid_Click(object sender, EventArgs e)
        {
            MessageBox.Show(madyshevDataGridView.DataGridSelectedRow.ToString(), "selected item");
        }

        private void buttonSetSelectedIndexGrid_Click(object sender, EventArgs e)
        {
            madyshevDataGridView.DataGridSelectedRow = ((int)numericUpDownSelectedIndexGrid.Value);
        }

        private void buttonGriSelectedObjectGrid_Click(object sender, EventArgs e)
        {
            MessageBox.Show(madyshevDataGridView.GetSelectedObjectIntoRow<Human>().ToString(), "Selected object");
        }

        private void buttonDoucmentWithTable_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" }) {
                using (var docTables = new MadyshevDocTablesComponent())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        docTables.CreateDoc(dialog.FileName, "Tema", new List<string[,]>()
                        {
                            new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" }, { "10", "11", "12"} },
                            new string[,] { { "1", "2" }, { "3", "4"}, { "5", "6"}},
                            new string[,] { { "1"}, { "4"}, { "7"}, { "10"} }
                        });
                        MessageBox.Show("Complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void buttonCreateDocCustomTable_Click(object sender, EventArgs e)
        {
            using (MadyshevCustomTableComponent docCustomTableComponent = new MadyshevCustomTableComponent()) {
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        docCustomTableComponent.CreateDoc(new CustomTableData<Human>()
                        {
                            FileName = dialog.FileName,
                            Title = "Tema",
                            HeaderHeight = 1200,
                            RowsHeight = 800,
                            ColumnsHeaders = new List<string>()
                                {
                                "Возраст", "Имя", "Фамилия", "Номер"
                                },
                            ColumnsWidth = new List<int>()
                                {
                                1000, 1000, 1000, 800
                                },
                            ColumnsProperties = new List<string>()
                                {
                                "Age", "Name", "Surname", "Id"
                                },
                            Data = new List<Human>()
                                {
                                new Human() { Id = 1, Age = 15, Name = "Pavel", Surname = "Pavlov" },
                                new Human() { Id = 2, Age = 22, Name = "Artem", Surname = "Artemov" },
                                new Human() { Id = 3, Age = 62, Name = "Ivan", Surname = "Ivanov" }
                                }
                        });
                        MessageBox.Show("Complete", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonCreateDocHistogram_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" }) {
                using (var docHistogram = new DocHistogramComponent())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        docHistogram.CreateDoc(dialog.FileName, "Tema", "Series", LegendLocation.TopRight, new List<ChartData>() {
                            new ChartData() { Category = "cat", Expenses = 1 },
                            new ChartData() { Category = "dog", Expenses = 2 },
                            new ChartData() { Category = "human", Expenses = 5 },
                            new ChartData() { Category = "mouse", Expenses = 1 }
                        });
                        MessageBox.Show("Complete", "Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
