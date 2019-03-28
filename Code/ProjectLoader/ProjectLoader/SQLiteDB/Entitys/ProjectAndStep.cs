using System;
using System.Data;
using System.Text;

namespace ProjectLoader.SQLiteDB.Entitys
{
    /// <summary>
    /// 类ProjectAndStep。
    /// </summary>
    [Serializable]
    public partial class ProjectAndStep : IEntity
    {
        public ProjectAndStep() { }

        public override Noear.Weed.DbTableQuery copyTo(Noear.Weed.DbTableQuery query)
        {
            //设置值
            query.set("ID", ID);
            query.set("StepID", StepID);
            query.set("StepContent", StepContent);
            query.set("StepResult", StepResult);
            query.set("Method", Method);
            query.set("Money", Money);

            return query;
        }

        #region Model
        private string _id;
        private string _stepid;
        private string _stepcontent;
        private string _stepresult;
        private string _method;
        private decimal? _money;
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
        public string StepID
        {
            set { _stepid = value; }
            get { return _stepid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StepContent
        {
            set { _stepcontent = value; }
            get { return _stepcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StepResult
        {
            set { _stepresult = value; }
            get { return _stepresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Method
        {
            set { _method = value; }
            get { return _method; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Money
        {
            set { _money = value; }
            get { return _money; }
        }
        #endregion Model

        public override void bind(Noear.Weed.GetHandlerEx source)
        {
            ID = source("ID").value<string>(Guid.NewGuid().ToString());
            StepID = source("StepID").value<string>(string.Empty);
            StepContent = source("StepContent").value<string>(string.Empty);
            StepResult = source("StepResult").value<string>(string.Empty);
            Method = source("Method").value<string>(string.Empty);
            Money = source("Money").value<decimal>(0);
        }

        public override Noear.Weed.IBinder clone()
        {
            return new ProjectAndStep();
        }
    }
}