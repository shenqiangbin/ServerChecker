using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ServerLoadChecker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.Run(new ServerLoadCheckerUI());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string tip = string.Empty;
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                tip = string.Format("Window UI Thread Unhandled Exception: {0}\n{1}", ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                tip = string.Format("Unknown Exception while handling the Window UI Thread Exception: {0}\n{1}", ex.Message, ex.StackTrace);
            }
            finally
            {
                Trace.TraceError(tip);
                MessageBox.Show(tip, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string tip = string.Empty;
            try
            {
                tip = string.Format("Background Worker Thread Unhandled Exception: {0}\n{1}", e.Exception.Message, e.Exception.StackTrace);
            }
            catch (Exception ex)
            {
                tip = string.Format("Unknown Exception while handling the Background Worker Thread Exception: {0}\n{1}", ex.Message, ex.StackTrace);
            }
            finally
            {
                Trace.TraceError(tip);
                MessageBox.Show(tip, "Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
