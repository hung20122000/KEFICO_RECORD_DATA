using MaterialSkin.Controls;
using System.Windows.Forms;
using TanHungHa.Common;

namespace TanHungHa.Tabs
{
    public partial class FormManager : MaterialForm
    {
        private static FormManager _instance;
        private static readonly object _lock = new object();
        public static FormManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormManager();
                    }
                }
            }
            return _instance;
        }

        public FormManager()
        {
            InitializeComponent();
            InitGUI();
        }

        void InitGUI()
        {
            this.Text = MyDefine.title;
            materialTabControlManager.SelectedTab = tabPageParameter;


            MyParam.tabManagerParam.TopLevel = false;
            MyParam.tabManagerTheme.TopLevel = false;


            MyParam.tabManagerParam.FormBorderStyle = FormBorderStyle.None;
            MyParam.tabManagerTheme.FormBorderStyle = FormBorderStyle.None;


            MyParam.tabManagerParam.Dock = DockStyle.Fill;
            MyParam.tabManagerTheme.Dock = DockStyle.Fill;

            tabPageParameter.Controls.Add(MyParam.tabManagerParam);
            tabPageTheme.Controls.Add(MyParam.tabManagerTheme);


            tabPageParameter.Tag = (MyParam.tabManagerParam);
            tabPageTheme.Tag = (MyParam.tabManagerTheme);


            MyParam.tabManagerParam.BringToFront();
            MyParam.tabManagerTheme.BringToFront();


            MyParam.tabManagerParam.Show();
            MyParam.tabManagerTheme.Show();


        }

    }
}
