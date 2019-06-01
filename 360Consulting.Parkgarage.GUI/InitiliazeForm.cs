using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _360Consulting.Parkgarage.Data;
using Npgsql;

namespace _360Consulting.Parkgarage.GUI
{
    public partial class InitiliazeForm : Form
    {
        public Garage garage = null;
        public List<Garage> garages { get; set; }
        private String name = String.Empty;
        private int floor = 0;
        private int spotPerFloor = 0;
        private NpgsqlConnection connection = null;

        public InitiliazeForm()
        {
            InitializeComponent();
        }

        public InitiliazeForm(Garage garage)
        {
            InitializeComponent();
            this.garage = garage;
        }

        public InitiliazeForm(NpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        public InitiliazeForm(Garage garage, NpgsqlConnection connection)
        {
            InitializeComponent();
            this.garage = garage;
            this.connection = connection;
        }

        private void InitiliazeForm_Load(object sender, EventArgs e)
        {
            this.garages = Garage.GetAllGarages(this.connection);
            FillListViewGarage();
        }

        private void FillListViewGarage()
        {
            ListViewItem item = null;
            this.listViewGarage.Items.Clear();
            foreach (Garage garage in this.garages)
            {
                item = new ListViewItem();
                item.Text = garage.Name;
                item.SubItems.Add(garage.Floor.ToString());
                item.SubItems.Add((garage.Floor.Value * garage.SpotPerFloor.Value).ToString());
                item.Tag = garage;
                this.listViewGarage.Items.Add(item);
            }
        }

        private bool ValidateInput()
        {
            bool result = true;

            if (this.textBoxName.Text != "")
            {
                this.name = this.textBoxName.Text;
            }
            else
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = "Die Garage muss einen Namen haben!";
                SystemSounds.Asterisk.Play();
                return false;
            }

            if (this.numericUpDownFloors.Value != 0)
            {
                this.floor = (int)this.numericUpDownFloors.Value;
            }
            else
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = "Die Garage muss mindestens eine Etage haben!";
                SystemSounds.Asterisk.Play();
                return false;
            }

            if (this.numericUpDownSpots.Value != 0)
            {
                this.spotPerFloor = (int)this.numericUpDownSpots.Value;
            }
            else
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = "Die Garage muss mindestens einen Parkplatz haben!";
                SystemSounds.Asterisk.Play();
                return false;
            }

            return result;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.garage != null)
            {
                this.garage.Floors = Floor.GetAllFloorsWithSpots(this.connection, garage);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (ValidateInput())
                {
                    this.garage = Garage.CreateGarage(this.connection, this.floor, this.spotPerFloor, this.name);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            FillListViewGarage();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.garage = null;
            this.textBoxName.Enabled = true;
            this.numericUpDownFloors.Enabled = true;
            this.numericUpDownSpots.Enabled = true;
            this.groupBoxGarage.Text = $"Neue Garage";
        }

        private void listViewGarage_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listViewGarage.GetItemAt(e.X, e.Y);
            this.garage = (Garage)item.Tag;
            if (this.garage.GarageId.HasValue)
            {
                this.textBoxName.Enabled = false;
                this.numericUpDownFloors.Enabled = false;
                this.numericUpDownSpots.Enabled = false;
                this.groupBoxGarage.Text = $"Garage {this.garage.Name} öffnen";
            }
            else
            {
                this.textBoxName.Enabled = true;
                this.numericUpDownFloors.Enabled = true;
                this.numericUpDownSpots.Enabled = true;
                this.groupBoxGarage.Text = $"Neue Garage";
            }
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
