using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Examen 2 Programacion 3
// II Ciclo 2021
// Damian Cordero Fallas 117600022
// Ronald Blanco Navarro 117580543



namespace SimuladorBacterias
{
    static class Program
    {
        /// Punto de entrada principal para la aplicación.
        
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmPrincipal menuPrincipal = new frmPrincipal();  // apertura del form login
            menuPrincipal.FormClosed += MainForm_Closed;
            menuPrincipal.Show();
            Application.Run();
        }


        private static void MainForm_Closed(object sender, FormClosedEventArgs e)
        { // metodo que permite pasar entre forms sin que se cierre la aplicacion al cerrar el principal
            ((Form)sender).FormClosed -= MainForm_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += MainForm_Closed;
            }

            // Link de metodo: https://es.stackoverflow.com/questions/38427/c%C3%B3mo-cerrar-un-form-en-c-y-que-se-habra-otro
        }
    }
}
