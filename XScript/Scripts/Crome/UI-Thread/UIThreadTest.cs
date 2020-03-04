using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ScriptSDK.Data;
using ScriptSDK.Engines;

namespace App.RebirthUO.Scripts.UIThreadTest
{
    public partial class UITester : Form
    {
        /// <summary>
        ///     Default Constructor wich constructs components
        /// </summary>
        public UITester()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Should be called in Mainmethod, handles the view of UI.
        ///     Use UITester.Perform(); to load UI.
        /// </summary>
        public static void Perform()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UITester());
        }
 
        /// <summary>
        ///     Button Event for Play-Button Starts Thread if not running yet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbplay_Click(object sender, EventArgs e)
        {
            if (!ScriptThread.IsBusy)
                ScriptThread.RunWorkerAsync();
        }

        /// <summary>
        ///     Button Event for Stop-Button Stops Thread if already running.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbstop_Click(object sender, EventArgs e)
        {
            if (ScriptThread.IsBusy)
                ScriptThread.CancelAsync();
        }

        /// <summary>
        ///     Code handled by Thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // Stores "Thread" to var
            var worker = (BackgroundWorker) sender;

            // Invokes Thread safe Actions onto UI. In this case disable play button , enable stop button.
            Invoke((MethodInvoker) delegate { tsbplay.Enabled = false; });
            Invoke((MethodInvoker) delegate { tsbstop.Enabled = true; });

            //Enables logger methods from SDK
            ScriptLogger.Initialize();

            //Initializes Loggin Event, wich performs an action whenever ScriptLogger gets new Logfiles.
            ScriptLogger.OnLogging += ScriptLogger_OnLogging;

            //Sample loop to repeat code inside, until thread gets stopped or application closed.
            while (!worker.CancellationPending)
            {
                //Sends Text to Logger, wich shares it onto UI through event.
                ScriptLogger.WriteLine("Hello Thread!");

                // Let the thread sleep when not requiring actions. Thread.Sleep works better then "Waits" via Api-Call.
                Thread.Sleep(500);
            }

            // Invokes Thread safe Actions onto UI. In this case disable stop button, enable play button.
            Invoke((MethodInvoker) delegate { tsbplay.Enabled = true; });
            Invoke((MethodInvoker) delegate { tsbstop.Enabled = false; });
        }

        /// <summary>
        ///     Event wich gets performed by thread (as Event to Scriptlogger) and writes send data via Invoke onto UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScriptLogger_OnLogging(object sender, ScriptLoggerArgs e)
        {
            Invoke((MethodInvoker) delegate { lblogger.Items.Add(string.Format("{0} : {1}", DateTime.UtcNow, e.Text)); });
        }

        /// <summary>
        ///     Just sample code for the Contextmenu onto Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblogger.Items.Clear();
        }

        /// <summary>
        ///     Just sample code for the Contextmenu onto Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(DateTime.UtcNow.ToFileTimeUtc() + ".log", lblogger.Items.Cast<string>().ToList());
        }
    }
}