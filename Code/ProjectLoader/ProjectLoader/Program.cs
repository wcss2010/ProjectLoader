using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjectLoader.DB;

namespace ProjectLoader
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //初始化数据库
            string serverIP = ConfigHelper.GetAppConfig("ServerIP");
            string db = ConfigHelper.GetAppConfig("DataBase");
            string user = ConfigHelper.GetAppConfig("user");
            string password = ConfigHelper.GetAppConfig("password");
            ConnManager.Open(serverIP, user, password, db);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            if (ConnManager.Context != null)
            {
                ConnManager.Close();
            }
        }
    }
}