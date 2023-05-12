using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;           //匯入網路通訊協定相關函數
using System.Net.Sockets;   //匯入網路插座功能函數
using System.Threading;     //匯入多執行緒功能函數
using System.Collections;   //匯入集合物件功能
using System.IO;            // 使用 StreamReader 要 using System.IO

namespace MasterCardMIP_Sim
{
    public partial class Form1 : Form
    {
        //公用變數宣告
        TcpListener TcpListener_Server; //伺服端網路監聽器(相當於電話總機)
        Socket Socket_Client;           //給連線用的連線物件(相當於電話分機)
        Thread Thread_Server;           //伺服器監聽用執行緒(電話總機開放中)
        Thread Thread_Client;           //連線用的通話執行緒(電話分機連線中)

        public Form1()
        {
            InitializeComponent();
        }

        #region 接受連線連線要求的程式
        private void ServerSub()
        {
            //Server IP 和 Port
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(TextBox1.Text), int.Parse(TextBox2.Text));
            TcpListener_Server = new TcpListener(EP);
            TcpListener_Server.Start(100);
            while (true)
            {
                try
                {
                    Socket_Client = TcpListener_Server.AcceptSocket();
                }
                catch (Exception)
                {
                    return;
                }
                Thread_Client = new Thread(Listen);    //建立監聽這個連線連線的獨立執行緒
                Thread_Client.IsBackground = true;     //設定為背景執行緒
                Thread_Client.Start();                 //開始執行緒的運作
            }
        }
        #endregion

        #region 監聽連線訊息的程式
        private void Listen()
        {
            Socket Listen_Socket_Client = Socket_Client; //複製Client通訊物件到個別連線專用物件Sck
            Thread Listen_Thread_Client = Thread_Client; //複製執行緒Th_Clt到區域變數Th

            while (true) //持續監聽連線傳來的訊息
            {
                try //用 Listen_Socket_Client 來接收此連線訊息，int_DataLen 是接收訊息的 Byte 數目
                {
                    int int_DataLen = Listen_Socket_Client.Available;   //接收到的socket資料大小
                    if (int_DataLen <= 0)
                    {
                        continue;
                    }
                    byte[] byte_Receive = new byte[int_DataLen]; //建立接收資料用的陣列，長度須大於可能的訊息
                    Listen_Socket_Client.Receive(byte_Receive);  //接收網路資訊(Byte陣列)
                    //Array.Resize(ref byte_Receive, inLen);     //重設接收資料的陣列大小，已用 Available 確認實際資料大小故不需再重設

                    string Msg = Encoding.Default.GetString(byte_Receive, 0, int_DataLen);
                    
                    string Str = Encoding.ASCII.GetString(ConvertEBCDICToASCII(byte_Receive)); //EBCDIC 轉回 ASCII

                    Str = Str.Replace("\0", "");
                    string FileType = "";
                    string FileName = "";
                    if (Str.Length>=21)
                    {
                        FileType = Str.Substring(7, 4);
                        FileName = Str.Substring(7, 14);
                    }

                    switch (FileType) //依檔案種類執行功能
                    {
                        case "T067":
                        case "T167":
                        case "T068":
                        case "T168":
                        case "T112":
                        case "T120":
                        case "T140":
                            showTextBoxInformation("FileType=>" + FileType);
                            showTextBoxInformation("FileName=>" + FileName);
                            break;
                        default:
                            showTextBoxInformation("收到訊息=>" + Msg.ToString().Trim());

                            break;
                    } //switch (FileType)

                    switch (FileType) //依檔案總類執行功能
                    {
                        case "T067":
                        case "T167":
                            showTextBoxInformation("T067 已送出");
                            break;
                        case "T068":
                        case "T168":
                            showTextBoxInformation("T068 已送出");
                            break;
                        case "T112":
                        case "T120":
                            showTextBoxInformation("T112 已送出");
                            break;
                        case "T140":
                            showTextBoxInformation("T140 已送出");
                            break;
                        default:
                            break;
                    } //switch (FileType)
                }
                catch (Exception)
                {
                    return;
                }
            } //while (true)
        }
 
