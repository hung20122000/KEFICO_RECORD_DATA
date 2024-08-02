using DevExpress.Spreadsheet;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSpreadsheet;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TanHungHa.Common;
using System.IO.Ports;
using ZedGraph;

namespace TanHungHa.Tabs
{
    public partial class FormAuto : MaterialForm
    {
        private static FormAuto _instance;
        private static readonly object _lock = new object();
        private readonly object balanceLock = new object();
        public static FormAuto GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {

                    if (_instance == null)
                    {
                        _instance = new FormAuto();
                    }
                }
            }
            return _instance;
        }

        private void SpreadsheetControl_DocumentLoaded(object sender, System.EventArgs e)
        {
            spreadsheetControl.Document.CalculateFull();
            BarHeaderFileName.Caption = spreadsheetControl.Options.Save.CurrentFileName;
            MyParam.commonParam.myExcel.filePath = BarHeaderFileName.Caption;

        }

        public FormAuto()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
            btnOpen.Enabled = true;
            btnSaveAs.Enabled = true;

            spreadsheetControl.DocumentLoaded += SpreadsheetControl_DocumentLoaded;
            MyParam.commonParam.myExcel.SetSpreadSheet(spreadsheetControl);
            //CreateGraph(MyParam.commonParam.myExcel.filePath);
            InitDiplayEvent();
        }




        public void LogAuto(string message = "", string mode = "")
        {
            MyParam.autoForm.lvLogAuto.BeginInvoke(new Action(() =>
            {
                if (mode != "Clear")
                    MyParam.autoForm.lvLogAuto.Items.Add(new ListViewItem(new string[] { MyLib.GetTimestamp(DateTime.Now), $"APP:\t{message}" }));
                else
                    MyParam.autoForm.lvLogAuto.Items.Clear();
            }));
        }

        private void btnProgramAction(object sender, EventArgs e)
        {
            var btnName = ((MaterialButton)sender).Name;
            switch (btnName)
            {
                case "btnStart":

                    break;

                case "btnStop":

                    break;

                case "btnOpenFile":

                    break;

            }
        }
     
        /*public void CreateGraph(string filePath_)
        {
            using (var spreadsheet = new SpreadsheetControl())
            {
                spreadsheet.LoadDocument(filePath_);
                var worksheet = spreadsheet.Document.Worksheets[0];


                GraphPane PaneDistance = zedGraphControl.GraphPane;

                RollingPointPairList l4 = new RollingPointPairList(999999);

                //PaneDistance.AddCurve("Giá trị đo", l4, Color.Blue, SymbolType.None);

                PaneDistance.Title.Text = "Biểu đồ giá trị đo";
                PaneDistance.XAxis.Title.Text = "STT";
                PaneDistance.YAxis.Title.Text = "Value(mm)";

                // Read data from columns A and B
                var xValues = new List<double>();
                var yValues = new List<double>();

                for (int i = 0; i < worksheet.GetUsedRange().RowCount; i++)
                {
                    double xValue, yValue;
                    if (double.TryParse(worksheet[i, 0].Value.ToString(), out xValue) &&
                        double.TryParse(worksheet[i, 1].Value.ToString(), out yValue))
                    {
                        xValues.Add(xValue);
                        yValues.Add(yValue);
                    }
                }
                // Create a new curve for the data
                var curve = PaneDistance.AddCurve("Data", xValues.ToArray(), yValues.ToArray(), Color.Blue, SymbolType.Circle);
                zedGraphControl.AxisChange();
                zedGraphControl.Invalidate();
            }
        }*/
       /* public double timeChart = 0;
        void UpdatePaneDistance(double CurrentValue,double time, string Mode)
        {
            GraphPane PaneDistance = zedGraphControl.GraphPane;

            if (Mode == "CLEAR")
            {
               PaneDistance.CurveList.Clear();
               PaneDistance.GraphObjList.Clear();
               zedGraphControl.AxisChange();
               zedGraphControl.Invalidate();
               timeChart = 0;
            }
            else
            {
                if (PaneDistance.CurveList.Count <= 0)
                {

                    RollingPointPairList l4 = new RollingPointPairList(999999);

                    PaneDistance.AddCurve("Current Value", l4, Color.Blue, SymbolType.Circle);

                }
                LineItem curve = PaneDistance.CurveList[0] as LineItem;

                if (curve == null)
                    return;

                IPointListEdit list = curve.Points as IPointListEdit;

                if (list == null)
                    return;

                timeChart += time;
                
                list.Add(timeChart, CurrentValue);

                Scale xScale = PaneDistance.XAxis.Scale;
                if (timeChart > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = timeChart + xScale.MajorStep;
                    xScale.Min = 0;
                }

                zedGraphControl.AxisChange();
                zedGraphControl.Invalidate();
            }

        }
        bool bThreadShowGraphic = false;
        public void ThreadStartShowGraphic()
        {
            if (bThreadShowGraphic)
            {
                return;
            }

            UpdatePaneDistance( 0,0, "CLEAR");

            bThreadShowGraphic = true;
        }

        public void ThreadStopShowGraphic()
        {
            bThreadShowGraphic = false;
            Thread.Sleep(10);
        }
        public void DoGraphicUpdateUI(string data_)
        {
            {
                {
                    double currentValue = Double.Parse(data_);              
                    string mode = "UPDATE";
                    double time = 0.01;


                    // Gọi phương thức UpdateDataGrid trong UI thread

                   if (zedGraphControl.InvokeRequired)
                    {
                        zedGraphControl.Invoke(new Action(() => UpdatePaneDistance(currentValue,time, mode)));
                    }
                    else
                    {
                        UpdatePaneDistance(currentValue,time, mode);
                    }
                }
            }
        }*/

        void InitDiplayEvent()
        {

        }

        bool m_bRun = false;

        public void btnStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bRun) return;
            LogAuto("Clear", "Clear");
            string nameFile = MyParam.commonParam.myExcel.filePath;

            if (File.Exists(nameFile))
            {
                LogAuto($"{nameFile} exists");
            }
            else
            {
                LogAuto($"{nameFile} does not exist");
                return;
            }

            if (MyParam.commonParam.myComport.connect())
            {
                LogAuto($"Connect {MyParam.commonParam.myComport.portName} Ok");
            }
            else
            {
                LogAuto($"Connect {MyParam.commonParam.myComport.portName} Fail");
                return;
            }


            if (nameFile != BarHeaderFileName.Caption && nameFile != "")
            {
                if (MyParam.commonParam.myExcel.openExcell())
                {
                    LogAuto($"Load excel file Ok");
                }
                else
                {
                    LogAuto($"Load excel file Fail");
                    return;
                }
            }

            MainProcess.RunLoopRS232();
            LogAuto($"Running");
            m_bRun = true;
            SetCtrlWhenStart();
            //ThreadStartShowGraphic();
        }

        public void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_bRun) return;
           
            MainProcess.StopLoopRS232();

            if (!MyParam.commonParam.myComport.disConnect())
            {
                LogAuto($"disConnect {MyParam.commonParam.myComport.portName} Ok");

            }
            else
            {
                LogAuto($"disConnect {MyParam.commonParam.myComport.portName} Fail");
                return;
            }

            LogAuto($"Stop");
            m_bRun = false;
            SetCtrlWhenStop();
        }

        private void SetCtrlWhenStop()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnOpen.Enabled = true;
            btnSaveAs.Enabled = true;
            spreadsheetControl.ReadOnly = false;
            MyParam.manualForm.Enabled = true;
            MyParam.managerForm.Enabled = true;

        }

        private void SetCtrlWhenStart()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnOpen.Enabled = false;
            btnSaveAs.Enabled = false;
            //spreadsheetControl.ReadOnly = true;
            MyParam.manualForm.Enabled = false;
            MyParam.managerForm.Enabled = false;


        }

        private void lvLogAuto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LogAuto("Clear", "Clear");
        }

        private void barManager1_ShowToolbarsContextMenu(object sender, DevExpress.XtraBars.ShowToolbarsContextMenuEventArgs e)
        {
            e.ItemLinks.Clear();
            return;
        }
    }


}
