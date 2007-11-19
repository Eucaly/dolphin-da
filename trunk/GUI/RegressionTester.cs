using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Dolphin.GUI;
using Dolphin.Regression;

namespace Dolphin.GUI
{
    public partial class Form1 : Form
    {
        private DataSet errorDataSet = new DataSet();
        private Regression.Regression regression = null;
        private Dictionary<string, PatternSet> patternSets = new Dictionary<string, PatternSet>();
        private double gmse;

        public Form1()
        {
            InitializeComponent();

            /*if (!EventLog.SourceExists("GNNS_SOURCE"))
            {
                EventLog.CreateEventSource("GNNS_SOURCE", "GNNS");
            }
*/

            foreach (EventLogEntry elo in eventLog.Entries)
            {
                Console.WriteLine(elo.TimeGenerated);
            }    
            
            UpdateEventLogHistory();
        }

        private void start_Click(object sender, EventArgs e)
        {
            regression.DataSet.Normalize();
            start.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }

        private void openDataSet_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            String fileName = openFileDialog.FileName;
            PatternSet set;

            if (fileName.ToLower().EndsWith("csv") || fileName.ToLower().EndsWith("data"))
            {
                set = PatternSet.LoadCSV(fileName, new string[] {" ", "\t"}, false);
            }
            else
            {
                set = PatternSet.LoadXML(fileName);
            }

            set.Normalize();
            Global.PatternSets.Add(set.Name, set);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            int p = regression.Permutations;
            gmse = regression.Test(delegate { 
                                                backgroundWorker.ReportProgress((p - i) * 100 / p); i++; });
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            eventLog.WriteEntry(String.Format("{0}\nMSE = {1}", regression, gmse), 
                                EventLogEntryType.Information);
            UpdateEventLogHistory();
            start.Enabled = true;
            toolStripProgressBar.Value = 0;
        }

        private void UpdateEventLogHistory()
        {
            foreach (EventLogEntry ev in eventLog.Entries)
            {
                string[] t = ev.Message.Split(new char[] {'\n'});
                logEntries.Items.Add(new ListViewItem(new string[]
                                                          {
                                                              ev.TimeGenerated.ToString("dd/MM/yy hh:mm"),
                                                              t[t.Length - 1],
                                                          }));
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = 100 - e.ProgressPercentage;
        }

        private void regressionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BUG: Temp hack
            switch(regressionCombo.SelectedIndex)
            {
                case 0:                    
                    regression = new RR();
                    break;
                case 1:
                    regression = new KAAR();
                    break;
                case 2:
                    regression = new KAARCh();
                    break;
            }

            propertyGrid.SelectedObject = regression;
        }

        private void propertyGrid_Click(object sender, EventArgs e)
        {

        }

        private void rrTest_Click(object sender, EventArgs e)
        {
            (new RROptimalParam()).Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (logEntries.SelectedIndices.Count == 0) return;          
            lblLogEntry.Text = eventLog.Entries[logEntries.SelectedIndices[0]].Message;
        }

        private void about_Click(object sender, EventArgs e)
        {
            (new AboutBox()).ShowDialog(this);
        }
    }
}