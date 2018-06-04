using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Machine.IState
{
    public abstract class IMachineState
    {
        protected string exePath = System.Environment.CurrentDirectory + @"\BrowerEXE";

        public abstract void Login();

        public abstract void WaitSeckill();

        public abstract void Seckilling();

        public abstract void Seckilled();
    }
}
