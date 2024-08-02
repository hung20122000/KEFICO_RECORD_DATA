using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using TanHungHa.Common;

internal static class Program
{
    private static Mutex mutex = new Mutex(true, "{Your unique mutex name}");

    [STAThread]
    private static void Main()
    {
        //if (mutex.WaitOne(TimeSpan.Zero, true))
        //{
            //if (!IsRunAsAdmin())
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(MyParam.mainForm);
            //}
            //else
            //{
            //    RestartAsAdmin();
            //}
        //}
        //else
        //{
        //    MessageBox.Show("Another instance of the application is already running.", "Single Instance App",
        //        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
    }

    private static bool IsRunAsAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    private static void RestartAsAdmin()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = Assembly.GetEntryAssembly().Location;
        startInfo.UseShellExecute = true;

        try
        {
            startInfo.Verb = "runas"; // Set the verb to "runas" to run the process as admin
            Process.Start(startInfo);
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            if (ex.NativeErrorCode == 1223)
            {
                // User cancelled the UAC prompt
                MessageBox.Show("You need to run the application as an administrator.", "Admin Privileges Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Other error, handle as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return; // Return without releasing the mutex or exiting the application
        }

        mutex.ReleaseMutex();
        Application.Exit(); // Exit the current instance of the application
    }
}
