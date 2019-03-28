using System;
using Mono.Data.Sqlite;
using Noear.Weed;

namespace ProjectLoader.SQLiteDB
{
    public class SQLiteConnManager
    {
        private static SqliteFactory factory = null;

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
            factory = new SqliteFactory();
            Context = new DbContext("main", "Data Source=" + dbFile, factory);
            Context.IsSupportInsertAfterSelectIdentity = false;
        }

        public static void Close()
        {
            Context.getConnection().Dispose();            
            //factory.Dispose();
            Context = null;

            GC.WaitForPendingFinalizers();
        }
    }
}