using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WebDiverWpf
{
    public delegate void SetText(string s);
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWebDriver driver;
        private readonly string loginUrl = "https://passport.jd.com/new/login.aspx";
        private readonly string orderUrl = "https://marathon.jd.com/seckill/seckill.action?skuId=7299780&num=1&rid=1527661627";
        private readonly string failUrl = "https://marathon.jd.com/koFail.html";
        private readonly string jdUrl ="https://www.jd.com/";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            driver = new FirefoxDriver(@"C:\Users\Stone\Desktop\WebDriver");
            //打开指定的URL地址
            driver.Navigate().GoToUrl(loginUrl);

        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            if (driver.Url.StartsWith(failUrl) || driver.Url.Equals(jdUrl))
            {
                driver.Navigate().GoToUrl(orderUrl);
                driver.FindElement(By.Id("tryBtn")).Click();
                Thread.Sleep(100);
                ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("btn-submit"));
                Thread.Sleep(100);
                elements[0].Click();
                Thread.Sleep(100);
                elements[1].Click();
                Thread.Sleep(100);
                driver.FindElement(By.Id("invoiceMobile")).SendKeys("13821003012");
                Thread.Sleep(100);
                elements[2].Click();
                Thread.Sleep(100);
                driver.FindElement(By.Id("order-submit")).Click();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            driver.Close();
            this.Close();
        }
    }
}
