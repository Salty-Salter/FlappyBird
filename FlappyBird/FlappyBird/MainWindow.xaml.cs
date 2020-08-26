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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double gravity = 5;
        int num = 0;
        bool alive = true;
        int score = 0;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(0.002);
            LiveTime.Tick += new EventHandler(gameTimer_Tick);
            LiveTime.Start();          
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (alive == true)
            {
                num = num - 1;
                Thickness icon = sensor.Margin;
                Thickness image = bird.Margin;
                bird.Margin = new Thickness(image.Left, image.Top + gravity, 0, 0);
                sensor.Margin = new Thickness(icon.Left, icon.Top + gravity, 0, 0);

                Thickness marg = pipe1.Margin;
                Thickness marg1 = pipe2.Margin;
                if (marg.Left >= -85)
                {
                    pipe1.Margin = new Thickness(marg.Left - 1.5, 0, 0, 0);
                    pipe2.Margin = new Thickness(marg.Left - 1.5, marg1.Top, 0, 0);
                }
                else
                {
                    marg.Left = 485;
                    pipe1.Margin = new Thickness(marg.Left, 0, 0, 0);

                    var random = new Random();
                    int num = random.Next(350);
                    pipe1.Height = num;
                    pipe2.Margin = new Thickness(marg.Left, 0 + num + 125, 0, 0);

                    if (500 - num - 125 > 0)
                    {
                        pipe2.Height = 500 - num - 125;
                    }
                    else
                    {
                        pipe2.Height = 0.01;
                    }
                }

                Thickness marg3 = pipe3.Margin;
                Thickness marg4 = pipe4.Margin;
                if (marg3.Left >= -85)
                {
                    pipe3.Margin = new Thickness(marg3.Left - 1.5, 0, 0, 0);
                    pipe4.Margin = new Thickness(marg3.Left - 1.5, marg4.Top, 0, 0);
                }
                else
                {
                    marg3.Left = 485;
                    pipe3.Margin = new Thickness(marg3.Left, 0, 0, 0);

                    var random = new Random();
                    int num2 = random.Next(350);
                    pipe3.Height = num2;
                    pipe4.Margin = new Thickness(marg3.Left, 0 + num2 + 125, 0, 0);

                    if (500 - num2 - 125 > 0)
                    {
                        pipe4.Height = 500 - num2 - 125;
                    }
                    else
                    {
                        pipe4.Height = 0.01;
                    }
                }

                if (marg.Left == 117 || marg3.Left == 117 || marg.Left == 116 || marg3.Left == 116)
                {
                    score++;
                    Display.Content = score.ToString();
                }

                if (150 <= marg.Left && marg.Left <= 250 && (icon.Top <= pipe1.Height || icon.Top + 30 >= pipe1.Height + 125))
                {
                    life.Content = "dead";
                }
                else if (150 <= marg3.Left && marg3.Left <= 250 && (icon.Top <= pipe3.Height || icon.Top + 30 >= pipe3.Height + 125))
                {
                    life.Content = "dead";
                }
                else
                {
                    life.Content = "alive";
                }

                if (num <= 0) { gravity = 3; }
                else { gravity = gravity + 0.75; }
            }
        }

        private void Jump(object sender, EventArgs e)
        {
            gravity = -10;
            num = 10;
        }
    }
}
