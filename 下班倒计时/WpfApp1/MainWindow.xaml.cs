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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1;

        public MainWindow()
        {
            InitializeComponent();

            timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 1);//计时器间隔
            timer1.Tick += new EventHandler(ShowTimer_Tick);
            timer1.Start();




        }
        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            l1.Content = DateTime.Now.ToString("今天是 yyyy/MM/dd");
            l2.Content = DateTime.Now.ToString("当前时间是 HH:mm:ss");
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string end = DateTime.Now.ToString("yyyy-MM-dd ") + "17:50:00";
            DateTime dtStartTime = Convert.ToDateTime(now);
            DateTime dtEndTime = Convert.ToDateTime(end);
            TimeSpan ts = dtEndTime - dtStartTime;
            if (dtEndTime > dtStartTime)
            {
                l3.Content = string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
                l4.Content = "";
            }
            else
            {
                ts = dtStartTime - dtEndTime;
                l3.Content = "00:00:00";
                l4.Content = string.Format("今日已加班 {0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);

            }
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();//退出
        }

        private void Config(object sender, RoutedEventArgs e)
        {

        }
    }
}

