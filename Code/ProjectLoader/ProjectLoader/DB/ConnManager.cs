using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Noear.Weed;

namespace ProjectLoader.DB
{
    public class ConnManager
    {
        private static MySqlClientFactory factory = null;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static DbContext Context { get; set; }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        public static void Open(string ip,string user,string pwd,string dbName)
        {
            factory = new MySqlClientFactory();
            Context = new DbContext(dbName, "server=" + ip + ";port=3306;user=" + user + ";password=" + pwd + ";database=" + dbName + ";Charset=utf8", factory);
            //Context.IsSupportInsertAfterSelectIdentity = false;
        }

        public static void Close()
        {
            Context.getConnection().Dispose();
            factory = null;
            Context = null;
        }
    }
}