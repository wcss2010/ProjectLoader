using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类Step。
    /// </summary>
    [Serializable]
    public partial class Step : IEntity
    {
        public Step() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("ProjectID", ProjectID);
            query.set("StepTime", StepTime);
            query.set("StepDest", StepDest);
            query.set("StepMoney", StepMoney);
            query.set("StepIndex", StepIndex);

            return query;
        }

        #region Model
        private string _id;
        private string _projectid;
        private int? _steptime;
        private string _stepdest;
        private decimal? _stepmoney;
        private int? _StepIndex;
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
        public int? StepTime
        {
            set { _steptime = value; }
            get { return _steptime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StepDest
        {
            set { _stepdest = value; }
            get { return _stepdest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? StepMoney
        {
            set { _stepmoney = value; }
            get { return _stepmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? StepIndex
        {
            set { _StepIndex = value; }
            get { return _StepIndex; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            ProjectID = source("ProjectID").value<string>(string.Empty);
            StepTime = source("StepTime").value<int>(0);
            StepDest = source("StepDest").value<string>(string.Empty);
            StepMoney = source("StepMoney").value<decimal>(0);
            StepIndex = source("StepIndex").value<int>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new Step();
        }
    }
}