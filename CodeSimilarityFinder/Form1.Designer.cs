using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CodeSimilarityFinder
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.codeExample_txt = new TextBox();
            this.result_grid = new DataGridView();
            this.find_btn = new Button();
            this.projects_cb = new ComboBox();
            this.components_cb = new ComboBox();
            ((ISupportInitialize)(this.result_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // codeExample_txt
            // 
            this.codeExample_txt.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.codeExample_txt.Location = new Point(0, 0);
            this.codeExample_txt.Multiline = true;
            this.codeExample_txt.Name = "codeExample_txt";
            this.codeExample_txt.ScrollBars = ScrollBars.Both;
            this.codeExample_txt.Size = new Size(843, 288);
            this.codeExample_txt.TabIndex = 0;
            // 
            // result_grid
            // 
            this.result_grid.AllowUserToAddRows = false;
            this.result_grid.AllowUserToDeleteRows = false;
            this.result_grid.AllowUserToResizeRows = false;
            this.result_grid.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.result_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_grid.Location = new Point(0, 345);
            this.result_grid.MultiSelect = false;
            this.result_grid.Name = "result_grid";
            this.result_grid.ReadOnly = true;
            this.result_grid.RowHeadersVisible = false;
            this.result_grid.RowTemplate.Height = 24;
            this.result_grid.ScrollBars = ScrollBars.Vertical;
            this.result_grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.result_grid.Size = new Size(843, 350);
            this.result_grid.TabIndex = 1;
            this.result_grid.TabStop = false;
            // 
            // find_btn
            // 
            this.find_btn.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.find_btn.Location = new Point(570, 289);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new Size(273, 55);
            this.find_btn.TabIndex = 2;
            this.find_btn.Text = "Search duplicates";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new EventHandler(this.find_btn_Click);
            // 
            // projects_cb
            // 
            this.projects_cb.AllowDrop = true;
            this.projects_cb.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.projects_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.projects_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.projects_cb.DropDownHeight = 110;
            this.projects_cb.IntegralHeight = false;
            this.projects_cb.ItemHeight = 16;
            this.projects_cb.Location = new Point(0, 320);
            this.projects_cb.Name = "projects_cb";
            this.projects_cb.Size = new Size(569, 24);
            this.projects_cb.TabIndex = 3;
            // 
            // components_cb
            // 
            this.components_cb.AllowDrop = true;
            this.components_cb.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.components_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.components_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.components_cb.DropDownHeight = 110;
            this.components_cb.IntegralHeight = false;
            this.components_cb.ItemHeight = 16;
            this.components_cb.Location = new Point(0, 289);
            this.components_cb.Name = "components_cb";
            this.components_cb.Size = new Size(570, 24);
            this.components_cb.TabIndex = 4;
            this.components_cb.SelectedIndexChanged += new EventHandler(this.solutions_cb_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(843, 695);
            this.Controls.Add(this.components_cb);
            this.Controls.Add(this.projects_cb);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.result_grid);
            this.Controls.Add(this.codeExample_txt);
            this.Name = "Form1";
            this.Text = "Code Similarity Finder";
            ((ISupportInitialize)(this.result_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox codeExample_txt;
        private DataGridView result_grid;
        private Button find_btn;
        private ComboBox projects_cb;
        private ComboBox components_cb;
    }
}

