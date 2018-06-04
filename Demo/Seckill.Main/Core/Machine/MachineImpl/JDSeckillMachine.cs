using OpenQA.Selenium;
using Seckill.Main.Core.Behavior;
using Seckill.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Machine
{
    public class JDSeckillMachine : ISeckillMachine
    {
        private IWebDriver _driver;
        private ILoginBehavior loginBehavior;
        private IWaitSeckillBehavior waitSeckillBehavior;
        private Good _good;
        public JDSeckillMachine(IWebDriver driver, Good good)
        {
            _driver = driver;
            _good = good;
            loginBehavior = new JDLoginBehavior(_driver);
            waitSeckillBehavior = new JDWaitSeckillBehavior(_driver, _good);
        }

        public void Login()
        {
            loginBehavior.Login();
        }

        public void WaitSeckill()
        {
            waitSeckillBehavior.WaitSeckill();
        }

        public void Seckilled()
        {
            throw new NotImplementedException();
        }

        public void Seckilling()
        {
            throw new NotImplementedException();
        }


    }
}
