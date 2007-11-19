using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;

namespace Dolphin.Regression
{
    public class KAAR : RR
    {
        public override double GetPrediction(List<double> signal)
        {
            double rr = base.GetPrediction(signal);
            double z = KernelFunction.GetOutput(VectorBuilder.CreateVector(signal.ToArray()), VectorBuilder.CreateVector(signal.ToArray())) - (K.Transpose() * KAI * K)[0, 0];
            return rr*(1 - z/(z + A));
        }

        public override string ToString()
        {
            return "Algorithm: KAAR\n" + base.ToString();
        }
    }
}