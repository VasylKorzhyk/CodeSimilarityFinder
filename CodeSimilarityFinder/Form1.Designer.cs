namespace CodeSimilarityFinder
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.codeExample_txt = new System.Windows.Forms.TextBox();
            this.result_grid = new System.Windows.Forms.DataGridView();
            this.find_btn = new System.Windows.Forms.Button();
            this.projects_cb = new System.Windows.Forms.ComboBox();
            this.components_cb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.result_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // codeExample_txt
            // 
            this.codeExample_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeExample_txt.Location = new System.Drawing.Point(0, 0);
            this.codeExample_txt.Multiline = true;
            this.codeExample_txt.Name = "codeExample_txt";
            this.codeExample_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeExample_txt.Size = new System.Drawing.Size(843, 288);
            this.codeExample_txt.TabIndex = 0;
            // 
            // result_grid
            // 
            this.result_grid.AllowUserToAddRows = false;
            this.result_grid.AllowUserToDeleteRows = false;
            this.result_grid.AllowUserToResizeRows = false;
            this.result_grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.result_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result_grid.Location = new System.Drawing.Point(0, 345);
            this.result_grid.MultiSelect = false;
            this.result_grid.Name = "result_grid";
            this.result_grid.ReadOnly = true;
            this.result_grid.RowHeadersVisible = false;
            this.result_grid.RowTemplate.Height = 24;
            this.result_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.result_grid.Size = new System.Drawing.Size(843, 350);
            this.result_grid.TabIndex = 1;
            this.result_grid.TabStop = false;
            // 
            // find_btn
            // 
            this.find_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.find_btn.Location = new System.Drawing.Point(570, 289);
            this.find_btn.Name = "find_btn";
            this.find_btn.Size = new System.Drawing.Size(273, 55);
            this.find_btn.TabIndex = 2;
            this.find_btn.Text = "Search duplicates";
            this.find_btn.UseVisualStyleBackColor = true;
            this.find_btn.Click += new System.EventHandler(this.find_btn_Click);
            // 
            // projects_cb
            // 
            this.projects_cb.AllowDrop = true;
            this.projects_cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projects_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.projects_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.projects_cb.DropDownHeight = 110;
            this.projects_cb.IntegralHeight = false;
            this.projects_cb.ItemHeight = 16;
            this.projects_cb.Location = new System.Drawing.Point(0, 320);
            this.projects_cb.Name = "projects_cb";
            this.projects_cb.Size = new System.Drawing.Size(569, 24);
            this.projects_cb.TabIndex = 3;
            // 
            // components_cb
            // 
            this.components_cb.AllowDrop = true;
            this.components_cb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.components_cb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.components_cb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.components_cb.DropDownHeight = 110;
            this.components_cb.IntegralHeight = false;
            this.components_cb.ItemHeight = 16;
            this.components_cb.Location = new System.Drawing.Point(0, 289);
            this.components_cb.Name = "components_cb";
            this.components_cb.Size = new System.Drawing.Size(570, 24);
            this.components_cb.TabIndex = 4;
            this.components_cb.SelectedIndexChanged += new System.EventHandler(this.solutions_cb_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 695);
            this.Controls.Add(this.components_cb);
            this.Controls.Add(this.projects_cb);
            this.Controls.Add(this.find_btn);
            this.Controls.Add(this.result_grid);
            this.Controls.Add(this.codeExample_txt);
            this.Name = "Form1";
            this.Text = "Code Similarity Finder";
            ((System.ComponentModel.ISupportInitialize)(this.result_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codeExample_txt;
        private System.Windows.Forms.DataGridView result_grid;
        private System.Windows.Forms.Button find_btn;
        private System.Windows.Forms.ComboBox projects_cb;
        private System.Windows.Forms.ComboBox components_cb;
    }
}

