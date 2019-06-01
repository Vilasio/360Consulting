using _360Consulting.Parkgarage.Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _360Consulting.Parkgarage.GUI
{
    public partial class SearchForm : Form
    {
        private Search search = null;
        private NpgsqlConnection connection;

        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(Search search)
        {
            this.search = search;
            InitializeComponent();
        }

        public SearchForm(Search search, NpgsqlConnection connection)
        {
            this.search = search;
            this.connection = connection;
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            if (this.search.numberplate != String.Empty)
            {
                this.textBoxNumberplate.Text = this.search.numberplate;
                this.search.SearchVehicle();
                if (this.search.spot != null) this.buttonDriveOut.Visible = true;
                FillForm();
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (this.textBoxNumberplate.Text != null)
            {
                this.search.Reset();
                this.search.numberplate = this.textBoxNumberplate.Text;
                this.search.SearchVehicle();
                if (this.search.spot != null) this.buttonDriveOut.Visible = true;
                FillForm();
            }
        }

        private void buttonDriveOut_Click(object sender, EventArgs e)
        {
            if (this.search.spot != null)
            {
                this.search.spot.DriveOut();
                this.labelStatus.Visible = true;
                this.labelStatus.Text = $"Das Fahrzeug {this.search.numberplate} ist ausgefahren";
                this.search.Reset();
                this.textBoxNumberplate.Text = String.Empty;
                if (this.search.spot != null) this.buttonDriveOut.Visible = false;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillForm()
        {
            if (this.search.SpotId != null)
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = $"Das Fahrzeug steht in Garage {this.search.GarageName}.\nEtage {this.search.FloorNr.ToString()} | Parkplatz {this.search.SpotNr}";
            }
            else
            {
                this.labelStatus.Visible = true;
                this.labelStatus.Text = "Dieses Fahrzeug ist nirgends geparkt";
            }
        }

        private void ClearForm()
        {
            this.labelStatus.Visible = false;
        }
    }
}
