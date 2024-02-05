using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorBacterias
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnNuevaSimulacion_Click(object sender, EventArgs e)
        {

           frmSimulador simulacion = new frmSimulador(); // paso a form principal
            simulacion.FormClosed += MainForm_Closed;
            simulacion.Show();
            this.Close();

        }


        private static void MainForm_Closed(object sender, FormClosedEventArgs e) // metodo para cambio de forms sin cerrar programa
        {
            ((Form)sender).FormClosed -= MainForm_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += MainForm_Closed;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
