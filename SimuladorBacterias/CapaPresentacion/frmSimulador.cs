using SimuladorBacterias.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorBacterias
{
    public partial class frmSimulador : Form
    {
        // factores
        private static int temperatura = 0;
        private static int cantCO2 = 0;
        private static int cantO2 = 0;
        private static int humedad = 0;
        bool oxigenoModificado = false;
        bool dioxidoCarbonoModificado = false;

        Image backImage; //imagen de musgo 
        Image O2Image;
        Image CO2Image;

        public static int Temperatura { get => temperatura; set => temperatura = value; }
        public static int CantCO2 { get => cantCO2; set => cantCO2 = value; }
        public static int CantO2 { get => cantO2; set => cantO2 = value; }
        public static int Humedad { get => humedad; set => humedad = value; }

        public frmSimulador()
        {
            InitializeComponent();
        }

        private void frmSimulador_Load(object sender, EventArgs e)
        {
            pnlCentral.AllowDrop = true;
            pnlCentral.BackgroundImage = null;
            backImage = Image.FromFile("..\\CapaPresentacion\\Recursos\\musgo2.png");
            O2Image = Image.FromFile("..\\CapaPresentacion\\Recursos\\02.png");
            CO2Image = Image.FromFile("..\\CapaPresentacion\\Recursos\\C02.png");
            pnlCentral.BackColor = Color.FromArgb(51, 153, 255); // azul
            tmrGases.Start();
            oxigenoModificado = false;
            dioxidoCarbonoModificado = false;

        }


        private void pnlCentral_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pnlCentral_DragDrop(object sender, DragEventArgs e) // captacion de la bacteria en el contenedor
        {

            // insercion de bacteria en contenedor segun tipo
            // inicio de ciclo de vida de bacteria
            try
            {
                string nombreBacteria = e.Data.GetData(DataFormats.Text).ToString();

                switch (nombreBacteria)
                {
                    case "imgPsicrofila1":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Psicrofila", "imgPsicrofila1", e.X, e.Y, pnlCentral);//,
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    case "imgPsicrofila2":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Psicrofila", "imgPsicrofila2", e.X, e.Y, pnlCentral);//, 
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    case "imgMesofila":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Mesofila", "imgMesofila", e.X, e.Y, pnlCentral);//, 
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    case "imgMesofila2":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Mesofila", "imgMesofila2", e.X, e.Y, pnlCentral);//, 
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    case "imgTermifila":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Termifila", "imgTermifila", e.X, e.Y, pnlCentral);//, 
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    case "imgTermifila2":
                        {
                            // creacion e inicializacion de bacteria
                            Bacteria bacterium = new Bacteria("Termifila", "imgTermifila2", e.X, e.Y, pnlCentral);//
                            _ = bacterium.comportamientoBacteriaAsync();

                            break;
                        }
                    default:
                        {
                            break;
                        }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        private void pnlCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trkbrTemperatura_Scroll(object sender, EventArgs e)
        {
            // cambio de color de panlCentral segun temperatura
            lblCelcius.Text = trkbrTemperatura.Value.ToString() + " C°";
            temperatura = Int32.Parse(trkbrTemperatura.Value.ToString());

            if (temperatura >= 0 && temperatura < 10)
            {
                pnlCentral.BackColor = Color.FromArgb(51, 153, 255); // azul
            }
            else if (temperatura >= 10 && temperatura < 20)
            {
                pnlCentral.BackColor = Color.FromArgb(0, 255, 255); // celeste
            }
            else if (temperatura >= 20 && temperatura < 30)
            {
                pnlCentral.BackColor = Color.FromArgb(0, 255, 128); // verde claro
            }
            else if (temperatura >= 30 && temperatura < 40)
            {
                pnlCentral.BackColor = Color.FromArgb(178, 255, 102); // verde 
            }
            else if (temperatura >= 40 && temperatura < 50)
            {
                pnlCentral.BackColor = Color.FromArgb(255, 255, 51); // amarillo 
            }
            else if (temperatura >= 50 && temperatura < 60)
            {
                pnlCentral.BackColor = Color.FromArgb(255, 128, 0); // naranja 
            }
            else if (temperatura >= 60 && temperatura <= 75)
            {
                pnlCentral.BackColor = Color.FromArgb(255, 0, 0); // rojo 
            }
        }

        private void trkbrHumedad_Scroll(object sender, EventArgs e)
        {
            // cambio de opacidad de imagen de musgo segun la humedad
            lblHumedad.Text = trkbrHumedad.Value.ToString() + " %";
            humedad = Int32.Parse(trkbrHumedad.Value.ToString());


            if (humedad >= 0 && humedad < 10)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.05F);

            }
            else if (humedad >= 10 && humedad < 20)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.15F);
            }
            else if (humedad >= 20 && humedad < 30)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.25F);
            }
            else if (humedad >= 30 && humedad < 40)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.35F);
            }
            else if (humedad >= 40 && humedad < 50)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.45F);
            }
            else if (humedad >= 50 && humedad < 60)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.55F);
            }
            else if (humedad >= 60 && humedad < 70)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.65F);
            }
            else if (humedad >= 70 && humedad < 80)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.75F);
            }
            else if (humedad >= 80 && humedad < 90)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.85F);
            }
            else if (humedad >= 90 && humedad < 95)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 0.90F);
            }
            else if (humedad >= 95 && humedad <= 100)
            {
                imgMusgo.Image = SetImageOpacity(backImage, 1F);
            }
        }

        public Image SetImageOpacity(Image image, float opacity) // cambio de opacidad de imagen
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,//
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
            // https://stackoverflow.com/questions/23114282/are-we-able-to-set-opacity-of-the-background-image-of-a-panel
        }


        private void trkbrOxigeno_Scroll(object sender, EventArgs e)
        {
            lblOxigeno.Text = trkbrOxigeno.Value.ToString() + " %";
            cantO2 = Int32.Parse(trkbrOxigeno.Value.ToString()); // nivel de oxigeno
            oxigenoModificado = true;
            pnlO2.Controls.Clear();
        }

        private void trkbrCarbono_Scroll(object sender, EventArgs e)
        {
            lblCarbono.Text = trkbrCarbono.Value.ToString() + " %";
            cantCO2 = Int32.Parse(trkbrCarbono.Value.ToString()); // nivel de dioxido de carbono
            dioxidoCarbonoModificado = true;
            pnlC02.Controls.Clear();

        }

        private void imgPsicrofila_MouseDown(object sender, MouseEventArgs e)
        {
            imgPsicrofila1.DoDragDrop(imgPsicrofila1.Name, DragDropEffects.Copy |
          DragDropEffects.Move);
        }

        private void imgPsicrofila2_MouseDown(object sender, MouseEventArgs e)
        {
            imgPsicrofila2.DoDragDrop(imgPsicrofila2.Name, DragDropEffects.Copy |
            DragDropEffects.Move);
        }
        private void imgMesofila_MouseDown(object sender, MouseEventArgs e)
        {
            imgMesofila.DoDragDrop(imgMesofila.Name, DragDropEffects.Copy |
            DragDropEffects.Move);
        }

        private void imgMesofila2_MouseDown(object sender, MouseEventArgs e)
        {
            imgMesofila2.DoDragDrop(imgMesofila2.Name, DragDropEffects.Copy |
            DragDropEffects.Move);
        }

        private void imgTermifila_MouseDown(object sender, MouseEventArgs e)
        {
            imgTermifila.DoDragDrop(imgTermifila.Name, DragDropEffects.Copy |
            DragDropEffects.Move);
        }

        private void imgTermifila2_MouseDown(object sender, MouseEventArgs e)
        {
            imgTermifila2.DoDragDrop(imgTermifila2.Name, DragDropEffects.Copy |
            DragDropEffects.Move);
        }

        private void tmrGases_Tick(object sender, EventArgs e)
        {
            if (oxigenoModificado)
            {
                //Console.WriteLine(cantCO2);

                int auxO2 = 0; // basicamente solo se encarga de separar en niveles la cantOxigeno
                if (cantO2 == 0)
                    auxO2 = 0;
                if (cantO2 > 0 && cantO2 <= 10)
                    auxO2 = 1;
                if (cantO2 > 10 && cantO2 <= 20)
                    auxO2 = 2;
                if (cantO2 > 20 && cantO2 <= 30)
                    auxO2 = 3;
                if (cantO2 > 30 && cantO2 <= 40)
                    auxO2 = 4;
                if (cantO2 > 40 && cantO2 <= 50)
                    auxO2 = 5;
                if (cantO2 > 50 && cantO2 <= 60)
                    auxO2 = 8;
                if (cantO2 > 60 && cantO2 <= 70)
                    auxO2 = 10;
                if (cantO2 > 70 && cantO2 <= 80)
                    auxO2 = 12;
                if (cantO2 > 80 && cantO2 <= 90)
                    auxO2 = 14;
                if (cantO2 > 90 && cantO2 <= 100)
                    auxO2 = 16;

                for (int i = 0; i < auxO2; i++) // insercion de burbujas de oxigeno
                {
                    PictureBox img = new PictureBox();
                    img.Image = O2Image;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.Width = 40;
                    img.Height = 40;
                    img.Location = new Point(img.Location.X, 800 - i * 50);//
                    pnlO2.Controls.Add(img);

                    

                }
                oxigenoModificado = false;
            }

            if (dioxidoCarbonoModificado)
            {
                int auxCO2 = 0; // basicamente solo se encarga de separar en niveles la cantOxigeno
                if (cantCO2 == 0)
                    auxCO2 = 0;
                if (cantCO2 > 0 && cantCO2 <= 10)
                    auxCO2 = 1;
                if (cantCO2 > 10 && cantCO2 <= 20)
                    auxCO2 = 2;
                if (cantCO2 > 20 && cantCO2 <= 30)
                    auxCO2 = 3;
                if (cantCO2 > 30 && cantCO2 <= 40)
                    auxCO2 = 4;
                if (cantCO2 > 40 && cantCO2 <= 50)
                    auxCO2 = 5;
                if (cantCO2 > 50 && cantCO2 <= 60)
                    auxCO2 = 8;
                if (cantCO2 > 60 && cantCO2 <= 70)
                    auxCO2 = 10;
                if (cantCO2 > 70 && cantCO2 <= 80)
                    auxCO2 = 12;
                if (cantCO2 > 80 && cantCO2 <= 90)
                    auxCO2 = 14;
                if (cantCO2 > 90 && cantCO2 <= 100)
                    auxCO2 = 16;

                for (int i = 0; i < auxCO2; i++) // insercion de burbujas de oxigeno
                {
                    PictureBox img = new PictureBox();
                    img.Image = CO2Image;
                    img.SizeMode = PictureBoxSizeMode.StretchImage;
                    img.Width = 40;
                    img.Height = 40;
                    img.Location = new Point(img.Location.X, 800 - i * 50);
                    pnlC02.Controls.Add(img);

                }
                dioxidoCarbonoModificado = false;
            }

        }

        private void frmSimulador_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrGases.Stop();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            pnlCentral.Controls.Clear();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmPrincipal principal = new frmPrincipal(); // paso a form principal
            principal.FormClosed += MainForm_Closed;
            principal.Show();
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
    }


}
