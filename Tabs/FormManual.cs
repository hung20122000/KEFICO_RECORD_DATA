using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using TanHungHa.Common;

namespace TanHungHa.Tabs
{
    public partial class FormManual : MaterialForm
    {
        private static FormManual _instance;
        private static readonly object _lock = new object();
        public static FormManual GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FormManual();
                    }
                }
            }
            return _instance;
        }

        public FormManual()
        {
            InitializeComponent();
            InitGUI();
        }

        void InitGUI()
        {
            this.Text = MyDefine.title;
            materialTabControlManual.SelectedTab = tabPageVisionpro;


            MyParam.tabRS232.TopLevel = false;
            MyParam.tabRS232.FormBorderStyle = FormBorderStyle.None;
            MyParam.tabRS232.Dock = DockStyle.Fill;
            
            //MyParam.tabExcel.TopLevel = false;
            //MyParam.tabExcel.FormBorderStyle = FormBorderStyle.None;
            //MyParam.tabExcel.Dock = DockStyle.Fill;

            tabPageSerial.Controls.Add(MyParam.tabRS232);
            tabPageSerial.Tag = (MyParam.tabRS232);
            
            //tabPageExcel.Controls.Add(MyParam.tabExcel);
            //tabPageExcel.Tag = (MyParam.tabExcel);

            
            MyParam.tabRS232.BringToFront();
            MyParam.tabRS232.Show();
            
            //MyParam.tabExcel.BringToFront();
            //MyParam.tabExcel.Show();

        }


        bool isInitToolBlock = false;
        private void materialTabControlManual_Selected(object sender, TabControlEventArgs e)
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
                case "tabPageVisionpro":
                    break;
                
                case "tabPageCamera":
                    if(!isInitToolBlock)
                    {
                        isInitToolBlock = true;
                    }
                    break;

                
            }
        }
    }
}
