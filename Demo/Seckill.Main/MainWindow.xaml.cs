using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Seckill.Main.Core.Machine;
using Seckill.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Seckill.Main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimeSpan sleepTime = TimeSpan.FromMilliseconds(100);
        IWebDriver webDriver;
        ISeckillMachine machine;
        public MainWindow()
        {
            InitializeComponent();
            string exePath = System.Environment.CurrentDirectory + @"\BrowerEXE";
            webDriver = new FirefoxDriver(exePath);
            Good good = new Good();
            good.GoodUrl = "https://item.jd.com/4631945.html";
            machine = new JDSeckillMachine(webDriver, good);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            machine.Login();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            machine.WaitSeckill();
        }
    }
}