        #endregion
        private void button_MIP_START_Click(object sender, EventArgs e) //MIP Server START
        {
            CheckForIllegalCrossThreadCalls = false;    //忽略跨執行緒處理的錯誤(允許跨執行緒存取變數)
            Thread_Server = new Thread(ServerSub);      //宣告監聽執行緒(副程式ServerSub)
            Thread_Server.IsBackground = true;          //設定為背景執行緒
            Thread_Server.Start();                      //啟動監聽執行緒
            button_MIP_START.Enabled = false;           //讓按鍵無法使用(不能重複啟動伺服器)
            button_MIP_STOP.Enabled = true;             //讓按鍵可以使用(能停止伺服器)
            showTextBoxInformation("MIP Server START");
            button_MIP_STOP.Focus();
        }
        private void button_MIP_STOP_Click(object sender, EventArgs e) //MIP Server STOP
        {
            try
            {
                button_MIP_STOP.Enabled = false;            //讓按鍵無法使用(不能重複停止伺服器)
                button_MIP_START.Enabled = true;            //讓按鍵無法使用(能啟動伺服器)
                showTextBoxInformation("MIP Server STOP");
                button_MIP_START.Focus();

                TcpListener_Server.Stop();                  //停止監聽執行緒
                Socket_Client.Close();
                GC.Collect();
            }
            catch (Exception)
            {
                return;
            }
        }        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();//關閉所有執行緒
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //送出訊息給連線端
        private void Send(string Str)
        {
            try
            {
                byte[] B = Encoding.Default.GetBytes(Str);     //翻譯字串Str為Byte陣列B
                int ret = Socket_Client.Send(B, 0, B.Length, SocketFlags.None);      //使用連線物件傳送資料
                showTextBoxInformation("送出訊息=>"+ Str);
            }
            catch (Exception ex)
            {
                showTextBoxInformation("尚無Client建立連線，不能送出訊息");
                //showTextBoxInformation(ex.ToString().Trim());
                return;
                //throw;
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            Send(textBox3.Text); //回傳訊息給連線端
        }

        private void button_Send_good_END_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] msg = new byte[20];
                int i = 0;
                while (i < 20)
                {
                    if (i >= 10 && i <= 16)
                    {
                        msg[10] = Convert.ToByte(249);
                        msg[11] = Convert.ToByte(249);
                        msg[12] = Convert.ToByte(248);
                        msg[13] = Convert.ToByte(240);
                        msg[14] = Convert.ToByte(241);
                        msg[15] = Convert.ToByte(240);
                        msg[16] = Convert.ToByte(240);
                    }
                    else
                    {
                        msg[i] = Convert.ToByte(227);
                    }
                    i++;
                }
                Socket_Client.Send(msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("回傳Client失敗；" + ex.ToString()); //連線失敗時顯示訊息
                showTextBoxInformation("回傳Client失敗；" + ex.ToString());
            }
        }

        private void button_Send_bad_END_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] msg = new byte[9];
                msg[0] = Convert.ToByte(227);
                msg[1] = Convert.ToByte(227);
                msg[2] = Convert.ToByte(249);
                msg[3] = Convert.ToByte(249);
                msg[4] = Convert.ToByte(248);
                msg[5] = Convert.ToByte(240);
                msg[6] = Convert.ToByte(241);
                msg[7] = Convert.ToByte(240);
                msg[8] = Convert.ToByte(241);
                Socket_Client.Send(msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("回傳Client失敗；" + ex.ToString()); //連線失敗時顯示訊息
                showTextBoxInformation("回傳Client失敗；" + ex.ToString());
            }
        }

   

        public byte[] ConvertEBCDICToASCII(byte[] byte_ebcdicData)
        {
            //建立編碼ASCII     
            Encoding obj_ascii = Encoding.ASCII;
            //建立編碼EBCDIC   
            Encoding obj_ebcdic = Encoding.GetEncoding("IBM037");
            //Retutn Ascii Data 
            return Encoding.Convert(obj_ebcdic, obj_ascii, byte_ebcdicData);
        }

        private void showTextBoxInformation(string strMsg)
        {
            textBoxInformation.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff ") + strMsg + "\r\n" + textBoxInformation.Text;
        }

    }
}
