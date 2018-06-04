using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Behavior
{
    public class JDLoginBehavior : ILoginBehavior
    {
        private IWebDriver _driver;
        private TimeSpan _time;
        private string _username;
        private string _password;
        public JDLoginBehavior(IWebDriver driver)
        {
            this._driver = driver;
            _time = TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["SleepTime"]));
            _username = ConfigurationManager.AppSettings["JDUsername"];
            _password = ConfigurationManager.AppSettings["JDPassword"];
        }

        public void Login()
        {
            _driver.Navigate().GoToUrl("https://passport.jd.com/new/login.aspx");
            Thread.Sleep(_time);
            _driver.FindElement(By.LinkText("账户登录")).Click();
            Thread.Sleep(_time);
            _driver.FindElement(By.Id("loginname")).SendKeys(_username);
            _driver.FindElement(By.Id("nloginpwd")).SendKeys(_password);
        }
    }
}
