
namespace CSM_V2
{
    partial class Administrator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrator));
            this.MasterData = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.user_btn = new System.Windows.Forms.Button();
            this.scrap_btn = new System.Windows.Forms.Button();
            this.csm_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Prev_btn = new System.Windows.Forms.Button();
            this.Next_btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.MasterData)).BeginInit();
            this.SuspendLayout();
            // 
            // MasterData
            // 
            this.MasterData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MasterData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MasterData.Location = new System.Drawing.Point(21, 54);
            this.MasterData.Name = "MasterData";
            this.MasterData.RowHeadersWidth = 51;
            this.MasterData.RowTemplate.Height = 24;
            this.MasterData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MasterData.Size = new System.Drawing.Size(938, 426);
            this.MasterData.TabIndex = 19;
            this.MasterData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.MasterData_CellValueChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(806, 525);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(153, 39);
            this.button6.TabIndex = 18;
            this.button6.Text = "Close";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // user_btn
            // 
            this.user_btn.Location = new System.Drawing.Point(394, 525);
            this.user_btn.Margin = new System.Windows.Forms.Padding(4);
            this.user_btn.Name = "user_btn";
            this.user_btn.Size = new System.Drawing.Size(153, 39);
            this.user_btn.TabIndex = 17;
            this.user_btn.Text = "Users";
            this.user_btn.UseVisualStyleBackColor = true;
            this.user_btn.Click += new System.EventHandler(this.user_btn_Click);
            this.user_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // scrap_btn
            // 
            this.scrap_btn.Location = new System.Drawing.Point(202, 525);
            this.scrap_btn.Margin = new System.Windows.Forms.Padding(4);
            this.scrap_btn.Name = "scrap_btn";
            this.scrap_btn.Size = new System.Drawing.Size(153, 39);
            this.scrap_btn.TabIndex = 16;
            this.scrap_btn.Text = "Scrap";
            this.scrap_btn.UseVisualStyleBackColor = true;
            this.scrap_btn.Click += new System.EventHandler(this.scrap_btn_Click);
            this.scrap_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // csm_btn
            // 
            this.csm_btn.Location = new System.Drawing.Point(21, 525);
            this.csm_btn.Margin = new System.Windows.Forms.Padding(4);
            this.csm_btn.Name = "csm_btn";
            this.csm_btn.Size = new System.Drawing.Size(153, 39);
            this.csm_btn.TabIndex = 15;
            this.csm_btn.Text = "Warranty CSM";
            this.csm_btn.UseVisualStyleBackColor = true;
            this.csm_btn.Click += new System.EventHandler(this.csm_btn_Click);
            this.csm_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 39);
            this.button2.TabIndex = 14;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 8);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // Prev_btn
            // 
            this.Prev_btn.Location = new System.Drawing.Point(21, 486);
            this.Prev_btn.Name = "Prev_btn";
            this.Prev_btn.Size = new System.Drawing.Size(75, 23);
            this.Prev_btn.TabIndex = 22;
            this.Prev_btn.Text = "<<";
            this.Prev_btn.UseVisualStyleBackColor = true;
            this.Prev_btn.Click += new System.EventHandler(this.button7_Click);
            this.Prev_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // Next_btn
            // 
            this.Next_btn.Location = new System.Drawing.Point(884, 486);
            this.Next_btn.Name = "Next_btn";
            this.Next_btn.Size = new System.Drawing.Size(75, 23);
            this.Next_btn.TabIndex = 23;
            this.Next_btn.Text = ">>";
            this.Next_btn.UseVisualStyleBackColor = true;
            this.Next_btn.Click += new System.EventHandler(this.Next_btn_Click);
            this.Next_btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MasterData_KeyDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 579);
            this.Controls.Add(this.Next_btn);
            this.Controls.Add(this.Prev_btn);
            this.Controls.Add(this.MasterData);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.user_btn);
            this.Controls.Add(this.scrap_btn);
            this.Controls.Add(this.csm_btn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.Load += new System.EventHandler(this.Administrator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Administrator_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MasterData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView MasterData;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button user_btn;
        private System.Windows.Forms.Button scrap_btn;
        private System.Windows.Forms.Button csm_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Prev_btn;
        private System.Windows.Forms.Button Next_btn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}