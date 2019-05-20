namespace _360Consulting.Parkgarage.GUI
{
    partial class InitiliazeForm
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
            this.labelFloors = new System.Windows.Forms.Label();
            this.labelSpots = new System.Windows.Forms.Label();
            this.numericUpDownFloors = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpots = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpots)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFloors
            // 
            this.labelFloors.AutoSize = true;
            this.labelFloors.Location = new System.Drawing.Point(12, 9);
            this.labelFloors.Name = "labelFloors";
            this.labelFloors.Size = new System.Drawing.Size(41, 13);
            this.labelFloors.TabIndex = 0;
            this.labelFloors.Text = "Etagen";
            // 
            // labelSpots
            // 
            this.labelSpots.AutoSize = true;
            this.labelSpots.Location = new System.Drawing.Point(12, 44);
            this.labelSpots.Name = "labelSpots";
            this.labelSpots.Size = new System.Drawing.Size(57, 13);
            this.labelSpots.TabIndex = 1;
            this.labelSpots.Text = "Parkplätze";
            // 
            // numericUpDownFloors
            // 
            this.numericUpDownFloors.Location = new System.Drawing.Point(90, 7);
            this.numericUpDownFloors.Name = "numericUpDownFloors";
            this.numericUpDownFloors.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownFloors.TabIndex = 2;
            this.numericUpDownFloors.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownSpots
            // 
            this.numericUpDownSpots.Location = new System.Drawing.Point(90, 42);
            this.numericUpDownSpots.Name = "numericUpDownSpots";
            this.numericUpDownSpots.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSpots.TabIndex = 3;
            this.numericUpDownSpots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(124, 110);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(218, 111);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Abbrechen";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(12, 90);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(45, 16);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status";
            this.labelStatus.Visible = false;
            // 
            // InitiliazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 154);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownSpots);
            this.Controls.Add(this.numericUpDownFloors);
            this.Controls.Add(this.labelSpots);
            this.Controls.Add(this.labelFloors);
            this.Name = "InitiliazeForm";
            this.Text = "InitiliazeForm";
            this.Load += new System.EventHandler(this.InitiliazeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFloors;
        private System.Windows.Forms.Label labelSpots;
        private System.Windows.Forms.NumericUpDown numericUpDownFloors;
        private System.Windows.Forms.NumericUpDown numericUpDownSpots;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStatus;
    }
}