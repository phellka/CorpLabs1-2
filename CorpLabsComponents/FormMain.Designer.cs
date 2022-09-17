
namespace CorpLabsComponents
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonGetSelected = new System.Windows.Forms.Button();
            this.buttonSetSelected = new System.Windows.Forms.Button();
            this.textBoxSelectedItem = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonClearGrid = new System.Windows.Forms.Button();
            this.buttonGriSelectedObjectGrid = new System.Windows.Forms.Button();
            this.buttonSetSelectedIndexGrid = new System.Windows.Forms.Button();
            this.buttonGetSelectedIndexGrid = new System.Windows.Forms.Button();
            this.numericUpDownSelectedIndexGrid = new System.Windows.Forms.NumericUpDown();
            this.buttonDoucmentWithTable = new System.Windows.Forms.Button();
            this.buttonCreateDocWithCustomTable = new System.Windows.Forms.Button();
            this.madyshevDataGridView = new MadyshevVisualComponents.MadyshevDataGridView();
            this.madyshevTextBox = new MadyshevVisualComponents.MadyshevTextBox();
            this.madyshevListBox = new MadyshevVisualComponents.MadyshevListBox();
            this.buttonCreateDocHistogram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedIndexGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(10, 78);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(64, 20);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonGetSelected
            // 
            this.buttonGetSelected.Location = new System.Drawing.Point(98, 78);
            this.buttonGetSelected.Name = "buttonGetSelected";
            this.buttonGetSelected.Size = new System.Drawing.Size(74, 20);
            this.buttonGetSelected.TabIndex = 2;
            this.buttonGetSelected.Text = "Get Selected";
            this.buttonGetSelected.UseVisualStyleBackColor = true;
            this.buttonGetSelected.Click += new System.EventHandler(this.buttonGetSelected_Click);
            // 
            // buttonSetSelected
            // 
            this.buttonSetSelected.Location = new System.Drawing.Point(98, 115);
            this.buttonSetSelected.Name = "buttonSetSelected";
            this.buttonSetSelected.Size = new System.Drawing.Size(74, 20);
            this.buttonSetSelected.TabIndex = 4;
            this.buttonSetSelected.Text = "Set Selected";
            this.buttonSetSelected.UseVisualStyleBackColor = true;
            this.buttonSetSelected.Click += new System.EventHandler(this.buttonSetSelected_Click);
            // 
            // textBoxSelectedItem
            // 
            this.textBoxSelectedItem.Location = new System.Drawing.Point(10, 116);
            this.textBoxSelectedItem.Name = "textBoxSelectedItem";
            this.textBoxSelectedItem.Size = new System.Drawing.Size(65, 20);
            this.textBoxSelectedItem.TabIndex = 5;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(246, 53);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(74, 20);
            this.buttonEnter.TabIndex = 7;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonClearGrid
            // 
            this.buttonClearGrid.Location = new System.Drawing.Point(387, 224);
            this.buttonClearGrid.Name = "buttonClearGrid";
            this.buttonClearGrid.Size = new System.Drawing.Size(64, 20);
            this.buttonClearGrid.TabIndex = 9;
            this.buttonClearGrid.Text = "Clear";
            this.buttonClearGrid.UseVisualStyleBackColor = true;
            this.buttonClearGrid.Click += new System.EventHandler(this.buttonClearGrid_Click);
            // 
            // buttonGriSelectedObjectGrid
            // 
            this.buttonGriSelectedObjectGrid.Location = new System.Drawing.Point(560, 224);
            this.buttonGriSelectedObjectGrid.Name = "buttonGriSelectedObjectGrid";
            this.buttonGriSelectedObjectGrid.Size = new System.Drawing.Size(116, 20);
            this.buttonGriSelectedObjectGrid.TabIndex = 10;
            this.buttonGriSelectedObjectGrid.Text = "Get Selected Object";
            this.buttonGriSelectedObjectGrid.UseVisualStyleBackColor = true;
            this.buttonGriSelectedObjectGrid.Click += new System.EventHandler(this.buttonGriSelectedObjectGrid_Click);
            // 
            // buttonSetSelectedIndexGrid
            // 
            this.buttonSetSelectedIndexGrid.Location = new System.Drawing.Point(465, 259);
            this.buttonSetSelectedIndexGrid.Name = "buttonSetSelectedIndexGrid";
            this.buttonSetSelectedIndexGrid.Size = new System.Drawing.Size(82, 20);
            this.buttonSetSelectedIndexGrid.TabIndex = 11;
            this.buttonSetSelectedIndexGrid.Text = "Set Selected";
            this.buttonSetSelectedIndexGrid.UseVisualStyleBackColor = true;
            this.buttonSetSelectedIndexGrid.Click += new System.EventHandler(this.buttonSetSelectedIndexGrid_Click);
            // 
            // buttonGetSelectedIndexGrid
            // 
            this.buttonGetSelectedIndexGrid.Location = new System.Drawing.Point(465, 224);
            this.buttonGetSelectedIndexGrid.Name = "buttonGetSelectedIndexGrid";
            this.buttonGetSelectedIndexGrid.Size = new System.Drawing.Size(82, 20);
            this.buttonGetSelectedIndexGrid.TabIndex = 12;
            this.buttonGetSelectedIndexGrid.Text = "Get Selected";
            this.buttonGetSelectedIndexGrid.UseVisualStyleBackColor = true;
            this.buttonGetSelectedIndexGrid.Click += new System.EventHandler(this.buttonGetSelectedIndexGrid_Click);
            // 
            // numericUpDownSelectedIndexGrid
            // 
            this.numericUpDownSelectedIndexGrid.Location = new System.Drawing.Point(387, 258);
            this.numericUpDownSelectedIndexGrid.Name = "numericUpDownSelectedIndexGrid";
            this.numericUpDownSelectedIndexGrid.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownSelectedIndexGrid.TabIndex = 13;
            // 
            // buttonDoucmentWithTable
            // 
            this.buttonDoucmentWithTable.Location = new System.Drawing.Point(12, 224);
            this.buttonDoucmentWithTable.Name = "buttonDoucmentWithTable";
            this.buttonDoucmentWithTable.Size = new System.Drawing.Size(160, 23);
            this.buttonDoucmentWithTable.TabIndex = 14;
            this.buttonDoucmentWithTable.Text = "Document with table";
            this.buttonDoucmentWithTable.UseVisualStyleBackColor = true;
            this.buttonDoucmentWithTable.Click += new System.EventHandler(this.buttonDoucmentWithTable_Click);
            // 
            // buttonCreateDocWithCustomTable
            // 
            this.buttonCreateDocWithCustomTable.Location = new System.Drawing.Point(10, 258);
            this.buttonCreateDocWithCustomTable.Name = "buttonCreateDocWithCustomTable";
            this.buttonCreateDocWithCustomTable.Size = new System.Drawing.Size(162, 23);
            this.buttonCreateDocWithCustomTable.TabIndex = 15;
            this.buttonCreateDocWithCustomTable.Text = "Document custom table";
            this.buttonCreateDocWithCustomTable.UseVisualStyleBackColor = true;
            this.buttonCreateDocWithCustomTable.Click += new System.EventHandler(this.buttonCreateDocCustomTable_Click);
            // 
            // madyshevDataGridView
            // 
            this.madyshevDataGridView.DataGridSelectedRow = -1;
            this.madyshevDataGridView.Location = new System.Drawing.Point(387, 10);
            this.madyshevDataGridView.Name = "madyshevDataGridView";
            this.madyshevDataGridView.Size = new System.Drawing.Size(289, 195);
            this.madyshevDataGridView.TabIndex = 8;
            // 
            // madyshevTextBox
            // 
            this.madyshevTextBox.Location = new System.Drawing.Point(225, 10);
            this.madyshevTextBox.Name = "madyshevTextBox";
            this.madyshevTextBox.Size = new System.Drawing.Size(129, 38);
            this.madyshevTextBox.TabIndex = 6;
            this.madyshevTextBox.TextBoxValue = null;
            // 
            // madyshevListBox
            // 
            this.madyshevListBox.ListBoxValue = "";
            this.madyshevListBox.Location = new System.Drawing.Point(10, 10);
            this.madyshevListBox.Name = "madyshevListBox";
            this.madyshevListBox.Size = new System.Drawing.Size(161, 62);
            this.madyshevListBox.TabIndex = 0;
            // 
            // buttonCreateDocHistogram
            // 
            this.buttonCreateDocHistogram.Location = new System.Drawing.Point(10, 288);
            this.buttonCreateDocHistogram.Name = "buttonCreateDocHistogram";
            this.buttonCreateDocHistogram.Size = new System.Drawing.Size(161, 23);
            this.buttonCreateDocHistogram.TabIndex = 16;
            this.buttonCreateDocHistogram.Text = "Document with histogram";
            this.buttonCreateDocHistogram.UseVisualStyleBackColor = true;
            this.buttonCreateDocHistogram.Click += new System.EventHandler(this.buttonCreateDocHistogram_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.buttonCreateDocHistogram);
            this.Controls.Add(this.buttonCreateDocWithCustomTable);
            this.Controls.Add(this.buttonDoucmentWithTable);
            this.Controls.Add(this.numericUpDownSelectedIndexGrid);
            this.Controls.Add(this.buttonGetSelectedIndexGrid);
            this.Controls.Add(this.buttonSetSelectedIndexGrid);
            this.Controls.Add(this.buttonGriSelectedObjectGrid);
            this.Controls.Add(this.buttonClearGrid);
            this.Controls.Add(this.madyshevDataGridView);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.madyshevTextBox);
            this.Controls.Add(this.textBoxSelectedItem);
            this.Controls.Add(this.buttonSetSelected);
            this.Controls.Add(this.buttonGetSelected);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.madyshevListBox);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedIndexGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MadyshevVisualComponents.MadyshevListBox madyshevListBox;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonGetSelected;
        private System.Windows.Forms.Button buttonSetSelected;
        private System.Windows.Forms.TextBox textBoxSelectedItem;
        private MadyshevVisualComponents.MadyshevTextBox madyshevTextBox;
        private System.Windows.Forms.Button buttonEnter;
        private MadyshevVisualComponents.MadyshevDataGridView madyshevDataGridView;
        private System.Windows.Forms.Button buttonClearGrid;
        private System.Windows.Forms.Button buttonGriSelectedObjectGrid;
        private System.Windows.Forms.Button buttonSetSelectedIndexGrid;
        private System.Windows.Forms.Button buttonGetSelectedIndexGrid;
        private System.Windows.Forms.NumericUpDown numericUpDownSelectedIndexGrid;
        private System.Windows.Forms.Button buttonDoucmentWithTable;
        private System.Windows.Forms.Button buttonCreateDocWithCustomTable;
        private System.Windows.Forms.Button buttonCreateDocHistogram;
    }
}

