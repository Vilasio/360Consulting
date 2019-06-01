namespace _360Consulting.Parkgarage.GUI
{
    partial class SearchForm
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
            this.labelNumberplate = new System.Windows.Forms.Label();
            this.textBoxNumberplate = new System.Windows.Forms.TextBox();
            this.buttonDriveOut = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNumberplate
            // 
            this.labelNumberplate.AutoSize = true;
            this.labelNumberplate.Location = new System.Drawing.Point(12, 9);
            this.labelNumberplate.Name = "labelNumberplate";
            this.labelNumberplate.Size = new System.Drawing.Size(69, 13);
            this.labelNumberplate.TabIndex = 0;
            this.labelNumberplate.Text = "Kennzeichen";
            // 
            // textBoxNumberplate
            // 
            this.textBoxNumberplate.Location = new System.Drawing.Point(15, 25);
            this.textBoxNumberplate.Name = "textBoxNumberplate";
            this.textBoxNumberplate.Size = new System.Drawing.Size(200, 20);
            this.textBoxNumberplate.TabIndex = 1;
            // 
            // buttonDriveOut
            // 
            this.buttonDriveOut.Location = new System.Drawing.Point(12, 82);
            this.buttonDriveOut.Name = "buttonDriveOut";
            this.buttonDriveOut.Size = new System.Drawing.Size(75, 50);
            this.buttonDriveOut.TabIndex = 2;
            this.buttonDriveOut.Text = "Fahrzeug ausfahren";
            this.buttonDriveOut.UseVisualStyleBackColor = true;
            this.buttonDriveOut.Visible = false;
            this.buttonDriveOut.Click += new System.EventHandler(this.buttonDriveOut_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(12, 48);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(45, 16);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Status";
            this.labelStatus.Visible = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(221, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Suchen";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(221, 109);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 5;
            this.buttonDone.Text = "Fertig";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 175);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonDriveOut);
            this.Controls.Add(this.textBoxNumberplate);
            this.Controls.Add(this.labelNumberplate);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumberplate;
        private System.Windows.Forms.TextBox textBoxNumberplate;
        private System.Windows.Forms.Button buttonDriveOut;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonDone;
    }
}