using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类Project。
    /// </summary>
    [Serializable]
    public partial class Project : IEntity
    {
        public Project() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("Name", Name);
            query.set("SecretLevel", SecretLevel);
            query.set("Type", Type);
            query.set("Type2", Type2);
            query.set("ParentID", ParentID);
            query.set("UnitID", UnitID);
            query.set("TotalTime", TotalTime);
            query.set("TotalMoney", TotalMoney);
            query.set("Keywords", Keywords);

            return query;
        }

        #region Model
        private string _id;
        private string _name;
        private string _secretlevel;
        private string _type;
        private string _type2;
        private string _parentid;
        private string _unitid;
        private string _keywords;
        private int? _totaltime;
        private decimal? _totalmoney;

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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecretLevel
        {
            set { _secretlevel = value; }
            get { return _secretlevel; }
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
        public string Type2
        {
            get { return _type2; }
            set { _type2 = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitID
        {
            set { _unitid = value; }
            get { return _unitid; }
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
        public decimal? TotalMoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }

        public string Keywords
        {
            get
            {
                return _keywords;
            }

            set
            {
                _keywords = value;
            }
        }

        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            Name = source("Name").value<string>(string.Empty);
            SecretLevel = source("SecretLevel").value<string>(string.Empty);
            Type = source("Type").value<string>(string.Empty);
            Type2 = source("Type2").value<string>(string.Empty);
            ParentID = source("ParentID").value<string>(string.Empty);
            UnitID = source("UnitID").value<string>(string.Empty);
            TotalTime = source("TotalTime").value<int>(0);
            TotalMoney = source("TotalMoney").value<decimal>(0);
            Keywords = source("Keywords").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Project();
        }
    }
}