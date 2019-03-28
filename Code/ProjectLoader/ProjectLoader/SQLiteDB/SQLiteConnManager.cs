using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Noear.Weed;
using ProjectLoader.SQLiteDB.Entitys;

namespace ProjectLoader.SQLiteDB
{
    public class SQLiteConnManager
    {
        private static System.Data.SQLite.SQLiteFactory factory = null;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static DbContext Context { get; set; }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        /// <param name="dbFile"></param>
        public static void Open(string dbFile)
        {
            factory = new System.Data.SQLite.SQLiteFactory();
            Context = new DbContext("main", "Data Source=" + dbFile, factory);
            Context.IsSupportInsertAfterSelectIdentity = false;
        }

        public static void Close()
        {
            Context.getConnection().Dispose();            
            factory.Dispose();
            Context = null;

            GC.WaitForPendingFinalizers();
        }
    }
}