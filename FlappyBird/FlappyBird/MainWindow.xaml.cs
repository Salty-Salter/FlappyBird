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

namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            Thickness marg = pipe1.Margin;
            if (marg.Left != -100)
            {
                pipe1.Margin = new Thickness(marg.Left-1, 0, 0, 0);
            }
            else
            {
                marg.Left = 400;
                pipe1.Margin = new Thickness(marg.Left, 0, 0, 0);

                var random = new Random();
                int num = random.Next(450);
                pipe1.Height = num;
                pipe2.Margin = new Thickness(350, 0 + num + 100, 0, 0);
                pipe2.Height = 500 - num - 100;

            }
        }
    }
}
