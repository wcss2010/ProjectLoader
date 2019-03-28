using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Noear.Weed;
using ProjectLoader.DB;
using System.Configuration;
using System.IO;
using ProjectLoader.SQLiteDB;
using ProjectLoader.SQLiteDB.Entitys;
using ProjectLoader.Util;
using System.Text.RegularExpressions;
using ProjectLoader.Forms;
using System.Diagnostics;

namespace ProjectLoader
{
    public partial class MainForm : Form
    {
        public static string DataDir = Path.Combine(Application.StartupPath, "Data");

        public static string FileDir = Path.Combine("C:\\", "HuiZongFiles");

        public static Dictionary<string, string> MoneyNameDict = new Dictionary<string, string>();

        public static Dictionary<string, int> MoneyIndexDict = new Dictionary<string, int>();

        public static MainForm Instance { get; set; }

        private BackgroundWorker _worker = new BackgroundWorker();

        public DiffForm DiffFormObj { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Instance = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string localDirs = ConfigHelper.GetAppConfig("LoclDirs");
            if (string.IsNullOrEmpty(localDirs))
            {
                FileDir = Path.Combine("C:\\", "HuiZongFiles");
            }
            else
            {
                FileDir = localDirs;
            }

            try
            {
                Directory.CreateDirectory(DataDir);
            }
            catch (Exception ex) { }

            try
            {
                Directory.CreateDirectory(FileDir);
            }
            catch (Exception ex) { }

            //初始化资金名称字典
            InitMoneyNameDict();

            //刷新目录
            UpdateProjectList();

            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
        }

        private void InitMoneyNameDict()
        {
            //NameDict
            MoneyNameDict.Add("Projectoutlay1", "年度申请经费预算-第1年");
            MoneyNameDict.Add("Projectoutlay2", "年度申请经费预算-第2年");
            MoneyNameDict.Add("Projectoutlay3", "年度申请经费预算-第3年");
            MoneyNameDict.Add("Projectoutlay4", "年度申请经费预算-第4年");
            MoneyNameDict.Add("Projectoutlay5", "年度申请经费预算-第5年");
            MoneyNameDict.Add("ProjectRFA", "项目总经费");
            MoneyNameDict.Add("ProjectRFA1", "直接费用");
            MoneyNameDict.Add("ProjectRFA1_1", "设备费");
            MoneyNameDict.Add("ProjectRFA1_1_1", "设备购置费");
            MoneyNameDict.Add("ProjectRFA1_1_2", "设备试制费");
            MoneyNameDict.Add("ProjectRFA1_1_3", "其他");
            MoneyNameDict.Add("ProjectRFA1_2", "材料费");
            MoneyNameDict.Add("ProjectRFA1_3", "外部协作费");
            MoneyNameDict.Add("ProjectRFA1_4", "燃料动力费");
            MoneyNameDict.Add("ProjectRFA1_5", "会议/差旅/国际合作与交流费");
            MoneyNameDict.Add("ProjectRFA1_6", "出版/文献/信息传播/知识产权事务费");
            MoneyNameDict.Add("ProjectRFA1_7", "劳务费");
            MoneyNameDict.Add("ProjectRFA1_8", "专家咨询费");
            MoneyNameDict.Add("ProjectRFA1_9", "其他支出");
            MoneyNameDict.Add("ProjectRFA2", "间接费用");
            MoneyNameDict.Add("ProjectRFA2_1", "管理费/科研绩效支出");
            MoneyNameDict.Add("ProjectZiChouJingFei", "自筹经费");

            //IndexDict
            MoneyIndexDict.Add("ProjectZiChouJingFei", 0);
            MoneyIndexDict.Add("Projectoutlay1", 1);
            MoneyIndexDict.Add("Projectoutlay2", 2);
            MoneyIndexDict.Add("Projectoutlay3", 3);
            MoneyIndexDict.Add("Projectoutlay4", 4);
            MoneyIndexDict.Add("Projectoutlay5", 5);
            MoneyIndexDict.Add("ProjectRFA", 6);
            MoneyIndexDict.Add("ProjectRFA1", 7);
            MoneyIndexDict.Add("ProjectRFA1_1",8);
            MoneyIndexDict.Add("ProjectRFA1_1_1", 9);
            MoneyIndexDict.Add("ProjectRFA1_1_2", 10);
            MoneyIndexDict.Add("ProjectRFA1_1_3", 11);
            MoneyIndexDict.Add("ProjectRFA1_2", 12);
            MoneyIndexDict.Add("ProjectRFA1_3", 13);
            MoneyIndexDict.Add("ProjectRFA1_4", 14);
            MoneyIndexDict.Add("ProjectRFA1_5", 15);
            MoneyIndexDict.Add("ProjectRFA1_6", 16);
            MoneyIndexDict.Add("ProjectRFA1_7", 17);
            MoneyIndexDict.Add("ProjectRFA1_8", 18);
            MoneyIndexDict.Add("ProjectRFA1_9", 19);
            MoneyIndexDict.Add("ProjectRFA2", 20);
            MoneyIndexDict.Add("ProjectRFA2_1", 21);            
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Directory.Exists(DataDir) && File.Exists(Path.Combine(DataDir, "projectList.lst")))
            {
                string[] dirs = File.ReadAllLines(Path.Combine(DataDir, "projectList.lst"));
                foreach (string destDir in dirs)
                {
                    if (string.IsNullOrEmpty(destDir))
                    {
                        continue;
                    }

                    string dbFile = Path.Combine(destDir, "static.db");
                    if (File.Exists(dbFile))
                    {
                        //是否退出
                        if (_worker.CancellationPending)
                        {
                            break;
                        }

                        try
                        {
                            if (IsHandleCreated)
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                                    {
                                        string temp = dgvRow.Tag != null ? dgvRow.Tag.ToString() : string.Empty;

                                        if (temp == destDir)
                                        {
                                            dgvRow.Cells[dgvRow.Cells.Count - 2].Value = "上传中...";
                                            break;
                                        }
                                    }
                                }));
                            }

