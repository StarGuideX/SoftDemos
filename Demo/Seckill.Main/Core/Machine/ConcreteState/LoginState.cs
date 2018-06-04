using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Seckill.Main.Core.Machine.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Machine.ConcreteState
{
    public class LoginState : IMachineState
    {
        SeckillMachine _machine;
        IWebDriver driver;
        TimeSpan sleepTime = TimeSpan.FromMilliseconds(100);

        public LoginState(SeckillMachine machine)
        {
            this._machine = machine;
        }

        public override void Login()
        {
            driver = new FirefoxDriver(exePath);
            driver.Navigate().GoToUrl("https://passport.jd.com/new/login.aspx");
            Thread.Sleep(sleepTime);
            driver.FindElement(By.LinkText("账户登录")).Click();
            Thread.Sleep(sleepTime);
            driver.FindElement(By.Id("loginname")).SendKeys("");
            driver.FindElement(By.Id("nloginpwd")).SendKeys("");

            _machine.MachineState = _machine.SeckillingState;
        }

        public override void WaitSeckill()
        {
            throw new NotImplementedException();
        }

        public override void Seckilling()
        {
            throw new NotImplementedException();
        }

        public override void Seckilled()
        {
            throw new NotImplementedException();
        }
    }
}
