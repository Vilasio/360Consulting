using _360Consulting.Parkgarage.Data;
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

namespace _360Consulting.Parkgarage.GUI
{
    public partial class MainForm : Form
    {
        private Garage garage = null;
        private Spot spot = null;
        private Floor selectedFloor= null;

        private enum Kind
        {
            Auto,
            Motorad
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Garage garage)
        {
            InitializeComponent();
            this.garage = garage;
           
        }

        private void FillListViewFloor()
        {
            this.listViewFloor.Items.Clear();
            ListViewItem item = null;
            
            foreach (Floor floor in this.garage.Floors)
            {
                item = new ListViewItem();
                item.Text = $"Etage {floor.FloorNumber}";
                item.Tag = floor;
                this.listViewFloor.Items.Add(item);

            }
        }

        private void FillListViewSpots(List<Spot> spots)
        {
            this.listViewSpots.Items.Clear();

            ListViewItem item = null;

            foreach (Spot spot in spots)
            {
                item = new ListViewItem();
                item.Text = spot.SpotNr.ToString();
                if (spot.Vehicle != null)
                {
                    item.SubItems.Add(spot.Vehicle.NumberPlate);
                    item.SubItems.Add(spot.Vehicle.Kind);
                }
                item.Tag = spot;
                this.listViewSpots.Items.Add(item);
            }
        }

        /*
        private bool ValidateVehicle()
        {
            if (this.garage.AllreadyIn(this.textBoxNumberPlate.Text))
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = "Kennzeichen existiert bereits im Parkhaus";
                SystemSounds.Asterisk.Play();
                return false;
            }
            else
            {
                bool result = true;
                Vehicle vehicle = new Vehicle();
                if (this.spot == null)
                {
                    this.spot = garage.GetFirstFreeSpot();
                    if (spot == null)
                    {
                        this.labelStatus.Visible = true;
                        this.labelStatus.Text = "Die Garage ist voll";
                        SystemSounds.Asterisk.Play();
                        return false;
                    }
                    vehicle.Spot = this.spot;
                    this.spot.Vehicle = vehicle;

                }

                if (this.textBoxNumberPlate.Text != "")
                {
                    this.spot.Vehicle.NumberPlate = this.textBoxNumberPlate.Text;
                }
                else
                {
                    this.labelStatus.Visible = true;
                    this.labelStatus.Text = "Kein Kennzeichen angegeben";
                    SystemSounds.Asterisk.Play();
                    return false;
                }
                if (this.checkBoxCar.Checked)
                {
                    this.spot.Vehicle.Kind = "Auto";

                }
                else
                {
                    this.spot.Vehicle.Kind = "Motorad";
                }
                return result;
            }
           
        }
        */

        private void listViewFloor_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listViewFloor.GetItemAt(e.X, e.Y);
            this.selectedFloor = (Floor)item.Tag;
            FillListViewSpots(this.selectedFloor.Spots);
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rndnr = random.Next(100, 999);
            
            string result = String.Empty;

            result += (char)('A' + random.Next(0, 26));
            result += (char)('A' + random.Next(0, 26));
            result += $"-{rndnr.ToString()}-";
            result += (char)('A' + random.Next(0, 26));
            result += (char)('A' + random.Next(0, 26));

            this.textBoxNumberPlate.Text = result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.comboBoxKind.DataSource = Enum.GetValues(typeof(Kind));
            FillListViewFloor();
            this.selectedFloor = this.garage.Floors.ElementAt(0);
        }

        private void checkBoxCar_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxCar.Checked)
            {
                if (this.checkBoxMotorcycle.Checked)
                {
                    this.checkBoxMotorcycle.Checked = false;
                }
            }
        }

        private void checkBoxMotorcycle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxMotorcycle.Checked)
            {
                if (this.checkBoxCar.Checked)
                {
                    this.checkBoxCar.Checked = false;
                }
            }
        }

        private void buttonDriveIn_Click(object sender, EventArgs e)
        {
           /* if (ValidateVehicle())
            {
                FillListViewSpots(this.selectedFloor.Spots);
                this.spot = null;
            }*/
        }

   

        private void buttonSearch_Click(object sender, EventArgs e)
        {
           /* Spot spot = this.garage.Search(this.textBoxNumberPlate.Text);
            if (spot != null)
            {
                MessageBox.Show($"Gefunden\n" +
                    $"Das Fahrzeug steht in Etage {spot.Floor.FloorNumber} auf Platz {spot.SpotId}", "Gefunden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Leider nichts gefunden","Nix", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void buttonDriveOut_Click(object sender, EventArgs e)
        {
            if (this.spot != null)
            {
                this.spot.Vehicle = null;
                FillListViewSpots(this.spot.Floor.Spots);
                ClearVehicle();
            }
        }

        private void listViewSpots_MouseClick(object sender, MouseEventArgs e)
        {
            ClearVehicle();
            ListViewItem item = this.listViewSpots.GetItemAt(e.X, e.Y);
            this.spot = (Spot)item.Tag;
            FillVehicle();
        }

        public void FillVehicle()
        {
            if (this.spot.Vehicle != null)
            {
                this.textBoxNumberPlate.Text = this.spot.Vehicle.NumberPlate;
                this.checkBoxCar.Enabled = false;
                this.checkBoxMotorcycle.Enabled = false;
                this.buttonDriveOut.Enabled = true;
                this.buttonDriveIn.Enabled = false;
                if (this.spot.Vehicle.Kind == "Auto")
                {
                    this.checkBoxCar.Checked = true;
                    this.checkBoxMotorcycle.Checked = false;
                }
                else
                {
                    this.checkBoxCar.Checked = true;
                    this.checkBoxMotorcycle.Checked = false;
                }
            }
        }

        public void ClearVehicle()
        {

            this.spot = null;
            this.textBoxNumberPlate.Text = String.Empty;
            this.checkBoxCar.Checked = true;
            this.checkBoxMotorcycle.Checked = false;
            this.checkBoxCar.Enabled = true;
            this.checkBoxMotorcycle.Enabled = true;
            this.buttonDriveOut.Enabled = false;
            this.buttonDriveIn.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearVehicle();
        }
    }
}
