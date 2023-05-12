using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net; //取得本機IP

namespace MasterCardMIP_Sim
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //vvvvvv 取得本機IP
            System.Net.IPAddress SvrIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            //Response.Write("SvrIP=" + SvrIP.ToString());
            Form1 myForm1 = new Form1();
            myForm1.TextBox1.Text = SvrIP.ToString();
            myForm1.button_MIP_STOP.Enabled = false; //要去按鈕(button_MIP_STOP)的屬性視窗把 Modifiers 設為 Public，才能在這裡把按鈕設 Enable=false
            Application.Run(myForm1); //Application.Run(new Form1());
            //^^^^^^ 取得本機IP
        }
    }
}
