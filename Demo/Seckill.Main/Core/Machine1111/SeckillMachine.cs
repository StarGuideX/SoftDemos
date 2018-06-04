using OpenQA.Selenium;
using Seckill.Main.Core.Machine.ConcreteState;
using Seckill.Main.Core.Machine.IState;
using Seckill.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seckill.Main.Core.Machine
{
    public abstract class SeckillMachine
    {
        protected IMachineState _loginState;
        protected IMachineState _waitSeckillState;
        protected IMachineState _seckillingState;
        protected IMachineState _seckilledState;
        protected IMachineState _machineState;

        private Good _good;

        public IMachineState LoginState
        {
            get
            {
                return _loginState;
            }

            set
            {
                _loginState = value;
            }
        }

        public IMachineState WaitSeckillState
        {
            get
            {
                return _waitSeckillState;
            }

            set
            {
                _waitSeckillState = value;
            }
        }

        public IMachineState SeckillingState
        {
            get
            {
                return _seckillingState;
            }

            set
            {
                _seckillingState = value;
            }
        }

        public IMachineState SeckilledState
        {
            get
            {
                return _seckilledState;
            }

            set
            {
                _seckilledState = value;
            }
        }

        public IMachineState MachineState
        {
            get
            {
                return _machineState;
            }

            set
            {
                _machineState = value;
            }
        }

        public Good Good
        {
            get
            {
                return _good;
            }

            set
            {
                _good = value;
            }
        }

        public SeckillMachine()
        {
            _loginState = new LoginState(this);
            _machineState = _loginState;
        }
        public abstract void Login();

    }
}
