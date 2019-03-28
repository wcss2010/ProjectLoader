using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类Unit。
    /// </summary>
    [Serializable]
    public partial class Unit : IEntity
    {
        public Unit() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("UnitName", UnitName);
            query.set("FlagName", FlagName);
            query.set("NormalName", NormalName);
            query.set("Address", Address);
            query.set("ContactName", ContactName);
            query.set("Telephone", Telephone);
            query.set("SecretQualification", SecretQualification);

            return query;
        }

        #region Model
        private string _id;
        private string _unitname;
        private string _flagname;
        private string _normalname;
        private string _address;
        private string _contactname;
        private string _telephone;
        private string _secretqualification;
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
        public string UnitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FlagName
        {
            set { _flagname = value; }
            get { return _flagname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NormalName
        {
            set { _normalname = value; }
            get { return _normalname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContactName
        {
            set { _contactname = value; }
            get { return _contactname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SecretQualification
        {
            set { _secretqualification = value; }
            get { return _secretqualification; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            UnitName = source("UnitName").value<string>(string.Empty);
            FlagName = source("FlagName").value<string>(string.Empty);
            NormalName = source("NormalName").value<string>(string.Empty);
            Address = source("Address").value<string>(string.Empty);
            ContactName = source("ContactName").value<string>(string.Empty);
            Telephone = source("Telephone").value<string>(string.Empty);
            SecretQualification = source("SecretQualification").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Unit();
        }
    }
}