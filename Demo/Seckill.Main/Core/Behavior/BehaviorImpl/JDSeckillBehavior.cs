using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Seckill.Main.Model;
using System.Timers;
using System.Text.RegularExpressions;

namespace Seckill.Main.Core.Behavior
{
    public class JDSeckillBehavior : ISeckillBahavior
    {
        private IWebDriver _driver;
        private TimeSpan _time;
        private Good _good;
        private Timer _checkTimer;
        private Timer _orderTimer;
        public JDSeckillBehavior(IWebDriver driver, Good good)
        {
            this._driver = driver;
            _time = TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["SleepTime"]));
            _good = good;
        }

        public void Seckill()
        {
            WaitSeckill();

        }


        //当天
        public void WaitSeckill()
        {
            //跳转
            _driver.Navigate().GoToUrl(_good.GoodUrl);
            //预约
            IWebElement orderBanner = _driver.FindElement(By.Id("yuyue-banner"));
            IWebElement orderTime = orderBanner.FindElement(By.ClassName("J-time"));
            string orderTimeStr = orderTime.Text;
            double allTime = GetAllTime(orderTimeStr);

            //创建倒计时抢购Timer
            _orderTimer = new Timer();
            _orderTimer.Interval = allTime;
            _orderTimer.AutoReset = true;
            _orderTimer.Elapsed += CheckOrderTime;
            //创建校准时间Timer
            _checkTimer = new Timer();
            _checkTimer.Interval = TimeSpan.FromMinutes(10).TotalMilliseconds;
            _checkTimer.AutoReset = true;
            _checkTimer.Elapsed += CheckOrderTime;














            string time = "22:59:54";
            //string c = _driver.FindElement(By.ClassName("activity-message")).Text;

            //t.
            //string a = webElement.Text;
        }
        private double GetAllTime(string orderTimeStr)
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int hourIndexBedfore = 0;
            int minuteIndex = 0;
            int secondsIndex = 0;

            if (orderTimeStr.Contains("小时") && orderTimeStr.Contains("分") && orderTimeStr.Contains("秒"))
            {
                hourIndexBedfore = orderTimeStr.IndexOf("小");
                minuteIndex = orderTimeStr.IndexOf("分");
                secondsIndex = orderTimeStr.IndexOf("秒");
                hours = int.Parse(orderTimeStr.Substring(0, hourIndexBedfore));
                minutes = int.Parse(orderTimeStr.Substring(hourIndexBedfore + 2, minuteIndex - (hourIndexBedfore + 2)));
                seconds = int.Parse(orderTimeStr.Substring(minuteIndex + 1, secondsIndex - (minuteIndex + 1)));
                return TimeSpan.FromHours(hours).TotalMilliseconds + TimeSpan.FromMinutes(minutes).TotalMilliseconds + TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            }
            else if (orderTimeStr.Contains("分") && orderTimeStr.Contains("秒"))
            {
                minuteIndex = orderTimeStr.IndexOf("分");
                secondsIndex = orderTimeStr.IndexOf("秒");
                minutes = int.Parse(orderTimeStr.Substring(0, minuteIndex));
                seconds = int.Parse(orderTimeStr.Substring(minuteIndex + 1, secondsIndex - (minuteIndex + 1)));
                return TimeSpan.FromMinutes(minutes).TotalMilliseconds + TimeSpan.FromSeconds(seconds).TotalMilliseconds;
            }
            else if (orderTimeStr.Contains("秒"))
            {
                //暂无
            }
            return 0;
        }

        private void CheckOrderTime(object source, ElapsedEventArgs e)
        {
            //抓取时间
            IWebElement orderBanner = _driver.FindElement(By.Id("yuyue-banner"));
            IWebElement orderTime = orderBanner.FindElement(By.ClassName("J-time"));
            string orderTimeStr = orderTime.Text;
            double allTime = GetAllTime(orderTimeStr);
            //设置Interval
        }

        private void BuyOrder(object source, ElapsedEventArgs e)
        {

        }
    }
}
