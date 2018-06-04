using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Seckill.Main.Model;

namespace Seckill.Main.Core.Behavior
{
    public class JDWaitSeckillBehavior : IWaitSeckillBehavior
    {
        private IWebDriver _driver;
        private TimeSpan _time;
        private Good _good;
        public JDWaitSeckillBehavior(IWebDriver driver, Good good)
        {
            this._driver = driver;
            _time = TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["SleepTime"]));
            _good = good;
        }

        public void WaitSeckill()
        {
            _driver.Navigate().GoToUrl(_good.GoodUrl);
            IWebElement webElement =  _driver.FindElement(By.Id("banner-miaosha"));
            IWebElement webElement2 = webElement.FindElement(By.ClassName("activity-message"));
            string b = webElement2.Text;

            //string c = _driver.FindElement(By.ClassName("activity-message")).Text;

            //string a = webElement.Text;
        }
    }
}
