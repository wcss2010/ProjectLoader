using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Noear.Weed;
using ProjectLoader.DB;
using ProjectLoader.SQLiteDB;
using ProjectLoader.SQLiteDB.Entitys;

namespace ProjectLoader.Forms
{
    public partial class DiffForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, List<string>> AcceptDict = new Dictionary<string, List<string>>();

        public DiffForm()
        {
            InitializeComponent();

            ShowDiffList();
        }

        public DialogResult TryShowDialog()
        {
            if (dgvDiff.Rows.Count == 0)
            {
                return DialogResult.OK;
            }
            else
            {
                return ShowDialog();
            }
        }

        protected void ShowDiffList()
        {
            if (Directory.Exists(MainForm.DataDir) && File.Exists(Path.Combine(MainForm.DataDir, "projectList.lst")))
            {
                string[] dirs = File.ReadAllLines(Path.Combine(MainForm.DataDir, "projectList.lst"));
                dgvDiff.Rows.Clear();
                foreach (string destDir in dirs)
                {
                    string dbFile = Path.Combine(destDir, "static.db");
                    if (File.Exists(dbFile))
                    {
                        SQLiteConnManager.Open(dbFile);
                        List<object> cells = new List<object>();

                        try
                        {
                            DataItem updateDataObj = null;
                            string recordId = string.Empty;

                            Project mainProject = SQLiteConnManager.Context.table("Project").where("ParentID is null or ParentID = ''").select("*").getItem<Project>(new Project());
                            List<Person> personList = SQLiteConnManager.Context.table("Person").select("*").getList<Person>(new Person());
                            List<Unit> unitList = SQLiteConnManager.Context.table("Unit").select("*").getList<Unit>(new Unit());

                            //Unit
                            foreach(Unit u in unitList)
                            {
                                DataItem di = ConnManager.Context.table("d_unit").where("name = '" + u.UnitName + "'").select("*").getDataItem();
                                if (di.count() >= 1)
                                {
                                    updateDataObj = new DataItem();
                                    updateDataObj.set("id", u.ID);
                                    updateDataObj.set("name", u.UnitName);
                                    updateDataObj.set("sealname", u.FlagName);
                                    updateDataObj.set("nickname", u.NormalName);
                                    updateDataObj.set("address", u.Address);
                                    updateDataObj.set("linkman", u.ContactName);
                                    updateDataObj.set("linknum", u.Telephone);
                                    updateDataObj.set("secgrade", u.SecretQualification);

                                    recordId = di.getString("id");

                                    updateDataObj.remove("id");
                                    di.remove("id");

                                    if (di.toJson().Equals(updateDataObj.toJson()))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        cells.Clear();
                                        cells.Add(false);
                                        cells.Add(mainProject.Name);
                                        cells.Add("单位信息");
                                        cells.Add(di.toJson());
                                        cells.Add(updateDataObj.toJson());                                        
                                        int rowIndex = dgvDiff.Rows.Add(cells.ToArray());
                                        dgvDiff.Rows[rowIndex].Tag = recordId;
                                    }
                                }
                            }

                            //Person
                            foreach (Person p in personList)
                            {
                                DataItem di = ConnManager.Context.table("d_person").where("id = '" + p.IDCard + "'").select("*").getDataItem();
                                if (di.count() >= 1)
                                {
                                    updateDataObj = new DataItem();
                                    updateDataObj.set("id", p.ID);
                                    updateDataObj.set("name", p.Name);
                                    updateDataObj.set("post", p.Job);
                                    updateDataObj.set("specialty", p.Specialty);
                                    updateDataObj.set("gender", p.Sex);
                                    updateDataObj.set("birthday", p.Birthday != null ? new DateTime(p.Birthday.Value.Year, p.Birthday.Value.Month, p.Birthday.Value.Day, 0, 0, 0) : new DateTime(0, 0, 0, 0, 0, 0));
                                    updateDataObj.set("phone", p.Telephone);
                                    updateDataObj.set("mobilephone", p.MobilePhone);
                                    updateDataObj.set("address", p.Address);
                                    updateDataObj.set("unitid", p.UnitID);

                                    recordId = di.getString("id");

                                    updateDataObj.remove("id");
                                    di.remove("id");
                                    updateDataObj.remove("unitid");
                                    di.remove("unitid");

                                    if (di.toJson().Equals(updateDataObj.toJson()))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        cells.Clear();
                                        cells.Add(false);
                                        cells.Add(mainProject.Name);
                                        cells.Add("人员信息");
                                        cells.Add(di.toJson());
                                        cells.Add(updateDataObj.toJson());
                                        
                                        int rowIndex = dgvDiff.Rows.Add(cells.ToArray());
                                        dgvDiff.Rows[rowIndex].Tag = recordId;
                                    }
                                }
                            }
                        }
                        finally
                        {
                            SQLiteConnManager.Close();
                        }
                    }
                }
            }
        }

        public bool IsAcceptUpdate(string type,string id)
        {
            if (AcceptDict.ContainsKey(type))
            {
                if (AcceptDict[type] != null)
                {
                    return AcceptDict[type].Contains(id);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvDiff.Rows)
            {
                if (dgvRow.Cells[1].Value == null)
                {
                    continue;
                }
                else
                {
                    bool isAccept = (bool)dgvRow.Cells[0].Value;
                    string type = dgvRow.Cells[2].Value != null ? dgvRow.Cells[2].Value.ToString() : string.Empty;
                    string id = dgvRow.Tag != null ? dgvRow.Tag.ToString() : string.Empty;
                    if (string.IsNullOrEmpty(id))
                    {
                        continue;
                    }
                    else
                    {
                        if (isAccept)
                        {
                            if (!AcceptDict.ContainsKey(type))
                            {
                                AcceptDict[type] = new List<string>();
                            }

                            AcceptDict[type].Add(id);
                        }
                    }
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}