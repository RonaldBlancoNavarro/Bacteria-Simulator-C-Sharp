using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Imaging;

namespace SimuladorBacterias.Clases
{
    class Bacteria
    {
        private string tipo; // psicrofilas , mesofilas, termofilas
        private string especie; //: psicrofila1...
        private int nivelCrecimiento; // = determina tamaño
        private int x, y; // posiciones de imagen
        private PictureBox imgBacteria;
        private int cantVida;
        private string estado; // = movimiento, quieta, muerta
        private bool capacidadReproducir;
        private int cantHijos;

        Panel contenedor; // panel donde se coloca la imagen de la bacteria
        static int tiempo; // variable contadora de segundos
        private static System.Timers.Timer aTimer;// contador de segundos

        int tiempo2; // variable contadora de segundos para fade transition



        public Bacteria()
        {
            tipo = "";
            especie = "";
            nivelCrecimiento = 1;
            x = 0;
            y = 0;
            imgBacteria = new PictureBox();
            cantVida = 100;
            estado = "movimiento";
            capacidadReproducir = false;
            cantHijos = 0;
            tiempo = 0;
            tiempo2 = 0;
        }

        public Bacteria(string tipo, string especie, int x, int y, Panel contenedor)
        {
            this.tipo = tipo;
            this.especie = especie;
            nivelCrecimiento = 1;
            this.x = x;
            this.y = y;
            imgBacteria = new PictureBox();
            cantVida = 100;
            estado = "movimiento";
            capacidadReproducir = false;
            cantHijos = 0;

            tiempo = 0;
            tiempo2 = 0;
            SetTimer();

            this.contenedor = contenedor;
            //this.temperatura = temperatura;

            this.contenedor.Controls.Add(imgBacteria);// agregado de imagen en panel
            determinarImagenBacteria();
        }



