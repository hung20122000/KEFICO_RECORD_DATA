using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using TanHungHa.Common;
using TanHungHa.Tabs;

namespace TanHungHa
{
    public partial class FormMain : MaterialForm
    {
        private Process cur = null;
        private PerformanceCounter curpcp = null;
        private const int MB_DIV = 1024 * 1024;

        private static FormMain _instance;
        private static readonly object _lock = new object();
        public static FormMain GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormMain();
                    }
                }
            }
            return _instance;
        }

        void InitSkin()
        {
            // Initialize MaterialSkinManager
            MyParam.materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            MyParam.materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            MyParam.materialSkinManager.AddFormToManage(this);
            MyParam.materialSkinManager.Theme = MyParam.uIParam.themes;
            DrawerAutoShow = MyParam.uIParam.swAutoShow;
            DrawerUseColors = MyParam.uIParam.swUserColors;
            DrawerHighlightWithAccent = MyParam.uIParam.swHighlightWithAccent;
            DrawerBackgroundWithAccent = MyParam.uIParam.swBackgroundWithAccent;
            DrawerShowIconsWhenHidden = MyParam.uIParam.swDisplayIconWhenHidden;
            MyLib.updateColor();
            Invalidate();


        }

        public void ShowInfo(string message, string title = "Warning")
        {
            MaterialDialog materialDialog = new MaterialDialog(this, title, message, "OK");
            DialogResult result = materialDialog.ShowDialog(this);

            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            SnackBarMessage.Show(this);
        }

        void InitVariables()
        {
            this.DoubleBuffered = true;
            MyParam.uIParam = SaveLoadParameter.Load_Parameter(MyParam.uIParam, MyDefine.file_uiParam) as UIParam;
            if (MyParam.uIParam == null)
            {
                MyParam.uIParam = UIParam.GetInstance();
                ShowInfo("Create default uiParam");
            }

            MyParam.commonParam = SaveLoadParameter.Load_Parameter(MyParam.commonParam, MyDefine.file_config) as CommonParam;
            if (MyParam.commonParam == null)
            {
                MyParam.commonParam = CommonParam.GetInstance();
                ShowInfo("Create default commonParam");
            }

            //Log
            SvLogger.Log.RollOverImage();
            SvLogger.Log.RollOverLog();

            //timer - RAM
            timerRAM.Enabled = true;
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolCheckVersion), null);

        }

        private void ThreadPoolCheckVersion(object obj)
        {
            System.Threading.Thread.Sleep(100);

            try
            {
                cur = Process.GetCurrentProcess();
                curpcp = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
            }
            catch
            {

            }
        }

        void InitGUI()
        {
            this.Text = MyDefine.title;
            materialTabControl1.SelectedTab = tabPageAuto;

            MyParam.autoForm.TopLevel = false;
            MyParam.infoForm.TopLevel = false;
            MyParam.logForm.TopLevel = false;
            MyParam.managerForm.TopLevel = false;
            MyParam.manualForm.TopLevel = false;
            MyParam.teachingForm.TopLevel = false;
           

            MyParam.autoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.infoForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.logForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.managerForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.manualForm.FormBorderStyle = FormBorderStyle.None;
            MyParam.teachingForm.FormBorderStyle = FormBorderStyle.None;
            

            MyParam.autoForm.Dock = DockStyle.Fill;
            MyParam.infoForm.Dock = DockStyle.Fill;
            MyParam.logForm.Dock = DockStyle.Fill;
            MyParam.managerForm.Dock = DockStyle.Fill;
            MyParam.manualForm.Dock = DockStyle.Fill;
            MyParam.teachingForm.Dock = DockStyle.Fill;
           

            panelAuto.Controls.Add(MyParam.autoForm);
            panelInfo.Controls.Add(MyParam.infoForm);
            panelLog.Controls.Add(MyParam.logForm);
            panelManager.Controls.Add(MyParam.managerForm);
            panelManual.Controls.Add(MyParam.manualForm);
            panelTeaching.Controls.Add(MyParam.teachingForm);
            
            
            
            

            panelAuto.Tag = (MyParam.autoForm);
            panelInfo.Tag = (MyParam.infoForm);
            panelLog.Tag = (MyParam.logForm);
            panelManager.Tag = (MyParam.managerForm);
            panelManual.Tag = (MyParam.manualForm);
            panelTeaching.Tag = (MyParam.teachingForm);
           
            


            MyParam.autoForm.BringToFront();
            MyParam.infoForm.BringToFront();
            MyParam.logForm.BringToFront();
            MyParam.managerForm.BringToFront();
            MyParam.manualForm.BringToFront();
            MyParam.teachingForm.BringToFront();
         

            MyParam.autoForm.Show();
            MyParam.infoForm.Show();
            MyParam.logForm.Show();
            MyParam.managerForm.Show();
            MyParam.manualForm.Show();
            MyParam.teachingForm.Show();
           

        }

        public FormMain()
        {
            InitializeComponent();
            InitVariables();
            InitSkin();
            InitGUI();
            MainProcess.RunLoopUpdateFileExcel();
        }
        private void materialTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action);
            messageBoxCS.AppendLine();
            Console.WriteLine(messageBoxCS.ToString());
           
            switch (e.TabPage.Name)
            {
                case "tabPageAuto":
                    break;

                case "tabPageManual":
                    break;

                case "tabPageTeaching":
                    break;

                case "tabPageManager":
                    break;

                case "tabPageLog":
                    break;

                case "tabPageInfo":
                    break;
               
                    

            }
        }

        private bool hasClosed = false;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasClosed)
            {
                return;
            }

            MaterialDialog materialDialog = new MaterialDialog(this, "Exit?", "Are you sure want to exit?", "OK", true, "Cancel");
            DialogResult result = materialDialog.ShowDialog(this);

            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            SnackBarMessage.Show(this);

            if (result == DialogResult.OK)
            {
                try
                {
                    if (result == DialogResult.OK)
                    {
                        MyLib.closeCom();
                        SaveLoadParameter.Save_Parameter(MyParam.uIParam, MyDefine.file_uiParam);
                        SaveLoadParameter.Save_Parameter(MyParam.commonParam, MyDefine.file_config);
                    }
                }
                catch { }

            }
            else if (result == DialogResult.Cancel)
            {
                hasClosed = false;
                e.Cancel = true;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                try
                {
                    hasClosed = true;
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    SvLogger.Log.Error("An error occurred while closing the application: " + ex.Message);
                }
            }
        }


        private void timerRAM_Tick(object sender, EventArgs e)
        {
            if (curpcp != null)
            {
                string RamInfo = (curpcp.NextValue() / MB_DIV).ToString("F1") + "MB";
                this.Text = MyDefine.title + " (Ram: " + RamInfo + ")";
            }
        }
    }
}
