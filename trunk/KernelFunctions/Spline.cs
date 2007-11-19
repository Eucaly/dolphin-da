using System;
using dnAnalytics.LinearAlgebra;
using Dolphin.Regression;

namespace Dolphin.KernelFunctions
{
    public class Spline : KernelFunction
    {

        public override double GetOutput(Vector x, Vector y)
        {
            double product = 1;
            for (int i = 0; i < x.Count; i++) {
                product *= 1 + x[i]*y[i] + 0.5*Math.Abs(x[i] - y[i])*Math.Pow(Math.Min(x[i], y[i]), 2) +
                           Math.Pow(Math.Min(x[i], y[i]), 3)/3;
			 
			}
            return product;
        }

        #region Validation Interface

        public override void ResetValidation()
        {
        }

        public override bool NextValidation()
        {
            return false;
        }

        public override void RememberBest()
        {
        }

        public override void RestoreBest()
        {
        }

        #endregion

        public override string ToString()
        {
            return String.Format("Spline");
        }
    }
}