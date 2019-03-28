using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectLoader.Forms
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            tbIP.Text = ConfigHelper.GetAppConfig("ServerIP") != null ? ConfigHelper.GetAppConfig("ServerIP") : "127.0.0.1";
            tbUser.Text = ConfigHelper.GetAppConfig("user") != null ? ConfigHelper.GetAppConfig("user") : "roott";
            tbPwd.Text = ConfigHelper.GetAppConfig("password") != null ? ConfigHelper.GetAppConfig("password") : "123123";
            tbDBName.Text = ConfigHelper.GetAppConfig("DataBase") != null ? ConfigHelper.GetAppConfig("DataBase") : "ShenBaoDB";
            tbFileDir.Text = ConfigHelper.GetAppConfig("LoclDirs") != null ? ConfigHelper.GetAppConfig("LoclDirs") : "C:\\FuJianMuLu";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (fbdDialog.ShowDialog() == DialogResult.OK)
            {
                tbFileDir.Text = fbdDialog.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool TestMysqlConnection()
        {
            string connStr = "server=" + tbIP.Text + ";port=3306;user=" + tbUser.Text + ";password=" + tbPwd.Text + "; database=" + tbDBName.Text + ";";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbFileDir.Text))
            {
                MessageBox.Show("对不起，请选择附件文件路径！");
                return;
            }

            if (!TestMysqlConnection())
            {
                MessageBox.Show("对不起，MySQL数据库无法连接！");
                return;
            }

            ConfigHelper.UpdateAppConfig("ServerIP", tbIP.Text);
            ConfigHelper.UpdateAppConfig("user", tbUser.Text);
            ConfigHelper.UpdateAppConfig("password", tbPwd.Text);
            ConfigHelper.UpdateAppConfig("DataBase", tbDBName.Text);
            ConfigHelper.UpdateAppConfig("LoclDirs", tbFileDir.Text);

            DialogResult = DialogResult.OK;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (TestMysqlConnection())
            {
                MessageBox.Show("连接成功！");
            }
            else
            {
                MessageBox.Show("连接失败！");
            }
        }
    }
}