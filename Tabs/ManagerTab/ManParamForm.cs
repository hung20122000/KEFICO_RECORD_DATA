using MaterialSkin.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanHungHa.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TanHungHa.Tabs.ManualTab
{
    public partial class ManParamForm : MaterialForm
    {
        private static ManParamForm _instance;
        private static readonly object _lock = new object();
        public static ManParamForm GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ManParamForm();
                    }
                }
            }
            return _instance;
        }

        public ManParamForm()
        {
            InitializeComponent();
            InitTreeView();
        }


        void InitTreeView()
        {
            treeView.BeginUpdate();
            TreeNode treeNodeExcel = new TreeNode(Text = MyDefine.treenodeExcel);
            TreeNode treeNodeRS232 = new TreeNode(Text = MyDefine.treenodeRS232);
            //TreeNode treeNodeFakeKeyboard = new TreeNode(Text = MyDefine.treenodeFakeKeyboard);

            treeView.Nodes.Add(treeNodeExcel);
            treeView.Nodes.Add(treeNodeRS232);
            
            treeView.EndUpdate();

            treeView.SelectedNode = treeNodeExcel;

            TreeNode childNode;

            foreach (TreeNode child in treeNodeExcel.Nodes)
            {
                if ("mode" == child.Text) {
                    childNode = child;
                    break;
                }
                
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedNodeText = e.Node.Text;
            Console.WriteLine(selectedNodeText);
            switch(selectedNodeText)
            {
                case MyDefine.treenodeExcel:
                    propertyGrid.SelectedObject = MyParam.commonParam.myExcel;
                    break;
                case MyDefine.treenodeRS232:
                    propertyGrid.SelectedObject = MyParam.commonParam.myComport;
                    break;

            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Console.WriteLine("update!");
            propertyGrid.Refresh();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveLoadParameter.Save_Parameter(MyParam.uIParam, MyDefine.file_uiParam);
            SaveLoadParameter.Save_Parameter(MyParam.commonParam, MyDefine.file_config);
        }
    }
}