        public void determinarImagenBacteria()
        {
            // dimenciones
            imgBacteria.Width = 33;
            imgBacteria.Height = 33;

            // imagen
            switch (especie)
            {
                case "imgPsicrofila1":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                case "imgPsicrofila2":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria2.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                case "imgMesofila":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria5.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                case "imgMesofila2":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria4.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                case "imgTermifila":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria6.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                case "imgTermifila2":
                    {
                        Image img = Image.FromFile("..\\CapaPresentacion\\Recursos\\bacteria3.png");
                        imgBacteria.Image = img;
                        imgBacteria.SizeMode = PictureBoxSizeMode.StretchImage;
                        imgBacteria.Location = new Point(x - (imgBacteria.Width / 2), y - (imgBacteria.Height));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Rotacion(0);
        }

        public void Rotacion(int rotacion)
        {
            switch (rotacion) // rotar imagenes
            {
                case 0:
                    {
                        imgBacteria.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        break;
                    }
                case 90:// derecha
                    {
                        imgBacteria.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    }
                case 180:
                    {
                        imgBacteria.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    }
                case 270:
                    {
                        imgBacteria.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public async Task comportamientoBacteriaAsync() // manejo del comportameiento de la bacteria en su ciclo de vida
        {
            Random random = new Random(); // creacion de coordenas para movimiento de imagen de bacteria
            x = random.Next(-1, 2);
            y = random.Next(-1, 2);

            if (x == 0) 
            {
                x += 1;
            }
            else if (y == 0)
            {
                y += 1;
            }

            while (cantVida > 0) // vida de bacteria
            {

                desarrollarBacteria();

                moverBacteria();

                reproducirBacteria();

                calcularVidaBacteria();

                await Task.Delay(30);
            }

            _ = muerteBacteria();// eliminacion de bacteria con fadetransition
        }

        private static void SetTimer() 
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            //https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-6.0
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            tiempo++;

            if (tiempo >= 30) // detencion de contador de tiempo
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }

        public void desarrollarBacteria()
        {
            // cremimiento de bacteria si las condiciones son favorables
            bool crecer = false;

            if (tipo == "Psicrofila")
            {
                if (frmSimulador.Temperatura > 0 && frmSimulador.Temperatura < 20)
                {
                    crecer = true;
                }
            }
            else if (tipo == "Mesofila")
            {
                if (frmSimulador.Temperatura > 20 && frmSimulador.Temperatura < 45)
                {
                    crecer = true;
                }
            }
            else if (tipo == "Termofila")
            {
                if (frmSimulador.Temperatura > 45 && frmSimulador.Temperatura < 70)
                {
                    crecer = true;
                }
            }

            if (crecer)
            {

                if (tiempo >= 5 && nivelCrecimiento == 1) // pasar a nivelCrecimiento 2
                {
                    // crecimineto de bacteria en imagen y tamaño
                    nivelCrecimiento = 2;
                    //determinarImagenBacteria();
                    imgBacteria.Width = 45;
                    imgBacteria.Height = 45;
                }
                else if (tiempo >= 10 && nivelCrecimiento == 2)// pasar a nivelCrecimiento 3
                {
                    // crecimineto de bacteria en imagen y tamaño
                    nivelCrecimiento = 3;
                    //determinarImagenBacteria();
                    imgBacteria.Width = 66;
                    imgBacteria.Height = 66;
                }
                else if (tiempo >= 15 && nivelCrecimiento == 3)// activar capacidad de reproducir
                {
                    capacidadReproducir = true;
                    //estado = "quieta";
                }
            }
        }

        public void moverBacteria()
        {
            if (estado == "movimiento") // estado; // = movimiento, quieta, muerta
            {
                imgBacteria.Location = new Point(imgBacteria.Location.X - x, imgBacteria.Location.Y - y);

                //Si llega a los bordes de la derecha o izquierda
                if (imgBacteria.Location.X <= 140)
                {
                    x = -x;
                }
                else if (imgBacteria.Location.X + imgBacteria.Width >= 1682)
                {
                    x = -x;
                }

                //Si llega a los border de arriba o abajo
                if (imgBacteria.Location.Y <= 60)
                {
                    y = -y;
                }
                else if (imgBacteria.Location.Y + imgBacteria.Height >= 883)
                {
                    y = -y;
                }
            }

        }

        public void reproducirBacteria()
        {
            // determinar si una bacteria se puede reproducir
            bool reproducir = false;

            if (tipo == "Psicrofila")
            {
                if (frmSimulador.Humedad > 0 && frmSimulador.Humedad < 20)
                {
                    reproducir = true;
                }
            }
            else if (tipo == "Mesofila")
            {
                if (frmSimulador.Humedad > 20 && frmSimulador.Humedad < 45)
                {
                    reproducir = true;
                }
            }
            else if (tipo == "Termofila")
            {
                if (frmSimulador.Humedad > 45 && frmSimulador.Humedad < 70)
                {
                    reproducir = true;
                }
            }

            if (reproducir)
            {
                if (capacidadReproducir && cantHijos == 0 && (contenedor.Controls.Count) - 3 < 20) // limite de reproduccion de bacterias
                {
                    Random random = new Random();
                    cantHijos = random.Next(1, 4);

                    for (int i = 0; i < cantHijos; i++) // cantidad de hijos aleatorea
                    {
                        // insercion de celulas hijas de la celula separada segun tipo de celula 
                        divisionCelular();
                    }

                    capacidadReproducir = false;
                    cantVida = 0; // muerte por division celular para reproduccion
                }
            }
        }

        public void divisionCelular()
        {
            switch (especie)
            {
                case "imgPsicrofila1":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Psicrofila", "imgPsicrofila1", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);//
                        _ = bacterium.comportamientoBacteriaAsync();
                        break;
                    }
                case "imgPsicrofila2":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Psicrofila", "imgPsicrofila2", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);
                        _ = bacterium.comportamientoBacteriaAsync();
                        break;
                    }
                case "imgMesofila":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Mesofila", "imgMesofila", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);//, 
                        _ = bacterium.comportamientoBacteriaAsync();
                        break;
                    }
                case "imgMesofila2":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Mesofila", "imgMesofila2", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);//,
                        _ = bacterium.comportamientoBacteriaAsync();
                        break;
                    }
                case "imgTermifila":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Termifila", "imgTermifila", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);//
                        _ = bacterium.comportamientoBacteriaAsync();
                        break;
                    }
                case "imgTermifila2":
                    {
                        // creacion e inicializacion de bacteria
                        Bacteria bacterium = new Bacteria("Termifila", "imgTermifila2", imgBacteria.Location.X, imgBacteria.Location.Y, contenedor);//
                        _ = bacterium.comportamientoBacteriaAsync();

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }


        public void calcularVidaBacteria() // calcula vida y algunos comportamientos de bacteria
        {
            // toma en cuenta .... temperatura. O2 , CO2

            switch (tipo)
            {
                case "Psicrofila":
                    {

                        // limites extremos- si se cumple cualquiera muere bacteria
                        if (frmSimulador.Temperatura > 70 || frmSimulador.CantO2 < 10 || frmSimulador.CantCO2 > 80)
                        {
                            cantVida = 0;
                        }
                        else // seleccion de muerte de bacteria por suerte 
                        {
                            var random = new Random();
                            int contMuerte = 0;

                            if (frmSimulador.Temperatura > 40)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantO2 < 20)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantCO2 > 60)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }


                            if (contMuerte == 0)
                            {
                                estado = "movimiento";
                                cantVida = 100;
                            }
                            if (contMuerte == 1)
                            {
                                estado = "quieta";
                                cantVida = 50;

                            }
                            else if (contMuerte == 2)
                            {
                                estado = "quieta";
                                cantVida = 0;
                            }

                            //Console.WriteLine(contMuerte);
                        }
                        break;
                    }
                case "Mesofila":
                    {
                        // limites extremos- si se cumple cualquiera muere bacteria
                        if (frmSimulador.Temperatura < 5 || frmSimulador.CantO2 < 60 || frmSimulador.CantCO2 > 20)
                        {
                            cantVida = 0;
                        }
                        else // seleccion de muerte de bacteria por suerte 
                        {
                            var random = new Random();
                            int contMuerte = 0;

                            if (frmSimulador.Temperatura < 10)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantO2 < 80)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantCO2 > 10)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }


