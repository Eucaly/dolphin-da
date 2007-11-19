using System;
using System.Collections.Generic;
using System.ComponentModel;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Decomposition;

namespace Dolphin.Regression
{
    public class RR : Regression
    {
        private ValidatableParameter a = new ValidatableParameter(3, 3, 1, 0);
        private bool useTraceRatio;
        private Matrix cache = null;
        private Matrix kAI;
        private Matrix k;

        protected Matrix K
        {
            get { return k; }
            set { k = value; }
        }

        protected Matrix KAI
        {
            get { return kAI; }
            set { kAI = value; }
        }

        [Category("Ridge Regression")]
        //[Editor(typeof(ValidatableParameterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual ValidatableParameter A
        {
            get { return a; }
            set { a = value; }
        }

        [Category("Ridge Regression")]
        public bool UseTraceRatio
        {
            get { return useTraceRatio; }
            set { useTraceRatio = value; }
        }

        public override double GetPrediction(List<double> signal)
        {
            if (TrainingSet.OutputSize != 1)
            {
                throw new Exception("Regression analyzer requires output in training set to be scalar.");
            }

            if (cache == null)
            {
                Matrix y = MatrixBuilder.CreateMatrix(TrainingSet.Count, 1);
                Matrix I = MatrixBuilder.CreateIdentityMatrix(TrainingSet.Count);

                for (int i = 0; i < TrainingSet.Count; i++) y[i, 0] = TrainingSet[i].Output[0];

                double x = UseTraceRatio ? A*GramMatrix.Diagonal().Sum()/GramMatrix.Diagonal().Count : A;

                KAI = (new Cholesky((GramMatrix + I*x))).Solve(I);
                cache = y.Transpose()*KAI;
            }


            k = MatrixBuilder.CreateMatrix(TrainingSet.Count, 1);
            for (int i = 0; i < TrainingSet.Count; i++)
                k[i, 0] =
                    KernelFunction.GetOutput(VectorBuilder.CreateVector(TrainingSet[i].Input.ToArray()),
                                             VectorBuilder.CreateVector(signal.ToArray()));

            return (cache*k)[0, 0];
        }

        protected override void StartCache()
        {
            base.StartCache();
            cache = null;
        }

        protected override void EndCache()
        {
            base.StartCache();
            cache = null;
        }

        public override string ToString()
        {
            return String.Format("Algorithm: Ridge Regression\nA = {0}\n{1}", A, base.ToString());
        }

        #region Validation Interface
        public override void ResetValidation()
        {
            A.ResetValidation();
            base.ResetValidation();
        }

        public override bool NextValidation()
        {
            if (base.NextValidation())
            {
                return true;
            }
            else
            {
                base.ResetValidation();
                return A.NextValidation();
            }
        }

        public override void RememberBest()
        {
            base.RememberBest();
            A.RememberBest();
        }


        public override void RestoreBest()
        {
            base.RestoreBest();
            A.RestoreBest();
        }
        #endregion
    }
}