using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类MoneyAndYear。
    /// </summary>
    [Serializable]
    public partial class MoneyAndYear : IEntity
    {
        public MoneyAndYear() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("Index", Index);
            query.set("ProjectID", ProjectID);
            query.set("Name", Name);
            query.set("Value", Value);

            return query;
        }

        #region Model
        private string _id;
        private int? _index;
        private string _projectid;
        private string _name;
        private string _value;
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
        public int? Index
        {
            set { _index = value; }
            get { return _index; }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            set { _value = value; }
            get { return _value; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            Index = source("Index").value<int>(0);
            ProjectID = source("ProjectID").value<string>(string.Empty);
            Name = source("Name").value<string>(string.Empty);
            Value = source("Value").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new MoneyAndYear();
        }
    }
}