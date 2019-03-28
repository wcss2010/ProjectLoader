using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类Task。
    /// </summary>
    [Serializable]
    public partial class Task : IEntity
    {
        public Task() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("PersonID", PersonID);
            query.set("Role", Role);
            query.set("Type", Type);
            query.set("Content", Content);
            query.set("TotalTime", TotalTime);
            query.set("IDCard", IDCard);

            return query;
        }

        #region Model
        private string _id;
        private string _projectid;
        private string _personid;
        private string _role;
        private string _type;
        private string _Content;
        private int? _totaltime;
        private string _idcard;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PersonID
        {
            set { _personid = value; }
            get { return _personid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TotalTime
        {
            set { _totaltime = value; }
            get { return _totaltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>(string.Empty);
            PersonID = source("PersonID").value<string>(string.Empty);
            Role = source("Role").value<string>(string.Empty);
            Type = source("Type").value<string>(string.Empty);
            Content = source("Content").value<string>(string.Empty);
            TotalTime = source("TotalTime").value<int>(0);
            IDCard = source("IDCard").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Task();
        }
    }
}