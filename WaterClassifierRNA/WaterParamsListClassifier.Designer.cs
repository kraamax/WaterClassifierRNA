namespace WaterClassifierRNA
{
    partial class WaterParamsListClassifier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgWaterParams = new System.Windows.Forms.DataGridView();
            this.dgOutputs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWaterParams
            // 
            this.dgWaterParams.AllowUserToAddRows = false;
            this.dgWaterParams.AllowUserToDeleteRows = false;
            this.dgWaterParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWaterParams.Location = new System.Drawing.Point(26, 36);
            this.dgWaterParams.Name = "dgWaterParams";
            this.dgWaterParams.RowHeadersWidth = 51;
            this.dgWaterParams.RowTemplate.Height = 24;
            this.dgWaterParams.Size = new System.Drawing.Size(776, 378);
            this.dgWaterParams.TabIndex = 2;
            this.dgWaterParams.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatos_CellContentClick);
            // 
            // dgOutputs
            // 
            this.dgOutputs.AllowUserToAddRows = false;
            this.dgOutputs.AllowUserToDeleteRows = false;
            this.dgOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOutputs.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgOutputs.Location = new System.Drawing.Point(808, 36);
            this.dgOutputs.Name = "dgOutputs";
            this.dgOutputs.RowHeadersWidth = 51;
            this.dgOutputs.RowTemplate.Height = 24;
            this.dgOutputs.Size = new System.Drawing.Size(228, 378);
            this.dgOutputs.TabIndex = 3;
            this.dgOutputs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // WaterParamsListClassifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 475);
            this.Controls.Add(this.dgOutputs);
            this.Controls.Add(this.dgWaterParams);
            this.Name = "WaterParamsListClassifier";
            this.Text = "WaterParamsListClassifier";
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOutputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWaterParams;
        private System.Windows.Forms.DataGridView dgOutputs;
    }
}