using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.CommonLib.AutoBrower
{
    public class AutoBrower
    {
        public void Create() {

            IWebDriver driver = new FirefoxDriver("");
            driver.Navigate().GoToUrl("");
            //Thread.Sleep(sleepmm);
            //ISearchContext s = new ISearchContext();
            //By by = new By();

            IWebElement e1 = driver.FindElement(By.LinkText("账户登录"));
        }
    }
}
