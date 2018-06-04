using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Seckill.Main.Core.Machine.IState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Machine
{
    public class JDSeckillMachine : SeckillMachine
    {
        public override void Login()
        {
            _machineState.Login();
        }
    }
}
