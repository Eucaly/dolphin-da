using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;
using Dolphin;

namespace Dolphin.Regression
{
    public abstract class KernelFunction : Validatable, PluginFunction
    {
        protected KernelFunction()
        {
            ResetValidation();
        }

        public abstract double GetOutput(Vector x, Vector y);
        public abstract void ResetValidation();
        public abstract bool NextValidation();
        public abstract void RememberBest();
        public abstract void RestoreBest();
    }
}