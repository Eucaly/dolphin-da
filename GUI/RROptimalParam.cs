using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dolphin.Regression;
using ZedGraph;

namespace Dolphin.GUI
{
    public partial class RROptimalParam : Form
    {
        private List<double> x, y;
        private RRTest rrTest = new RRTest();

        public RROptimalParam()
        {
            InitializeComponent();
        }

        private void RROptimalParam_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = rrTest;
            //rrTest.KernelFunction = new VPK(new ValidatableParameter(2, 2, 0));
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel.Text = String.Format("Testing a = {0}", e.UserState);
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GraphPane graphPane = chart.GraphPane;
            toolStripStatusLabel.Text = "Updating graph";
            graphPane.CurveList.Clear();

            LineItem curve =
                graphPane.AddCurve("", y.ToArray(), x.ToArray(), Color.FromArgb(49, 255, 49), SymbolType.Circle);
            curve.Symbol.Fill = new Fill(Color.FromArgb(49, 255, 49));
            curve.Symbol.Size = 5;
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.5F;

            chart.AxisChange();
            chart.Refresh();
            test.Enabled = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int permutations = rrTest.Permutations;
            x = new List<double>(permutations);
            y = new List<double>(permutations);

            int stepCount = (int) ((rrTest.End - rrTest.Start)/rrTest.Step);

            for (double a = rrTest.Start; a <= rrTest.End; a += rrTest.Step)
            {
                rrTest.A.Value = a;

                double error =
                    rrTest.Test(
                        delegate
                            {
                                backgroundWorker.ReportProgress(
                                    (int) (((a - rrTest.Start)/rrTest.Step)*100/stepCount), a);
                            });
                y.Add(a);
                x.Add(error);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            test.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }
    }

    internal class RRTest : RR
    {
        private double start;
        private double end;
        private double step;

        [Browsable(false)]
        public override ValidatableParameter A
        {
            get { return base.A; }
            set { base.A = value; }
        }

        [Category("Test")]
        public double Start
        {
            get { return start; }
            set { start = value; }
        }

        [Category("Test")]
        public double End
        {
            get { return end; }
            set { end = value; }
        }

        [Category("Test")]
        public double Step
        {
            get { return step; }
            set { step = value; }
        }
    }
}