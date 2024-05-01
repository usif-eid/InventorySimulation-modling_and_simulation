namespace MultiQueueSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.testcase1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.ShortageQuantityAverage = new System.Windows.Forms.TextBox();
            this.EndingInventoryAverage = new System.Windows.Forms.TextBox();
            this.TotalCos = new System.Windows.Forms.Label();
            this.TotalSalesProfi = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1094, 571);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.testcase1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(1086, 545);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // testcase1
            // 
            this.testcase1.Location = new System.Drawing.Point(47, 23);
            this.testcase1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.testcase1.Name = "testcase1";
            this.testcase1.Size = new System.Drawing.Size(80, 19);
            this.testcase1.TabIndex = 1;
            this.testcase1.Text = "show";
            this.testcase1.UseVisualStyleBackColor = true;
            this.testcase1.Click += new System.EventHandler(this.testcase1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1047, 495);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.ShortageQuantityAverage);
            this.tabPage2.Controls.Add(this.EndingInventoryAverage);
            this.tabPage2.Controls.Add(this.TotalCos);
            this.tabPage2.Controls.Add(this.TotalSalesProfi);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(816, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(47, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 19);
            this.button1.TabIndex = 14;
            this.button1.Text = "show performance metrices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShortageQuantityAverage
            // 
            this.ShortageQuantityAverage.Location = new System.Drawing.Point(156, 47);
            this.ShortageQuantityAverage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShortageQuantityAverage.Name = "ShortageQuantityAverage";
            this.ShortageQuantityAverage.Size = new System.Drawing.Size(76, 20);
            this.ShortageQuantityAverage.TabIndex = 5;
            // 
            // EndingInventoryAverage
            // 
            this.EndingInventoryAverage.Location = new System.Drawing.Point(156, 15);
            this.EndingInventoryAverage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EndingInventoryAverage.Name = "EndingInventoryAverage";
            this.EndingInventoryAverage.Size = new System.Drawing.Size(76, 20);
            this.EndingInventoryAverage.TabIndex = 4;
            // 
            // TotalCos
            // 
            this.TotalCos.AutoSize = true;
            this.TotalCos.Location = new System.Drawing.Point(16, 50);
            this.TotalCos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalCos.Name = "TotalCos";
            this.TotalCos.Size = new System.Drawing.Size(135, 13);
            this.TotalCos.TabIndex = 2;
            this.TotalCos.Text = "Shortage Quantity Average";
            // 
            // TotalSalesProfi
            // 
            this.TotalSalesProfi.AutoSize = true;
            this.TotalSalesProfi.Location = new System.Drawing.Point(16, 17);
            this.TotalSalesProfi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalSalesProfi.Name = "TotalSalesProfi";
            this.TotalSalesProfi.Size = new System.Drawing.Size(130, 13);
            this.TotalSalesProfi.TabIndex = 1;
            this.TotalSalesProfi.Text = "Ending Inventory Average";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 582);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button testcase1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ShortageQuantityAverage;
        private System.Windows.Forms.TextBox EndingInventoryAverage;
        private System.Windows.Forms.Label TotalCos;
        private System.Windows.Forms.Label TotalSalesProfi;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}