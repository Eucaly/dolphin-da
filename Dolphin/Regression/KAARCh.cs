using System;
using System.ComponentModel;
using dnAnalytics.LinearAlgebra;

namespace Dolphin.Regression
{
    public class KAARCh : RR
    {
        private double decayRate;

        [Category("KAARCh")]
        public double DecayRate
        {
            get { return decayRate; }
            set { decayRate = value; }
        }

        public override Matrix GramMatrix
        {
            get
            {
                Matrix m = base.GramMatrix;
                for (int i = 0; i < m.Rows; i++)
                    for (int j = 0; j < m.Columns; j++)
                        m[i, j] *= Math.Min(i, j)*DecayRate;
                return m;
            }
            set { base.GramMatrix = value; }
        }

        public override string ToString()
        {
            return "Algorithm: KAARCh\n" + base.ToString();
        }
    }
}