using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using static System.Net.WebRequestMethods;

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
        private readonly string jdUrl = "https://www.jd.com/";
        private TimeSpan sleepmm = TimeSpan.FromMilliseconds(2);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            string username = UserNameTB.Text;
            string password = PasswordTB.Text;

            //打开jd
            string exePath = System.Environment.CurrentDirectory + @"\BrowerEXE";
            driver = new FirefoxDriver(exePath);
            driver.Navigate().GoToUrl(loginUrl);
            Thread.Sleep(sleepmm);
            IWebElement e1 = driver.FindElement(By.LinkText("账户登录"));
            e1.Click();
            driver.FindElement(By.Id("loginname")).SendKeys(username);
            Thread.Sleep(sleepmm);
            driver.FindElement(By.Id("nloginpwd")).SendKeys(password);
            Thread.Sleep(sleepmm);
            driver.FindElement(By.Id("loginsubmit")).Click();

            //"banner-miaosha"
            //验证码
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            if (driver.Url.StartsWith(failUrl) || driver.Url.Equals(jdUrl))
            {
                driver.Navigate().GoToUrl(orderUrl);
                driver.FindElement(By.Id("tryBtn")).Click();
                Thread.Sleep(sleepmm);
                ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("btn-submit"));
                Thread.Sleep(sleepmm);
                elements[0].Click();
                Thread.Sleep(sleepmm);
                elements[1].Click();
                Thread.Sleep(sleepmm);
                driver.FindElement(By.Id("invoiceMobile")).SendKeys("13821003012");
                Thread.Sleep(sleepmm);
                elements[2].Click();
                Thread.Sleep(sleepmm);
                driver.FindElement(By.Id("order-submit")).Click();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            driver.Close();
            this.Close();
        }

        private void miaosha_Click(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer();
            timer
        }

        private void singleMiaosha_Click(object sender, RoutedEventArgs e)
        {
            driver.FindElement(By.Id("InitCartUrl")).Click();//driver.FindElement(By.LinkText("加入购物车"));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            driver.FindElement(By.Id("GotoShoppingCart")).Click();//driver.FindElement(By.LinkText("去购物车结算"));
            Thread.Sleep(sleepmm);
            driver.FindElement(By.Id("toggle-checkboxes_down")).Click(); //driver.FindElement(By.LinkText("全选"));
            Thread.Sleep(sleepmm);
            driver.FindElement(By.LinkText("去结算")).Click();
            Thread.Sleep(sleepmm);
            driver.FindElement(By.Id("order-submit")).Click();//text:提交订单
        }
    }
}
