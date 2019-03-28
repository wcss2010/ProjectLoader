using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类MoneyAndType。
    /// </summary>
    [Serializable]
    public partial class MoneyAndType : IEntity
    {
        public MoneyAndType() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("ItemData", ItemData);

            return query;
        }

        #region Model
        private string _id;
        private string _projectid;
        private string _itemdata;
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
        public string ItemData
        {
            set { _itemdata = value; }
            get { return _itemdata; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>(string.Empty);
            ItemData = source("ItemData").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new MoneyAndType();
        }
    }
}