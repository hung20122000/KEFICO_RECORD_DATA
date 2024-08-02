using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace TanHungHa.Common
{

    enum eMargin
    {
        LEFT,
        TOP,
        RIGHT,
        BOT
    }

    enum eSpace
    {
        X,
        Y
    }


    
    public static class MyLib
    {

        #region Fake keyboard
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);


        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);


        #endregion

        public static int[] text2arr(string text, int length)
        {
            int[] arr = new int[length];

            if (text == null | !text.Contains(","))
                return arr;

            var x = text.Split(',');
            for (int i = 0; i < x.Length; i++)
                arr[i] = int.Parse(x[i]);
            return arr;
        }


        

        public static bool fileIsExists(string file_name)
        {
            return File.Exists(file_name);
        }
        
        public static void showDlgError(string message)
        {
            if (MyParam.mainForm == null)
            {
                SvLogger.Log.Debug("MyParam.mainForm = null, at MyLib::ShowInfo");
                return;
            }
            MaterialDialog materialDialog = new MaterialDialog(MyParam.mainForm, "Error", message, "OK");
            DialogResult result = materialDialog.ShowDialog(MyParam.mainForm);
        }
        
        public static void showDlgWarning(string message)
        {
            if (MyParam.mainForm == null)
            {
                SvLogger.Log.Debug("MyParam.mainForm = null, at MyLib::ShowInfo");
                return;
            }
            MaterialDialog materialDialog = new MaterialDialog(MyParam.mainForm, "Warning", message, "OK");
            DialogResult result = materialDialog.ShowDialog(MyParam.mainForm);
        }
        
        public static void showDlgInfo(string message)
        {
            if (MyParam.mainForm == null)
            {
                SvLogger.Log.Debug("MyParam.mainForm = null, at MyLib::ShowInfo");
                return;
            }
            if(MyParam.mainForm.InvokeRequired)
            {
                MyParam.mainForm.BeginInvoke(new Action(() =>
                {
                    MaterialDialog materialDialog = new MaterialDialog(MyParam.mainForm, "Info", message, "OK");
                    DialogResult result = materialDialog.ShowDialog(MyParam.mainForm);
                }));
            }
            
        }

        public static void ShowInfo(string message, string title = "Warning")
        {
            if(MyParam.mainForm == null)
            {
                SvLogger.Log.Debug("MyParam.mainForm = null, at MyLib::ShowInfo");
                return;
            }    
          //  MaterialDialog materialDialog = new MaterialDialog(MyParam.mainForm, title, message, "OK");
          //  DialogResult result = materialDialog.ShowDialog(MyParam.mainForm);

            //MaterialSnackBar SnackBarMessage = new MaterialSnackBar(result.ToString(), 750);
            //SnackBarMessage.Show(MyParam.mainForm);
        }

        public static void log(string message)
        {
            Console.WriteLine(message);
            SvLogger.Log.Debug(message);
        }
        public static void log(string TAG, string message)
        {
            Console.WriteLine(TAG + ": " + message);
        }
        

        
        
        public static void closeCom()
        {
            //close and clear list camera
            //MyParam.commonParam.myComport.disConnect();


            
        }
       

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd-HH:mm:ss:ffff");
        }

        public static void updateColor()
        {
            //These are just example color schemes
            switch (MyParam.uIParam.colorSchemeIndex)
            {
                case 0:
                    MyParam.materialSkinManager.ColorScheme = new ColorScheme(
                        MyParam.materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        MyParam.materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        MyParam.materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;

                case 1:
                    MyParam.materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    break;

                case 2:
                    MyParam.materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
            }
            
        }


        public static byte[] serialize(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFomatter = new BinaryFormatter();
            binaryFomatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }

        

        

        public static string createMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

    }
}
