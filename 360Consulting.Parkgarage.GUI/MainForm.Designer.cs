namespace _360Consulting.Parkgarage.GUI
{
    partial class MainForm
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
            this.splitContainerGarage = new System.Windows.Forms.SplitContainer();
            this.splitContainerwasweißich = new System.Windows.Forms.SplitContainer();
            this.listViewFloor = new System.Windows.Forms.ListView();
            this.columnFloor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.groupBoxVehicle = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxMotorcycle = new System.Windows.Forms.CheckBox();
            this.checkBoxCar = new System.Windows.Forms.CheckBox();
            this.textBoxNumberPlate = new System.Windows.Forms.TextBox();
            this.buttonDriveIn = new System.Windows.Forms.Button();
            this.buttonDriveOut = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.listViewSpots = new System.Windows.Forms.ListView();
            this.ColumnSpotNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumberPlate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGarage)).BeginInit();
            this.splitContainerGarage.Panel1.SuspendLayout();
            this.splitContainerGarage.Panel2.SuspendLayout();
            this.splitContainerGarage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerwasweißich)).BeginInit();
            this.splitContainerwasweißich.Panel1.SuspendLayout();
            this.splitContainerwasweißich.Panel2.SuspendLayout();
            this.splitContainerwasweißich.SuspendLayout();
            this.groupBoxVehicle.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerGarage
            // 
            this.splitContainerGarage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGarage.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGarage.Name = "splitContainerGarage";
            // 
            // splitContainerGarage.Panel1
            // 
            this.splitContainerGarage.Panel1.Controls.Add(this.splitContainerwasweißich);
            // 
            // splitContainerGarage.Panel2
            // 
            this.splitContainerGarage.Panel2.Controls.Add(this.listViewSpots);
            this.splitContainerGarage.Size = new System.Drawing.Size(800, 450);
            this.splitContainerGarage.SplitterDistance = 266;
            this.splitContainerGarage.TabIndex = 0;
            // 
            // splitContainerwasweißich
            // 
            this.splitContainerwasweißich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerwasweißich.Location = new System.Drawing.Point(0, 0);
            this.splitContainerwasweißich.Name = "splitContainerwasweißich";
            this.splitContainerwasweißich.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerwasweißich.Panel1
            // 
            this.splitContainerwasweißich.Panel1.Controls.Add(this.listViewFloor);
            // 
            // splitContainerwasweißich.Panel2
            // 
            this.splitContainerwasweißich.Panel2.Controls.Add(this.buttonSearch);
            this.splitContainerwasweißich.Panel2.Controls.Add(this.textBoxSearch);
            this.splitContainerwasweißich.Panel2.Controls.Add(this.groupBoxVehicle);
            this.splitContainerwasweißich.Size = new System.Drawing.Size(266, 450);
            this.splitContainerwasweißich.SplitterDistance = 221;
            this.splitContainerwasweißich.TabIndex = 0;
            // 
            // listViewFloor
            // 
            this.listViewFloor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFloor});
            this.listViewFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFloor.FullRowSelect = true;
            this.listViewFloor.GridLines = true;
            this.listViewFloor.Location = new System.Drawing.Point(0, 0);
            this.listViewFloor.Name = "listViewFloor";
            this.listViewFloor.Size = new System.Drawing.Size(266, 221);
            this.listViewFloor.TabIndex = 1;
            this.listViewFloor.UseCompatibleStateImageBehavior = false;
            this.listViewFloor.View = System.Windows.Forms.View.Details;
            this.listViewFloor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewFloor_MouseClick);
            // 
            // columnFloor
            // 
            this.columnFloor.Text = "Etage";
            this.columnFloor.Width = 150;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(165, 177);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Suchen";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(9, 179);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(150, 20);
            this.textBoxSearch.TabIndex = 7;
            // 
            // groupBoxVehicle
            // 
            this.groupBoxVehicle.Controls.Add(this.buttonCancel);
            this.groupBoxVehicle.Controls.Add(this.labelStatus);
            this.groupBoxVehicle.Controls.Add(this.checkBoxMotorcycle);
            this.groupBoxVehicle.Controls.Add(this.checkBoxCar);
            this.groupBoxVehicle.Controls.Add(this.textBoxNumberPlate);
            this.groupBoxVehicle.Controls.Add(this.buttonDriveIn);
            this.groupBoxVehicle.Controls.Add(this.buttonDriveOut);
            this.groupBoxVehicle.Controls.Add(this.buttonRandom);
            this.groupBoxVehicle.Location = new System.Drawing.Point(3, 3);
            this.groupBoxVehicle.Name = "groupBoxVehicle";
            this.groupBoxVehicle.Size = new System.Drawing.Size(260, 145);
            this.groupBoxVehicle.TabIndex = 4;
            this.groupBoxVehicle.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 100);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(36, 17);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status";
            this.labelStatus.UseCompatibleTextRendering = true;
            this.labelStatus.Visible = false;
            // 
            // checkBoxMotorcycle
            // 
            this.checkBoxMotorcycle.AutoSize = true;
            this.checkBoxMotorcycle.Location = new System.Drawing.Point(133, 69);
            this.checkBoxMotorcycle.Name = "checkBoxMotorcycle";
            this.checkBoxMotorcycle.Size = new System.Drawing.Size(68, 17);
            this.checkBoxMotorcycle.TabIndex = 5;
            this.checkBoxMotorcycle.Text = "Motorrad";
            this.checkBoxMotorcycle.UseVisualStyleBackColor = true;
            this.checkBoxMotorcycle.CheckedChanged += new System.EventHandler(this.checkBoxMotorcycle_CheckedChanged);
            // 
            // checkBoxCar
            // 
            this.checkBoxCar.AutoSize = true;
            this.checkBoxCar.Checked = true;
            this.checkBoxCar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCar.Location = new System.Drawing.Point(9, 69);
            this.checkBoxCar.Name = "checkBoxCar";
            this.checkBoxCar.Size = new System.Drawing.Size(48, 17);
            this.checkBoxCar.TabIndex = 4;
            this.checkBoxCar.Text = "Auto";
            this.checkBoxCar.UseVisualStyleBackColor = true;
            this.checkBoxCar.CheckedChanged += new System.EventHandler(this.checkBoxCar_CheckedChanged);
            // 
            // textBoxNumberPlate
            // 
            this.textBoxNumberPlate.Location = new System.Drawing.Point(6, 19);
            this.textBoxNumberPlate.Name = "textBoxNumberPlate";
            this.textBoxNumberPlate.Size = new System.Drawing.Size(150, 20);
            this.textBoxNumberPlate.TabIndex = 2;
            // 
            // buttonDriveIn
            // 
            this.buttonDriveIn.Location = new System.Drawing.Point(6, 116);
            this.buttonDriveIn.Name = "buttonDriveIn";
            this.buttonDriveIn.Size = new System.Drawing.Size(75, 23);
            this.buttonDriveIn.TabIndex = 0;
            this.buttonDriveIn.Text = "Einfahren";
            this.buttonDriveIn.UseVisualStyleBackColor = true;
            this.buttonDriveIn.Click += new System.EventHandler(this.buttonDriveIn_Click);
            // 
            // buttonDriveOut
            // 
            this.buttonDriveOut.Location = new System.Drawing.Point(179, 116);
            this.buttonDriveOut.Name = "buttonDriveOut";
            this.buttonDriveOut.Size = new System.Drawing.Size(75, 23);
            this.buttonDriveOut.TabIndex = 1;
            this.buttonDriveOut.Text = "Ausfahren";
            this.buttonDriveOut.UseVisualStyleBackColor = true;
            this.buttonDriveOut.Click += new System.EventHandler(this.buttonDriveOut_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Image = global::_360Consulting.Parkgarage.GUI.Properties.Resources.icons8_dice_26;
            this.buttonRandom.Location = new System.Drawing.Point(162, 8);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(40, 40);
            this.buttonRandom.TabIndex = 3;
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // listViewSpots
            // 
            this.listViewSpots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnSpotNr,
            this.columnNumberPlate,
            this.columnKind});
            this.listViewSpots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSpots.FullRowSelect = true;
            this.listViewSpots.GridLines = true;
            this.listViewSpots.Location = new System.Drawing.Point(0, 0);
            this.listViewSpots.Name = "listViewSpots";
            this.listViewSpots.Size = new System.Drawing.Size(530, 450);
            this.listViewSpots.TabIndex = 0;
            this.listViewSpots.UseCompatibleStateImageBehavior = false;
            this.listViewSpots.View = System.Windows.Forms.View.Details;
            this.listViewSpots.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSpots_MouseClick);
            // 
            // ColumnSpotNr
            // 
            this.ColumnSpotNr.Text = "Platz";
            this.ColumnSpotNr.Width = 50;
            // 
            // columnNumberPlate
            // 
            this.columnNumberPlate.Text = "Kennzeichen";
            this.columnNumberPlate.Width = 150;
            // 
            // columnKind
            // 
            this.columnKind.Text = "Fahrzeugart";
            this.columnKind.Width = 150;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(87, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Abbrechen/Neu";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerGarage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainerGarage.Panel1.ResumeLayout(false);
            this.splitContainerGarage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGarage)).EndInit();
            this.splitContainerGarage.ResumeLayout(false);
            this.splitContainerwasweißich.Panel1.ResumeLayout(false);
            this.splitContainerwasweißich.Panel2.ResumeLayout(false);
            this.splitContainerwasweißich.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerwasweißich)).EndInit();
            this.splitContainerwasweißich.ResumeLayout(false);
            this.groupBoxVehicle.ResumeLayout(false);
            this.groupBoxVehicle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerGarage;
        private System.Windows.Forms.SplitContainer splitContainerwasweißich;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.TextBox textBoxNumberPlate;
        private System.Windows.Forms.Button buttonDriveOut;
        private System.Windows.Forms.Button buttonDriveIn;
        private System.Windows.Forms.ListView listViewSpots;
        private System.Windows.Forms.ColumnHeader ColumnSpotNr;
        private System.Windows.Forms.ColumnHeader columnNumberPlate;
        private System.Windows.Forms.ColumnHeader columnKind;
        private System.Windows.Forms.ListView listViewFloor;
        private System.Windows.Forms.ColumnHeader columnFloor;
        private System.Windows.Forms.GroupBox groupBoxVehicle;
        private System.Windows.Forms.CheckBox checkBoxMotorcycle;
        private System.Windows.Forms.CheckBox checkBoxCar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonCancel;
    }
}

