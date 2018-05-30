using CefSharp;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CefWebBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string loginUrl = "https://passport.jd.com/new/login.aspx";
        private string orderUrl = "https://marathon.jd.com/seckill/seckill.action?skuId=7299780&num=1&rid=1527661627";
        public MainWindow()
        {
            InitializeComponent();
            myWeb.Address = loginUrl;
        }

        private void loginSubmit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"document.getElementById('loginname').value = '327303195@qq.com';");
            sb.Append(@"document.getElementById('nloginpwd').value = 'stone13142nan%';");
            //sb.Append(@"document.getElementById('loginsubmit').click();");
            myWeb.ExecuteScriptAsync(sb.ToString());
            //myWeb.ExecuteScriptAsync("");
        }

        private void orderJump_Click(object sender, RoutedEventArgs e)
        {
            myWeb.Address = orderUrl;
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("var list = document.getElementsByClassName('btn-submit'); list[0].onclick(); list[1].onclick(); document.getElementById('invoiceMobile').value = '13821003012'; list[2].onclick(); document.getElementById('order-submit').onclick(); ");
            myWeb.ExecuteScriptAsync(sb.ToString());
        }

        private void re() {
            
        }

    }
}
