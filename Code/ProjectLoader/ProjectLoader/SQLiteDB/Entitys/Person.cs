using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类Person。
    /// </summary>
    [Serializable]
    public partial class Person : IEntity
    {
        public Person() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("IDCard", IDCard);
            query.set("Name", Name);
            query.set("Job", Job);
            query.set("Specialty", Specialty);
            query.set("Sex", Sex);
            query.set("Birthday", Birthday);
            query.set("Telephone", Telephone);
            query.set("MobilePhone", MobilePhone);
            query.set("Address", Address);
            query.set("UnitID", UnitID);

            return query;
        }

        #region Model
        private string _id;
        private string _idcard;
        private string _name;
        private string _job;
        private string _specialty;
        private string _sex;
        private DateTime? _birthday;
        private string _telephone;
        private string _mobilephone;
        private string _address;
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
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
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
        public string Job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Specialty
        {
            set { _specialty = value; }
            get { return _specialty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
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
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
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
        public string UnitID
        {
            set { _unitid = value; }
            get { return _unitid; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            IDCard = source("IDCard").value<string>(string.Empty);
            Name = source("Name").value<string>(string.Empty);
            Job = source("Job").value<string>(string.Empty);
            Specialty = source("Specialty").value<string>(string.Empty);
            Sex = source("Sex").value<string>(string.Empty);
            Birthday = source("Birthday").value<DateTime>(DateTime.Now);
            Telephone = source("Telephone").value<string>(string.Empty);
            MobilePhone = source("MobilePhone").value<string>(string.Empty);
            Address = source("Address").value<string>(string.Empty);
            UnitID = source("UnitID").value<string>(string.Empty);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Person();
        }
    }
}