                            if (contMuerte <= 1)
                            {
                                estado = "movimiento";
                                cantVida = 100;
                            }
                            if (contMuerte == 2)
                            {
                                estado = "quieta";
                                cantVida = 50;

                            }
                            else if (contMuerte == 3)
                            {
                                estado = "quieta";
                                cantVida = 0;
                            }

                            //Console.WriteLine(contMuerte);
                        }

                        break;
                    }
                case "Termifila":
                    {
                        // limites extremos- si se cumple cualquiera muere bacteria
                        if (frmSimulador.Temperatura < 20 || frmSimulador.CantO2 < 40 || frmSimulador.CantCO2 > 60)
                        {
                            cantVida = 0;
                        }
                        else // seleccion de muerte de bacteria por suerte 
                        {
                            var random = new Random();
                            int contMuerte = 0;

                            if (frmSimulador.Temperatura < 40)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantO2 < 50)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }
                            if (frmSimulador.CantCO2 > 50)
                            {
                                var randomBool = random.Next(2) == 1;
                                if (randomBool)
                                {
                                    contMuerte++;
                                }
                            }


                            if (contMuerte == 0)
                            {
                                estado = "movimiento";
                                cantVida = 100;
                            }
                            if (contMuerte == 1)
                            {
                                estado = "quieta";
                                cantVida = 50;

                            }
                            else if (contMuerte == 2)
                            {
                                estado = "quieta";
                                cantVida = 0;
                            }

                            //Console.WriteLine(contMuerte);
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public async Task muerteBacteria()
        {
            // aplicacion de fade transition 

            while (tiempo2 <= 3) // vida de bacteria
            {
                tiempo2++;

                // cambio en opacidad de imagen
                if (tiempo2 == 1)
                    imgBacteria.Image = SetImageOpacity(imgBacteria.Image, 0.75F);
                if (tiempo2 == 2)
                    imgBacteria.Image = SetImageOpacity(imgBacteria.Image, 0.50F);
                if (tiempo2 == 3)
                    imgBacteria.Image = SetImageOpacity(imgBacteria.Image, 0.25F);

                await Task.Delay(200);
            }

            // eliminacion de imagen
            if (cantVida == 0 && tiempo2 > 3)
            {
                if (contenedor.Controls.Contains(this.imgBacteria))
                {
                    contenedor.Controls.Remove(this.imgBacteria);
                }
            }
        }

        public Image SetImageOpacity(Image image, float opacity) // asignacion de opacidad de imagen a bacteria para efecto fade transition
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




    }
}


