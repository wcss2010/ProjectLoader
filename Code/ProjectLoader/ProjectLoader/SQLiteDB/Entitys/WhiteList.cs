using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Noear.Weed;

namespace ProjectLoader.SQLiteDB.Entitys
{
    public class WhiteList : IEntity
    {
        public WhiteList() { }

        #region Model
        private string _id;
        private string _unitid;
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
        public string UnitID
        {
            set { _unitid = value; }
            get { return _unitid; }
        }

        public string ProjectID { get; set; }

        #endregion Model

        public override DbTableQuery copyTo(DbTableQuery query)
        {
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("UnitID", UnitID);

            return query;
        }

        public override void bind(GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>(string.Empty);
            UnitID = source("UnitID").value<string>(string.Empty);
        }
    }
}