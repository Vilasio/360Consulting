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

namespace _360Consulting.Parkgarage.GUI
{
    public partial class InitiliazeForm : Form
    {
        public Garage garage = null;
        private int floor = 0;
        private int spotPerFloor = 0;

        public InitiliazeForm()
        {
            InitializeComponent();
        }

        public InitiliazeForm(Garage garage)
        {
            InitializeComponent();
            this.garage = garage;
        }

        private void InitiliazeForm_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            bool result = true;

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
            if (ValidateInput())
            {
                this.garage = new Garage(this.floor, this.spotPerFloor);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
