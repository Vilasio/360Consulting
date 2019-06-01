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
            this.listViewGarage = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFloors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSpots = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.groupBoxGarage = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpots)).BeginInit();
            this.groupBoxGarage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFloors
            // 
            this.labelFloors.AutoSize = true;
            this.labelFloors.Location = new System.Drawing.Point(11, 63);
            this.labelFloors.Name = "labelFloors";
            this.labelFloors.Size = new System.Drawing.Size(41, 13);
            this.labelFloors.TabIndex = 0;
            this.labelFloors.Text = "Etagen";
            // 
            // labelSpots
            // 
            this.labelSpots.AutoSize = true;
            this.labelSpots.Location = new System.Drawing.Point(11, 98);
            this.labelSpots.Name = "labelSpots";
            this.labelSpots.Size = new System.Drawing.Size(57, 13);
            this.labelSpots.TabIndex = 1;
            this.labelSpots.Text = "Parkplätze";
            // 
            // numericUpDownFloors
            // 
            this.numericUpDownFloors.Location = new System.Drawing.Point(89, 61);
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
            this.numericUpDownSpots.Location = new System.Drawing.Point(89, 96);
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
            this.buttonOk.Location = new System.Drawing.Point(15, 177);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(161, 177);
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
            this.labelStatus.Location = new System.Drawing.Point(12, 158);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(45, 16);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status";
            this.labelStatus.Visible = false;
            // 
            // listViewGarage
            // 
            this.listViewGarage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderFloors,
            this.columnHeaderSpots});
            this.listViewGarage.FullRowSelect = true;
            this.listViewGarage.GridLines = true;
            this.listViewGarage.Location = new System.Drawing.Point(295, 12);
            this.listViewGarage.Name = "listViewGarage";
            this.listViewGarage.Size = new System.Drawing.Size(275, 225);
            this.listViewGarage.TabIndex = 7;
            this.listViewGarage.UseCompatibleStateImageBehavior = false;
            this.listViewGarage.View = System.Windows.Forms.View.Details;
            this.listViewGarage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewGarage_MouseClick);
            this.listViewGarage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewGarage_MouseDoubleClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 150;
            // 
            // columnHeaderFloors
            // 
            this.columnHeaderFloors.Text = "Etagen";
            this.columnHeaderFloors.Width = 50;
            // 
            // columnHeaderSpots
            // 
            this.columnHeaderSpots.Text = "Plätze";
            this.columnHeaderSpots.Width = 50;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(14, 35);
            this.textBoxName.MaxLength = 245;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 8;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "Name";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(495, 248);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 10;
            this.button.Text = "Beenden";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // groupBoxGarage
            // 
            this.groupBoxGarage.Controls.Add(this.numericUpDownFloors);
            this.groupBoxGarage.Controls.Add(this.labelFloors);
            this.groupBoxGarage.Controls.Add(this.labelName);
            this.groupBoxGarage.Controls.Add(this.labelSpots);
            this.groupBoxGarage.Controls.Add(this.textBoxName);
            this.groupBoxGarage.Controls.Add(this.numericUpDownSpots);
            this.groupBoxGarage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGarage.Name = "groupBoxGarage";
            this.groupBoxGarage.Size = new System.Drawing.Size(224, 138);
            this.groupBoxGarage.TabIndex = 11;
            this.groupBoxGarage.TabStop = false;
            this.groupBoxGarage.Text = "Neue Garage";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(15, 248);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "Löschen";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // InitiliazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 283);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.groupBoxGarage);
            this.Controls.Add(this.button);
            this.Controls.Add(this.listViewGarage);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "InitiliazeForm";
            this.ShowIcon = false;
            this.Text = "GaragenApp";
            this.Load += new System.EventHandler(this.InitiliazeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpots)).EndInit();
            this.groupBoxGarage.ResumeLayout(false);
            this.groupBoxGarage.PerformLayout();
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
        private System.Windows.Forms.ListView listViewGarage;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderFloors;
        private System.Windows.Forms.ColumnHeader columnHeaderSpots;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.GroupBox groupBoxGarage;
        private System.Windows.Forms.Button buttonDelete;
    }
}