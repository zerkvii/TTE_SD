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
using System.Windows.Threading;
using xym_.content;
namespace xym_.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public DispatcherTimer timer { set; get; }
        public int cd { set; get; }
        public Home()
        {
            InitializeComponent();
            this.cd=0;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.cd++;
            foreach (var c in LogicalTreeHelper.GetChildren(this.pane))
            {
                if (c is cir)
                {
                    (c as cir).change_color(Colors.Yellow);
                }  
            }
        }

        private void Showcursor(object sender, MouseEventArgs e)
        {
           Point p = Mouse.GetPosition(this);
            la.Content = p.X+" "+p.Y;
           
        }

        private void addhole(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(this);
            cir c = new cir(p) { Width=15,Height=15};
            la2.Content = c.x_label + " " + c.y_label;
            pane.Children.Add(c);
            Canvas.SetLeft(c, e.GetPosition(this).X);
            Canvas.SetTop(c, e.GetPosition(this).Y);
         

        }

        private void deleteall(object sender, MouseButtonEventArgs e)
        {
            pane.Children.Clear();
        }

        private void count(object sender, RoutedEventArgs e)
        {

            this.timer.Start();

        }
    }
}
