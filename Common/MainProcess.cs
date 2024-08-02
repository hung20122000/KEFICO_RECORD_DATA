using DevExpress.XtraSpreadsheet;
using DocumentFormat.OpenXml.Spreadsheet;
using DevExpress.Spreadsheet;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TanHungHa.Tabs;
using DevExpress.Security;

namespace TanHungHa.Common
{
    public enum eCamSide
    {
        LEFT,
        RIGHT,
        CANBUS
    }
    public class MainProcess
    {
        //string codeData = null;

        MaterialButton btnStatus = null;
        MaterialButton btnResult = null;

        public StepControl Main_StepCtrl = new StepControl();
        public string TAG = null;
        public MainProcess()
        {
            Main_StepCtrl = null;
            TAG = null;
        }

        public void LogAuto(string message)
        {
            MyParam.autoForm.lvLogAuto.BeginInvoke(new Action(() =>
            {
                MyParam.autoForm.lvLogAuto.Items.Add(new ListViewItem(new string[] { MyLib.GetTimestamp(DateTime.Now), $"{TAG}:\t{message}" }));
            }));
        }


        public void SetStatus(string status)
        {
            btnStatus.BeginInvoke(new Action(() =>
            {
                if (btnStatus.Text.Equals(status))
                    return;

                btnStatus.Text = status;
            }));

        }

        public void SetResult(string result)
        {
            btnResult.BeginInvoke(new Action(() =>
            {
                if (btnResult.Text.Equals(result))
                    return;

                btnResult.Text = result;
            }));
        }

        public static void StopLoopRS232()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232].StopLoop();

            //MyParam.commonParam.queueData.Clear();
        }
        public static void RunLoopRS232()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_RS232].RunLoop(MyParam.commonParam.timeDelay.timeLoop, LoopProcess).ContinueWith((a) =>
            {
                MyLib.showDlgInfo($"Done task!");
            });
        }

        public static void RunLoopUpdateFileExcel()
        {
            MyParam.taskLoops[(int)eTaskLoop.Task_EXCEL].ResetToken();
            MyParam.taskLoops[(int)eTaskLoop.Task_EXCEL].RunLoop(2000, CheckAndProcessDate).ContinueWith((a) =>
            {
                MyLib.showDlgError($"Done task!");
            });
        }
 
        public static void LoopProcess()
        {
            lock (MyParam.commonParam.queueLock)
            {
                int queueSize = MyParam.commonParam.queueData.Count;
                if (queueSize > 0)
                {
                    var data = MyParam.commonParam.queueData.Dequeue();
                    SvLogger.Log.Sequence(data);
                    MyParam.tabRS232.setText(data);
                    MyExcel.GetInstance().writeCellSequence(data,MyExcel.dataType.DOUBLE);
                }
            }
        }
        public static void CheckAndProcessDate()
        {
            string dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            string templateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "template.xlsx");

            // Lấy ngày hiện tại
            DateTime currentDate = DateTime.Now.Date;
            string formattedDate = currentDate.ToString("yyyyMMdd");

            // Đọc ngày cuối cùng đã thực hiện
            string lastRunDateFilePath = Path.Combine(dataDirectory, "last_run_date.txt");
            DateTime lastRunDate = File.Exists(lastRunDateFilePath)
                ? DateTime.Parse(File.ReadAllText(lastRunDateFilePath))
                : DateTime.MinValue;

            // Kiểm tra xem ngày hiện tại có phải là ngày mới không
            if (currentDate > lastRunDate)
            {
                // Cập nhật ngày cuối cùng đã thực hiện
                File.WriteAllText(lastRunDateFilePath, currentDate.ToString("yyyy-MM-dd"));

                // Tạo thư mục mới
                string newFolder = Path.Combine(dataDirectory, formattedDate);
                if (!Directory.Exists(newFolder))
                {
                    Directory.CreateDirectory(newFolder);
                }

                // Tạo tên tệp đích
                string newFileName = $"data_{formattedDate}.xlsx";
                string destinationFilePath = Path.Combine(newFolder, newFileName);

                // Sao chép tệp mẫu vào thư mục mới với tên mới
                if (File.Exists(templateFilePath))
                {
                    File.Copy(templateFilePath, destinationFilePath, true); // true để ghi đè nếu tệp đã tồn tại
                }
                else
                {
                    Console.WriteLine("Template file does not exist.");
                }
                MyParam.commonParam.myExcel.filePath = destinationFilePath;

                MyParam.commonParam.myExcel.openExcell();

                Console.WriteLine($"File copied to: {destinationFilePath}");
            }
            else
            {
                Console.WriteLine("No new date detected.");
            }

        }
    }
}