                            //上传数据
                            ImportData(dbFile);

                            if (IsHandleCreated)
                            {
                                Invoke(new MethodInvoker(delegate ()
                                {
                                    foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                                    {
                                        string temp = dgvRow.Tag != null ? dgvRow.Tag.ToString() : string.Empty;

                                        if (temp == destDir)
                                        {
                                            dgvRow.Cells[dgvRow.Cells.Count - 2].Value = "上传完成";
                                            break;
                                        }
                                    }
                                }));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("上传失败！Ex:" + ex.ToString());
                            break;
                        }
                    }
                }

                if (IsHandleCreated)
                {
                    Invoke(new MethodInvoker(delegate ()
                    {
                        btnLoadAll.Enabled = true;
                        btnUploadAll.Enabled = true;
                        btnStopUploadAll.Enabled = false;
                    }));
                }
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            if (ofdZip.ShowDialog() == DialogResult.OK)
            {
                List<string> projectList = new List<string>();
                if (File.Exists(Path.Combine(DataDir, "projectList.lst")))
                {
                    projectList.AddRange(File.ReadAllLines(Path.Combine(DataDir, "projectList.lst")));
                }

                foreach (string s in ofdZip.FileNames)
                {
                    //生成本地目录
                    FileInfo fi = new FileInfo(s);
                    string destDir = Path.Combine(DataDir, fi.Name.Replace(".zip", string.Empty) + "_" + DateTime.Now.Ticks);

                    //解压需要导入的包
                    FileZipOpr fzo = new FileZipOpr();
                    fzo.UnZipFile(s, destDir, string.Empty, true);

                    projectList.Add(destDir);
                    File.WriteAllLines(Path.Combine(DataDir, "projectList.lst"), projectList.ToArray());

                    UpdateProjectList();
                }
            }
        }

        private void UpdateProjectList()
        {
            if (Directory.Exists(DataDir) && File.Exists(Path.Combine(DataDir, "projectList.lst")))
            {
                string[] dirs = File.ReadAllLines(Path.Combine(DataDir, "projectList.lst"));
                dgvDetail.Rows.Clear();
                foreach (string destDir in dirs)
                {
                    string dbFile = Path.Combine(destDir, "static.db");
                    if (File.Exists(dbFile))
                    {
                        SQLiteConnManager.Open(dbFile);
                        List<object> cells = new List<object>();

                        try
                        {
                            Project proj = SQLiteConnManager.Context.table("Project").where("ParentID is null or ParentID = ''").select("*").getItem<Project>(new Project());
                            Unit unitObj = SQLiteConnManager.Context.table("Unit").where("ID = '" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                            Task taskObj = SQLiteConnManager.Context.table("Task").where("Type='" + "项目" + "' and Role = '" + "负责人" + "' and ProjectId = '" + proj.ID + "'").select("*").getItem<Task>(new Task());
                            Person projectMasterPerson = SQLiteConnManager.Context.table("Person").where("ID = '" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());

                            cells.Add(proj.Name);
                            cells.Add(unitObj.UnitName);
                            cells.Add(unitObj.Address);
                            cells.Add(unitObj.ContactName);
                            cells.Add(unitObj.Telephone);
                            cells.Add(projectMasterPerson.Name);
                            cells.Add(projectMasterPerson.Telephone);
                            cells.Add(proj.TotalTime);
                            cells.Add(proj.TotalMoney);
                            cells.Add("等待上传");

                            int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                            dgvDetail.Rows[rowIndex].Tag = destDir;
                        }
                        finally
                        {
                            SQLiteConnManager.Close();
                        }
                    }
                }
            }
        }

        private void btnUploadAll_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (_worker.IsBusy)
                {
                    return;
                }

                DiffFormObj = new DiffForm();
                if (DiffFormObj.TryShowDialog() == DialogResult.OK)
                {
                    btnLoadAll.Enabled = false;
                    btnUploadAll.Enabled = false;
                    btnStopUploadAll.Enabled = true;

                    foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                    {
                        if (dgvRow.Tag != null)
                        {
                            dgvRow.Cells[dgvRow.Cells.Count - 2].Value = "等待上传";
                        }
                    }

                    _worker.RunWorkerAsync();
                }
            }
        }

        public static void ImportData(string tempSqliteFile)
        {
            //打开SQLite数据库连接
            System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
            DbContext context = new DbContext("main", "Data Source=" + tempSqliteFile, factory);
            context.IsSupportInsertAfterSelectIdentity = false;

            string destFileDir = string.Empty;

            //ConnManager.Context.tran((t) =>
            //{
            try
            {
                //DbContext mysqlDBContext = t.db();
                DbContext mysqlDBContext = ConnManager.Context;

                //导入数据
                //Unit Person Project
                List<Unit> unitList = context.table("Unit").select("*").getList<Unit>(new Unit());
                List<Person> personList = context.table("Person").select("*").getList<Person>(new Person());
                List<Project> projectList = context.table("Project").select("*").getList<Project>(new Project());

                DataItem updateDataObj = null;

                //新旧ID字典
                Dictionary<string, string> unitIDDict = new Dictionary<string, string>();
                Dictionary<string, string> personIDDict = new Dictionary<string, string>();
                Dictionary<string, string> projectIDDict = new Dictionary<string, string>();
                string mainProjectID = string.Empty;

                #region 更新或插入单位和人员
                //更新或插入单位信息
                foreach (Unit u in unitList)
                {
                    string itemID = mysqlDBContext.table("d_unit").where("name='" + u.UnitName + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(itemID))
                    {
                        string newID = Guid.NewGuid().ToString();
                        unitIDDict[u.ID] = newID;
                        u.ID = newID;

                        //向MySql插入数据
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", u.ID);
                        updateDataObj.set("name", u.UnitName);
                        updateDataObj.set("sealname", u.FlagName);
                        updateDataObj.set("nickname", u.NormalName);
                        updateDataObj.set("address", u.Address);
                        updateDataObj.set("linkman", u.ContactName);
                        updateDataObj.set("linknum", u.Telephone);
                        updateDataObj.set("secgrade", u.SecretQualification);
                        mysqlDBContext.table("d_unit").insert(updateDataObj);
                    }
                    else
                    {
                        string newID = itemID;
                        unitIDDict[u.ID] = newID;
                        u.ID = newID;

                        if (MainForm.Instance.DiffFormObj.IsAcceptUpdate("单位信息", u.ID))
                        {
                            //向MySql插入数据
                            updateDataObj = new DataItem();
                            updateDataObj.set("id", u.ID);
                            updateDataObj.set("name", u.UnitName);
                            updateDataObj.set("sealname", u.FlagName);
                            updateDataObj.set("nickname", u.NormalName);
                            updateDataObj.set("address", u.Address);
                            updateDataObj.set("linkman", u.ContactName);
                            updateDataObj.set("linknum", u.Telephone);
                            updateDataObj.set("secgrade", u.SecretQualification);
                            mysqlDBContext.table("d_unit").where("id='" + u.ID + "'").update(updateDataObj);
                        }
                    }
                }

                //更新或插入人员信息
                foreach (Person p in personList)
                {
                    //查找UnitID
                    if (unitIDDict.ContainsKey(p.UnitID))
                    {
                        p.UnitID = unitIDDict[p.UnitID];
                    }
                    else
                    {
                        continue;
                    }

                    string itemID = mysqlDBContext.table("d_person").where("id='" + p.IDCard + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(itemID))
                    {
                        string newID = p.IDCard;
                        personIDDict[p.ID] = newID;
                        p.ID = newID;


                        //向MySql插入数据
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", p.ID);
                        updateDataObj.set("name", p.Name);
                        updateDataObj.set("post", p.Job);
                        updateDataObj.set("specialty", p.Specialty);
                        updateDataObj.set("gender", p.Sex);
                        updateDataObj.set("birthday", p.Birthday);
                        updateDataObj.set("phone", p.Telephone);
                        updateDataObj.set("mobilephone", p.MobilePhone);
                        updateDataObj.set("address", p.Address);
                        updateDataObj.set("unitid", p.UnitID);
                        mysqlDBContext.table("d_person").insert(updateDataObj);
                    }
                    else
                    {
                        string newID = itemID;
                        personIDDict[p.ID] = newID;
                        p.ID = newID;

                        if (MainForm.Instance.DiffFormObj.IsAcceptUpdate("人员信息", p.ID))
                        {
                            //向MySql插入数据
                            updateDataObj = new DataItem();
                            updateDataObj.set("id", p.ID);
                            updateDataObj.set("name", p.Name);
                            updateDataObj.set("post", p.Job);
                            updateDataObj.set("specialty", p.Specialty);
                            updateDataObj.set("gender", p.Sex);
                            updateDataObj.set("birthday", p.Birthday);
                            updateDataObj.set("phone", p.Telephone);
                            updateDataObj.set("mobilephone", p.MobilePhone);
                            updateDataObj.set("address", p.Address);
                            updateDataObj.set("unitid", p.UnitID);
                            mysqlDBContext.table("d_person").where("id='" + p.ID + "'").update(updateDataObj);
                        }
                    }
                }
                #endregion

                #region 更新或插入项目与课题信息
                //更新或插入项目信息
                foreach (Project proj in projectList)
                {
                    if (string.IsNullOrEmpty(proj.ParentID))
                    {
                        if (unitIDDict.ContainsKey(proj.UnitID))
                        {
                            proj.UnitID = unitIDDict[proj.UnitID];
                        }

                        string projectID = mysqlDBContext.table("d_xm").where("id='" + proj.ID + "'").select("id").getValue<string>(string.Empty);
                        if (string.IsNullOrEmpty(projectID))
                        {
                            projectIDDict[proj.ID] = proj.ID;
                            destFileDir = proj.ID;

                            //Update To MySql
                            updateDataObj = new DataItem();
                            updateDataObj.set("name", proj.Name);
                            updateDataObj.set("id", proj.ID);
                            updateDataObj.set("sec_grade", proj.SecretLevel);
                            updateDataObj.set("type", proj.Type);
                            updateDataObj.set("category", "重大项目");
                            updateDataObj.set("pid", proj.ParentID);
                            updateDataObj.set("unitid", proj.UnitID);
                            updateDataObj.set("time", proj.TotalTime);
                            updateDataObj.set("outlay", proj.TotalMoney);
                            updateDataObj.set("year", 0);
                            updateDataObj.set("keyword", proj.Keywords);
                            updateDataObj.set("dirname", destFileDir);
                            updateDataObj.set("importtime", DateTime.Now);

                            mysqlDBContext.table("d_xm").insert(updateDataObj);
                        }
                        else
                        {
                            projectIDDict[proj.ID] = projectID;
                            proj.ID = projectID;
                            destFileDir = proj.ID;

                            //Update To MySql
                            updateDataObj = new DataItem();
                            updateDataObj.set("name", proj.Name);
                            updateDataObj.set("id", proj.ID);
                            updateDataObj.set("sec_grade", proj.SecretLevel);
                            updateDataObj.set("type", proj.Type);
                            updateDataObj.set("category", "重大项目");
                            updateDataObj.set("pid", proj.ParentID);
                            updateDataObj.set("unitid", proj.UnitID);
                            updateDataObj.set("time", proj.TotalTime);
                            updateDataObj.set("outlay", proj.TotalMoney);
                            updateDataObj.set("year", 0);
                            updateDataObj.set("keyword", proj.Keywords);
                            updateDataObj.set("dirname", destFileDir);
                            updateDataObj.set("importtime", DateTime.Now);

                            mysqlDBContext.table("d_xm").where("id='" + proj.ID + "'").update(updateDataObj);
                        }

                        mainProjectID = proj.ID;
                        break;
                    }
                }

                //更新或插入课题信息
                foreach (Project proj in projectList)
                {
                    if (string.IsNullOrEmpty(proj.ParentID))
                    {
                        continue;
                    }

                    if (unitIDDict.ContainsKey(proj.UnitID))
                    {
                        proj.UnitID = unitIDDict[proj.UnitID];
                    }

                    if (projectIDDict.ContainsKey(proj.ParentID))
                    {
                        proj.ParentID = projectIDDict[proj.ParentID];
                    }

                    string projectID = mysqlDBContext.table("d_xm").where("id='" + proj.ID + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(projectID))
                    {
                        projectIDDict[proj.ID] = proj.ID;


                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("name", proj.Name);
                        updateDataObj.set("id", proj.ID);
                        updateDataObj.set("sec_grade", proj.SecretLevel);
                        updateDataObj.set("type", proj.Type);
                        updateDataObj.set("category", "重大项目");
                        updateDataObj.set("pid", proj.ParentID);
                        updateDataObj.set("unitid", proj.UnitID);
                        updateDataObj.set("time", proj.TotalTime);
                        updateDataObj.set("outlay", proj.TotalMoney);
                        updateDataObj.set("year", 0);
                        updateDataObj.set("keyword", proj.Keywords);
                        updateDataObj.set("dirname", null);
                        updateDataObj.set("importtime", DateTime.Now);

                        mysqlDBContext.table("d_xm").insert(updateDataObj);
                    }
                    else
                    {
                        projectIDDict[proj.ID] = projectID;

                        proj.ID = projectID;


                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("name", proj.Name);
                        updateDataObj.set("id", proj.ID);
                        updateDataObj.set("sec_grade", proj.SecretLevel);
                        updateDataObj.set("type", proj.Type);
                        updateDataObj.set("category", "重大项目");
                        updateDataObj.set("pid", proj.ParentID);
                        updateDataObj.set("unitid", proj.UnitID);
                        updateDataObj.set("time", proj.TotalTime);
                        updateDataObj.set("outlay", proj.TotalMoney);
                        updateDataObj.set("year", 0);
                        updateDataObj.set("keyword", proj.Keywords);
                        updateDataObj.set("dirname", null);
                        updateDataObj.set("importtime", DateTime.Now);

                        mysqlDBContext.table("d_xm").where("id='" + proj.ID + "'").update(updateDataObj);
                    }
                }
                #endregion

                #region 更新联系人-阶段-经费数据
                List<Task> taskList = context.table("Task").select("*").getList<Task>(new Task());
                List<Step> stepList = context.table("Step").select("*").getList<Step>(new Step());
                List<WhiteList> whitelistList = context.table("WhiteList").select("*").getList<WhiteList>(new WhiteList());
                List<ProjectAndStep> projectandstepList = context.table("ProjectAndStep").select("*").getList<ProjectAndStep>(new ProjectAndStep());
                List<MoneyAndYear> moneyandyearList = context.table("MoneyAndYear").select("*").getList<MoneyAndYear>(new MoneyAndYear());

                //新旧ID字典
                Dictionary<string, string> stepIdDicts = new Dictionary<string, string>();

                //更新任务表
                foreach (Task task in taskList)
                {
                    if (projectIDDict.ContainsKey(task.ProjectID))
                    {
                        task.ProjectID = projectIDDict[task.ProjectID];
                    }

                    if (personIDDict.ContainsKey(task.PersonID))
                    {
                        task.PersonID = personIDDict[task.PersonID];
                    }

                    string taskID = mysqlDBContext.table("r_job").where("id='" + task.ID + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(taskID))
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", task.ID);
                        updateDataObj.set("xmid", task.ProjectID);
                        updateDataObj.set("personid", task.PersonID);
                        updateDataObj.set("fengong", task.Content);
                        updateDataObj.set("time", task.TotalTime);
                        updateDataObj.set("post", task.Role);
                        mysqlDBContext.table("r_job").insert(updateDataObj);
                    }
                    else
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", task.ID);
                        updateDataObj.set("xmid", task.ProjectID);
                        updateDataObj.set("personid", task.PersonID);
                        updateDataObj.set("fengong", task.Content);
                        updateDataObj.set("time", task.TotalTime);
                        updateDataObj.set("post", task.Role);
                        mysqlDBContext.table("r_job").where("id='" + task.ID + "'").update(updateDataObj);
                    }
                }

                //更新候选单位表
                //foreach (WhiteList wl in whitelistList)
                //{
                //    if (projectIDDict.ContainsKey(wl.ProjectID))
                //    {
                //        wl.ProjectID = projectIDDict[wl.ProjectID];
                //    }

                //    if (unitIDDict.ContainsKey(wl.UnitID))
                //    {
                //        wl.UnitID = unitIDDict[wl.UnitID];
                //    }

                //    string wlID = ConnectionManager.Context.table("WhiteList").where("id='" + wl.ID + "'").select("id").getValue<string>(string.Empty);
                //    if (string.IsNullOrEmpty(wlID))
                //    {
                //        //Update To MySql
                //        updateDataObj = new DataItem();
                //        updateDataObj.set("", null);
                //        mysqlDBContext.table("d_person").insert(updateDataObj);

                //        wl.copyTo(ConnectionManager.Context.table("WhiteList")).insert();
                //    }
                //    else
                //    {
                //        //Update To MySql
                //        updateDataObj = new DataItem();
                //        updateDataObj.set("", null);
                //        mysqlDBContext.table("d_person").insert(updateDataObj);

                //        wl.copyTo(ConnectionManager.Context.table("WhiteList")).where("id='" + wl.ID + "'").update();
                //    }
                //}

                //更新阶段表
                foreach (Step step in stepList)
                {
                    if (projectIDDict.ContainsKey(step.ProjectID))
                    {
                        step.ProjectID = projectIDDict[step.ProjectID];
                    }

                    stepIdDicts[step.ID] = step.ID;

                    string wlID = mysqlDBContext.table("d_phase").where("id='" + step.ID + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(wlID))
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", step.ID);
                        updateDataObj.set("xmid", step.ProjectID);
                        updateDataObj.set("aim", step.StepDest);
                        updateDataObj.set("num", step.StepIndex);
                        updateDataObj.set("outlay", step.StepMoney);
                        updateDataObj.set("time", step.StepTime);

                        mysqlDBContext.table("d_phase").insert(updateDataObj);
                    }
                    else
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", step.ID);
                        updateDataObj.set("xmid", step.ProjectID);
                        updateDataObj.set("aim", step.StepDest);
                        updateDataObj.set("num", step.StepIndex);
                        updateDataObj.set("outlay", step.StepMoney);
                        updateDataObj.set("time", step.StepTime);

                        mysqlDBContext.table("d_phase").where("id='" + step.ID + "'").update(updateDataObj);
                    }
                }

                //更新工程阶段表
                foreach (ProjectAndStep pas in projectandstepList)
                {
                    if (stepIdDicts.ContainsKey(pas.StepID))
                    {
                        pas.StepID = stepIdDicts[pas.StepID];
                    }

                    string wlID = mysqlDBContext.table("r_xm_phase").where("id='" + pas.ID + "'").select("id").getValue<string>(string.Empty);
                    if (string.IsNullOrEmpty(wlID))
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", pas.ID);
                        updateDataObj.set("phaseid", pas.StepID);
                        updateDataObj.set("content", pas.StepContent);
                        updateDataObj.set("effect", pas.StepResult);
                        updateDataObj.set("mode", pas.Method);
                        updateDataObj.set("outlay", pas.Money);

                        mysqlDBContext.table("r_xm_phase").insert(updateDataObj);
                    }
                    else
                    {
                        //Update To MySql
                        updateDataObj = new DataItem();
                        updateDataObj.set("id", pas.ID);
                        updateDataObj.set("phaseid", pas.StepID);
                        updateDataObj.set("content", pas.StepContent);
                        updateDataObj.set("effect", pas.StepResult);
                        updateDataObj.set("mode", pas.Method);
                        updateDataObj.set("outlay", pas.Money);

                        mysqlDBContext.table("r_xm_phase").where("id='" + pas.ID + "'").update(updateDataObj);
                    }
                }

                //更新经费表
                foreach (MoneyAndYear may in moneyandyearList)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(may.Name) || may.Name.EndsWith("rm") || may.Name.EndsWith("zb"))
                        {
                            continue;
                        }

                        if (projectIDDict.ContainsKey(may.ProjectID))
                        {
                            may.ProjectID = projectIDDict[may.ProjectID];
                        }

                        string wlID = mysqlDBContext.table("d_outlay").where("id='" + may.ID + "'").select("id").getValue<string>(string.Empty);
                        if (string.IsNullOrEmpty(wlID))
                        {
                            //Update To MySql
                            updateDataObj = new DataItem();
                            updateDataObj.set("id", may.ID);
                            updateDataObj.set("name", GetMoneyName(may.Name));
                            updateDataObj.set("content", string.IsNullOrEmpty(may.Value) ? 0 : double.Parse(may.Value));
                            updateDataObj.set("xmid", may.ProjectID);
                            updateDataObj.set("num", GetMoneyNum(may.Name));
                            updateDataObj.set("grade", GetMoneyStep(may.Name));

                            mysqlDBContext.table("d_outlay").insert(updateDataObj);
                        }
                        else
                        {
                            //Update To MySql
                            updateDataObj = new DataItem();
                            updateDataObj.set("id", may.ID);
                            updateDataObj.set("name", GetMoneyName(may.Name));
                            updateDataObj.set("content", string.IsNullOrEmpty(may.Value) ? 0 : double.Parse(may.Value));
                            updateDataObj.set("xmid", may.ProjectID);
                            updateDataObj.set("num", GetMoneyNum(may.Name));
                            updateDataObj.set("grade", GetMoneyStep(may.Name));

                            mysqlDBContext.table("d_outlay").where("id='" + may.ID + "'").update(updateDataObj);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }

                #endregion

                #region 复制所有的附件到本地目录
                string destDir = Path.Combine(MainForm.FileDir, destFileDir);
                try
                {
                    Directory.CreateDirectory(destDir);
                }
                catch (Exception ex) { }

                string fileDir = Path.Combine(new FileInfo(tempSqliteFile).DirectoryName, "Files");
                string[] filessss = Directory.GetFiles(fileDir);
                if (filessss != null)
                {
                    foreach (string f in filessss)
                    {
                        FileInfo fi = new FileInfo(f);

                        if (File.Exists(Path.Combine(destDir, fi.Name)))
                        {
                            //删除原来的文件
                            File.Delete(Path.Combine(destDir, fi.Name));
                        }

                        //复制文件到目标目录
                        File.Copy(f, Path.Combine(destDir, fi.Name));
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭数据库
                factory.Dispose();
                factory = null;
                context = null;
            }
            //});
        }

        private static string GetMoneyStep(string name)
        {
            int ccc = Regex.Matches(name, "_").Count;

            switch (ccc)
            {
                case 0:
                    return "1";
                case 1:
                    return "2";
                case 2:
                    return "3";
                default:
                    return "1";
            }
        }

        private static string GetMoneyName(string moneyKey)
        {
            if (MoneyNameDict.ContainsKey(moneyKey))
            {
                return MoneyNameDict[moneyKey];
            }
            else
            {
                return moneyKey;
            }
        }

        private static int GetMoneyNum(string moneyKey)
        {
            if (MoneyIndexDict.ContainsKey(moneyKey))
            {
                return MoneyIndexDict[moneyKey];
            }
            else
            {
                return -1;
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
            {
                string destDir = dgvDetail.Rows[e.RowIndex].Tag != null ? dgvDetail.Rows[e.RowIndex].Tag.ToString() : string.Empty;
                if (string.IsNullOrEmpty(destDir))
                {
                    return;
                }

                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (File.Exists(Path.Combine(DataDir, "projectList.lst")))
                    {
                        List<string> temps = new List<string>(File.ReadAllLines(Path.Combine(DataDir, "projectList.lst")));
                        temps.Remove(destDir);

                        File.WriteAllLines(Path.Combine(DataDir, "projectList.lst"), temps.ToArray());
                    }

                    UpdateProjectList();
                }
            }
        }

        private void btnStopUploadAll_Click(object sender, EventArgs e)
        {
            _worker.CancelAsync();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm cf = new ConfigForm();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }
    }
}