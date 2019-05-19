using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _360Consulting.Parkgarage.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.AppSettings["Connection"]);

            try
            {
                connection.Open();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch(NpgsqlException dbEx)
            {
                MessageBox.Show($"Leider ist eine Datenbankfehler aufgetreten.\n{dbEx.Message}", "Datenbankfehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Leider ist ein algemeiner Fehler aufgetreten.\n{ex.Message}", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
