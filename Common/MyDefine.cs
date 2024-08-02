using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TanHungHa.Common
{
    public class MyDefine
    {
        public static readonly string title = "THH Record Data App";
        public static readonly string version = "Version 0.1.0 \r\n 01/12/2023";
        
        public const string treenodeExcel = "Excel";
        public const string treenodeFakeKeyboard = "HID";
        public const string treenodeRS232 = "RS232";
        public const string treenodeTheme = "Theme";
        public const string treenodeDev = "Developer";

        public static int NUM_THREAD = 2;
        public static int MAX_FRAME_SIZE = 10;
        public const int MAX_QUEUE_DATA = 100;
        public static int[] baudrates = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 } ;
        public static int[] dataSize = new int[] { 7,8 };

        public static readonly string workingDirectory = Environment.CurrentDirectory;
        public static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        //public static readonly string workspaceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public static readonly string resources_folder = String.Format($"{workingDirectory}\\resources");
        public static readonly string model_folder = String.Format($"C:\\CTTV_VisionInspection_Data\\Models");
        public static readonly string dowload_folder = String.Format($"C:\\CTTV_VisionInspection_Data\\Downloads");
        public static readonly string image_folder = String.Format($"C:\\CTTV_VisionInspection_Data\\Images");
        public static readonly string job_folder = String.Format($"C:\\CTTV_VisionInspection_Data\\Jobs");
        public static readonly string text_folder = String.Format($"C:\\CTTV_VisionInspection_Data\\Texts");

        public static readonly string regex_get_image_file = @"[^\s]+(.*?)\.(jpg|jpeg|png|gif|bmp|JPG|JPEG|PNG|GIF|BMP)$";
        public static readonly string regex_get_ip = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";


        public static readonly string file_camera_config = String.Format($"{workingDirectory}\\Configs\\CameraParameters.pfs");
        public static readonly string file_tool_process = String.Format($"{workingDirectory}\\Configs\\Demo_TB_OK_Full.vpp");
        public static readonly string file_tool_acq = String.Format($"{workingDirectory}\\Configs\\Tool_Acq.vpp");


        #region Path file json
        public static readonly string file_y_axis_test_loop = String.Format($"{workingDirectory}\\Configs\\y_axis_test_loop.json");
        public static readonly string file_x_axis_test_loop = String.Format($"{workingDirectory}\\Configs\\x_axis_test_loop.json");

        public static readonly string file_minio_client = String.Format($"{workingDirectory}\\Configs\\minio_client.json");
        public static readonly string file_camera = String.Format($"{workingDirectory}\\Configs\\camera.json");
        public static readonly string file_model = String.Format($"{workingDirectory}\\Configs\\model.json");
        public static readonly string file_plc_assignment = String.Format($"{workingDirectory}\\Configs\\plc_assignment.json");
        //public static readonly string path_result = String.Format($"{workingDirectory}\\Configs\\plc_assignment.json");
        //public static readonly string path_save_texts = String.Format("{0}\\Texts", projectDirectory);

        
        public static readonly string file_config = String.Format($"{workingDirectory}\\Configs\\config_param.json");
        public static readonly string file_uiParam= String.Format($"{workingDirectory}\\Configs\\uiParameter.json");
        public static readonly string file_cameraParam= String.Format($"{workingDirectory}\\Configs\\camParameter.json");
        public static readonly string file_excel = String.Format($"{workingDirectory}\\Data\\ImportData.xlsx");

        public static readonly string file_config_format_data = String.Format($"{workingDirectory}\\Data\\configs\\format_data.json");
        public static readonly string file_config_common_param = String.Format($"{workingDirectory}\\Data\\configs\\common_param.json");
        public static readonly string file_config_filter_window = String.Format($"{workingDirectory}\\Data\\configs\\filter_window.json");
        public static readonly string path_load_img_database = @"C:\Program Files\Cognex\VisionPro\Images";
        public static readonly string path_load_vpp_file = @"C:\Users\Admin\Desktop\Vpp_file";
        public static readonly string path_save_images = String.Format("{0}\\Images", projectDirectory);

        public static readonly string key_thh = @"https://tanhungha.com.vn/";
        public static readonly string hash_key = "";
        #endregion

        #region api
        public static string API_OK = "success";
        public static string API_NG = "error";
        public static string API_Warning = "warning";
        public static string API_LOSS_CONNECTION = "network";
        public static string dev_pass = "tuanna@2022";
        public static string user_pass = "cttv@2022";
        #endregion

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        public static bool CheckLibrary(string fileName)
        {
            return LoadLibrary(fileName) == IntPtr.Zero;
        }

    }
}
