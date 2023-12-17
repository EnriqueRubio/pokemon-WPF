using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pokemon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        double decremento = 0.0;
        Storyboard danio;
        Storyboard ataque;
        Storyboard dormir;
        Storyboard quieto;
        public MainWindow()
        {
            InitializeComponent();
            this.danio = (Storyboard)this.Resources["apagado"];
            this.quieto = (Storyboard)this.Resources["quieto"];
            this.ataque = (Storyboard)this.Resources["ataque"];
            this.dormir = (Storyboard)this.Resources["dormir"];

            this.danio.Completed += new EventHandler(finDanio);
            this.ataque.Completed += new EventHandler(finFuego);
            

            this.quieto.Begin();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
            
        }
        private void reloj(object sender, EventArgs e)
        {
            
            if (this.pbVida.Value == 0)
            {
                t1.Stop();

                this.imgFuego.IsEnabled = false;
                this.imgPocima.IsEnabled = false;
                this.charmander1.IsEnabled = false;

                this.quieto.Stop();
                this.ataque.Stop();
                this.danio.Stop();

                this.dormir.Begin();
            }
            else
            {
                this.pbVida.Value -= decremento;
                if (this.pbEscudo.Value != 0)
                {
                    this.pbEscudo.Value -= decremento;
                } else if(this.pbEscudo.Value == 0)
                    {
                    this.pbVida.Value -= 5;
                }
                decremento += 0.10;
            }               
        }


        private void accPocima(object sender, MouseButtonEventArgs e)
        {
            this.pbVida.Value += 5;
        }

        private void charmander1_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            this.quieto.Stop();
            this.ataque.Stop();
            this.danio.Begin();
            
        }
        private void finDanio(object sender, EventArgs e)
        {
            this.quieto.Begin();
            this.pbEscudo.Value -= 5;
        }
        private void finFuego(object sender, EventArgs e)
        {
            this.quieto.Begin();
            this.pbEscudo.Value += 5;
        }



        private void fuego_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ataque.Stop();
            this.quieto.Stop();
            this.danio.Stop();
            this.ataque.Begin();
        }
    }
}
