using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TanHungHa.Tabs;
using TanHungHa.Tabs.ManualTab;
using static MaterialSkin.Controls.MaterialForm;

namespace TanHungHa.Common
{

    //insert comment
    public enum eTaskLoop
    {
        Task_RS232,
        Task_EXCEL,
    }

    public enum eProcessing
    {
        None = 0,
        Check_Condition_To_Run,
        Wait_Signal,
        Delay_Stable_Camera,
        Get_Image,
        Toolblock_Trigger,
        GetResult,
        Show_Result,
        Delay_Show_Result,
        Delay_Rest,
        Error,
        Finish
    }

    public class StepControl
    {
        public eProcessing Cur_Processing;
        public eProcessing Old_Processing;

        public StepControl()
        {
            Cur_Processing = eProcessing.None;
            Old_Processing = eProcessing.None;
        }

        public void SetStep(eProcessing step)
        {
            if (Cur_Processing == step)
            {
                Console.WriteLine("Dupplicate Step");
                return;
            }
            //Update step
            Old_Processing = Cur_Processing;
            Cur_Processing = step;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Old step = {Old_Processing}");
            Console.WriteLine($"Cur step = {Cur_Processing}");
        }
    }

    public class PineLine
    {
        //1. Camera  - Image
        //2. Process
        //3. Comport
    }
    public class ToolblockParam
    {
        public string path;
        public string isUsing;
    }

    public class TimeDelay
    {
        public int camStable { get; set; }
        public int showResult { get; set; }
        public int timeOut { get; set; }
        public int timeLoop { get; set; }
        public int delayAfterProcess { get; set; }
        public int delayLoadJob { get; set; }


        public TimeDelay()
        {
            timeLoop = 10;
            camStable = 100;
            showResult = 2000;
            timeOut = 2000;
            delayAfterProcess = 3000;
            delayLoadJob = 1000;
        }
    }


    public class CommonParam
    {
        private static CommonParam _instance;
        private static readonly object _lock = new object();
        public static CommonParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CommonParam();
                    }
                }
            }
            return _instance;
        }


        //--------------------Variable------------------
        //public MyComport myComport { get; set; }

        public SerialPortCommunication myComport { get; set; }
        public MyExcel myExcel { get; set; }
        public FakeKeyboadParam fakeKeyboadParam { get; set; }
        public TimeDelay timeDelay { get; set; }

        [JsonIgnore]
        public Queue<string> queueData;
        [JsonIgnore]
        public object queueLock;


        //--------------------------------------------
        CommonParam()
        {
            timeDelay = new TimeDelay();

            myComport = SerialPortCommunication.GetInstance();
            myExcel = MyExcel.GetInstance();
            fakeKeyboadParam = FakeKeyboadParam.GetInstance();

            queueData = new Queue<string>(MyDefine.MAX_QUEUE_DATA);
            queueLock = new object();
        }
    }
    
    public class FakeKeyboadParam
    {
        private static FakeKeyboadParam _instance;
        private static readonly object _lock = new object();
        public static FakeKeyboadParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FakeKeyboadParam();
                    }
                }
            }
            return _instance;
        }


        //--------------------Variable------------------
        public string className { get; set; }
        public bool ignoreClassName { get; set; }
        public bool setForeGround { get; set; }


        //--------------------------------------------
        FakeKeyboadParam()
        {
            className = "XLMAIN";
            ignoreClassName = false;
            setForeGround = false;
        }
    }


    public static class MyParam
    {
        static int number_create = 0;
        public static List<TaskLoop> taskLoops = new List<TaskLoop>();
        public static MaterialSkinManager materialSkinManager;

        public static UIParam uIParam = null;
        public static CommonParam commonParam = null;
        


        public static FormAuto autoForm = null;
        public static FormInfo infoForm = null;
        public static FormLog logForm = null;
        public static FormManager managerForm = null;
        public static FormManual manualForm = null;
        public static FormTeaching teachingForm = null;
        public static FormMain mainForm = null;
        


        //sub tab of Manual TAB
        public static RS232Form tabRS232 = null;

        //sub tab of Manager TAB
        public static ManParamForm tabManagerParam = null;
        public static ManThemeForm tabManagerTheme = null;



        public static void initial()
        {
            //task
            for (int i = 0; i < MyDefine.NUM_THREAD; i++)
            {
                taskLoops.Add(new TaskLoop());
            }

            //param
            uIParam = UIParam.GetInstance();
            commonParam = CommonParam.GetInstance();

            //form
            tabRS232 = RS232Form.GetInstance();
            //tabExcel = ExcelForm.GetInstance();

            tabManagerParam = ManParamForm.GetInstance();
            tabManagerTheme = ManThemeForm.GetInstance();

            autoForm = FormAuto.GetInstance();
            infoForm = FormInfo.GetInstance();
            logForm = FormLog.GetInstance();
            managerForm = FormManager.GetInstance();
            manualForm = FormManual.GetInstance();
            teachingForm = FormTeaching.GetInstance();
            mainForm = FormMain.GetInstance();
        }
        static MyParam()
        {
            Console.WriteLine($"Constructor MyParam = {number_create++}");
            initial();
        }
    }

    public class UIParam
    {
        private static UIParam _instance;
        private static readonly object _lock = new object();
        public static UIParam GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UIParam();
                    }
                }
            }
            return _instance;
        }
        public MaterialSkinManager.Themes themes { get; set; }
        public MaterialForm.FormStyles styles { get; set; }
        public bool swUserColors { get; set; }
        public bool swHighlightWithAccent { get; set; }
        public bool swBackgroundWithAccent { get; set; }
        public bool swDisplayIconWhenHidden { get; set; }
        public bool swAutoShow { get; set; }
        public int colorSchemeIndex { get; set; }

        UIParam()
        {
            themes = MaterialSkinManager.Themes.LIGHT;
            styles = FormStyles.StatusAndActionBar_None;
            swUserColors = true;
            swHighlightWithAccent = true;
            swBackgroundWithAccent = true;
            swDisplayIconWhenHidden = true;
            swAutoShow = true;
            colorSchemeIndex = 2;
        }


    }
}
