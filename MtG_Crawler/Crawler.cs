using csscript;
using CSScriptLibrary;
using MtG_Crawler.Converter;
using MtG_Crawler.Data;
using MtG_Crawler.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MtG_Crawler
{
    public partial class Crawler : Form, ICrawlerMessageReceiver
    {
        public Crawler()
        {
            InitializeComponent();
        }

        public void Log(string message)
        {
            if (textBoxLog.InvokeRequired)
                textBoxLog.Invoke(new MethodInvoker(() => Log(message)));
            else
            {
                if (textBoxLog.Text.Length > 0)
                    textBoxLog.Text += System.Environment.NewLine;
                textBoxLog.Text += string.Format("[{0}] {1}", DateTime.Now, message);
                // Ans Ende scrollen
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
        }

        public void SetStatus(string statusText)
        {
            if (labelStatusMessage.InvokeRequired)
                labelStatusMessage.Invoke(new MethodInvoker(() => SetStatus(statusText)));
            else
                labelStatusMessage.Text = statusText;
        }

        private void Crawler_Load(object sender, EventArgs e)
        {
            MessageController.Receiver = this;
            splitContainer.Panel1Collapsed = !checkBoxShowLog.Checked;
            SetControlsForProcessing(false);
            textBoxLog.Font = new Font(FontFamily.GenericMonospace, textBoxLog.Font.Size);
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxScriptPath.Text) && !string.IsNullOrEmpty(textBoxExcelPath.Text))
            {
                string directoryPath = Path.GetDirectoryName(textBoxExcelPath.Text);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                labelStatusMessage.Text = string.Empty;
                SetControlsForProcessing(true);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void buttonScriptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CS-Dateien (*.cs)|*.cs|Alle Dateien (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
                textBoxScriptPath.Text = dialog.FileName;
        }

        private void buttonExcelPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel-Dateien (*.xls,*.xlsx)|*.xlsx;*xls|Alle Dateien (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
                textBoxExcelPath.Text = dialog.FileName;
        }

        private void SetControlsForProcessing(bool isProcessing)
        {
            buttonExecute.Enabled = !isProcessing;
            buttonScriptFile.Enabled = !isProcessing;
            buttonExcelPath.Enabled = !isProcessing;

            textBoxScriptPath.Enabled = !isProcessing;
            textBoxSets.Enabled = !isProcessing;
            textBoxExcelPath.Enabled = !isProcessing;

            panelStatus.Visible = isProcessing;
        }

        private void checkBoxShowLog_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer.Panel1Collapsed = !checkBoxShowLog.Checked;
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxLog.Text = string.Empty;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetStatus(string.Format("Lade Script '{0}'", textBoxScriptPath.Text));

                ICrawlResult result = CSScript.Evaluator.ReferenceAssembly("HtmlAgilityPack.dll")
                                                        .LoadFile<ICrawlResult>(textBoxScriptPath.Text);

                SetStatus("Verarbeite Daten ...");
                CardSet[] sets = result.GetData(textBoxSets.Text).ToArray();

                SetStatus(string.Format("Schreibe Daten in die Datei '{0}'", textBoxExcelPath.Text));
                ExcelWriter writer = new ExcelWriter();
                writer.Write(textBoxExcelPath.Text, sets);
            }
            catch(CompilerException exc)
            {
                e.Result = exc;
                Log(exc.Message);
            }
            catch (Exception exc)
            {
                e.Result = exc;
                Log(exc.ToString());
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlsForProcessing(false);

            if (e.Result != null && e.Result is Exception)
            {
                Exception exc = e.Result as Exception;
                MessageBox.Show(string.Format("{0} - {1}", exc.GetType().ToString(), exc.Message));
            }
        }
    }
}
