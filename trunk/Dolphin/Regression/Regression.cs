using System;
using System.Collections.Generic;
using System.ComponentModel;
using dnAnalytics;
using dnAnalytics.LinearAlgebra;
using Dolphin.GUI;
using System.Collections;

namespace Dolphin.Regression
{
    public abstract class Regression : Validatable
    {
        public enum TestingMode
        {
            BATCH,
            ONLINE
        }

        public delegate void UpdateCallBack();

        private PatternSet trainingSet;
        private PatternSet testingSet;
        private PatternSet validationSet;
        private int trainingSize = 0;
        private int testingSize = 0;
        private int validationSize = 0;
        private int windowSize = 0;
        private PatternSet dataSet;
        private int permutations = 10;
        private TestingMode mode;

        private KernelFunction kernelFunction;
        private Matrix gramMatrix;

        [Category("Online testing")]
        public int WindowSize
        {
            get { return windowSize; }
            set { windowSize = value; }
        }

        [Category("General")]
        public TestingMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        [Category("General")]
        [TypeConverter(typeof (PatternSetConverter))]
        public String DataSetName
        {
            get
            {
                if (dataSet != null) return dataSet.Name;
                else return "(None)";
            }
            set
            {
                if (value == null || !Global.PatternSets.ContainsKey(value))
                {
                    throw new Exception("Unknow data set name");
                }

                DataSet = Global.PatternSets[value];
            }
        }

        [Browsable(false)]
        public PatternSet DataSet
        {
            get { return dataSet; }
            set
            {
                dataSet = value;
                TestingSize = 0;
                TrainingSize = value.Count;
            }
        }

        [Category("Batch testing")]
        public int TrainingSize
        {
            get { return trainingSize; }
            set
            {
                trainingSize = value;
                if (trainingSize + testingSize + validationSize > dataSet.Count)
                {
                    testingSize = dataSet.Count - trainingSize - validationSize;
                }
            }
        }

        [Category("General")]
        public int TestingSize
        {
            get { return testingSize; }
            set
            {
                testingSize = value;
                if (trainingSize + testingSize + validationSize > dataSet.Count)
                {
                    trainingSize = dataSet.Count - testingSize - validationSize;
                }
            }
        }

        [Category("Batch testing")]
        public int ValidationSize
        {
            get { return validationSize; }
            set
            {
                validationSize = value;
                if (trainingSize + testingSize + validationSize > dataSet.Count)
                {
                    validationSize = dataSet.Count - testingSize - trainingSize;
                }
            }
        }

        [Category("Batch testing")]
        public int Permutations
        {
            get { return permutations; }
            set { permutations = value; }
        }

        [Browsable(false)]
        public PatternSet TrainingSet
        {
            get { return trainingSet; }
            set { trainingSet = value; }
        }

        [Browsable(false)]
        public PatternSet TestingSet
        {
            get { return testingSet; }
            set { testingSet = value; }
        }

        [Browsable(false)]
        public PatternSet ValidationSet
        {
            get { return validationSet; }
            set { validationSet = value; }
        }

        [Category("General")]
        [Editor(typeof(KernelFunctionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public KernelFunction KernelFunction
        {
            get { return kernelFunction; }
            set { kernelFunction = value; }
        }

        [Browsable(false)]
        public virtual Matrix GramMatrix
        {
            get
            {
                if (kernelFunction == null)
                {
                    throw new Exception("Kernel function is required for kernel matrix calculation");
                }

                if (gramMatrix == null)
                {
                    gramMatrix = MatrixBuilder.CreateMatrix(trainingSet.Count);
                    for (int i = 0; i < trainingSet.Count; i++)
                    {
                        for (int j = 0; j < trainingSet.Count; j++)
                        {
                            gramMatrix[i, j] =
                                KernelFunction.GetOutput(VectorBuilder.CreateVector(trainingSet[i].Input.ToArray()),
                                                         VectorBuilder.CreateVector(trainingSet[j].Input.ToArray()));
                        }
                    }
                }

                return gramMatrix;
            }

            set { gramMatrix = value; }
        }

        public abstract double GetPrediction(List<double> signal);

        private double OnlineTest(UpdateCallBack callback)
        {
            Queue<Pattern> window = new Queue<Pattern>(DataSet.GetRange(0, WindowSize));
            
            int position = windowSize;
            double mse = 0;
            while (position < TestingSize+WindowSize)
            {
                Pattern[] tmp = window.ToArray();
                Array.Reverse(tmp);
                TrainingSet = new PatternSet(tmp);

                mse += Math.Pow(GetPrediction(DataSet[position].Input) - DataSet[position].Output[0], 2);
                EndCache();
                
                window.Dequeue();
                window.Enqueue(DataSet[position]);
                callback.Invoke();
            }
            return mse/TestingSize;
        }

        private double BatchTest(UpdateCallBack callback)
        {
            Settings.Blas = dnAnalytics.LinearAlgebra.Native.BlasProvider.Mkl;
            Settings.Lapack = dnAnalytics.LinearAlgebra.Native.LapackProvider.Mkl;

            double gmse = 0;
            for (int i = 0; i < permutations; i++)
            {
                ResetValidation();
                double validationMse = Double.MaxValue;
                DataSet.Shuffle();

                gramMatrix = null;


                TrainingSet = new PatternSet(DataSet.GetRange(0, TrainingSize));
                ValidationSet = new PatternSet(DataSet.GetRange(TrainingSize, ValidationSize));
                TestingSet = new PatternSet(DataSet.GetRange(TrainingSize + ValidationSize, TestingSize));

                do
                {
                    double l = CalculateMse(ValidationSet);

                    if (l < validationMse)
                    {
                        validationMse = l;
                        RememberBest();
                    }
                } while (NextValidation());

                RestoreBest();
                gmse += CalculateMse(TestingSet);
                callback.Invoke();
            }

            return gmse / permutations;
        }

        public double Test(UpdateCallBack callback)
        {
            if (mode == TestingMode.ONLINE) return OnlineTest(callback);
            else if (mode == TestingMode.BATCH) return BatchTest(callback);
            else throw new Exception("Unsupported testing mode " + mode);
        }

        private double CalculateMse(PatternSet patternSet)
        {
            double mse = 0;
            StartCache();
            foreach (Pattern pattern in patternSet)
            {
                double result = GetPrediction(pattern.Input);
                mse += Math.Pow(result - pattern.Output[0], 2);

#if TRACE
                Console.WriteLine(String.Format("{0} - {1}", pattern.Output[0], result));
#endif
            }
            EndCache();
            return mse / patternSet.Count;
        }

        protected virtual void StartCache()
        {
            gramMatrix = null;
        }

        protected virtual void EndCache()
        {
            gramMatrix = null;
        }


        public override string ToString()
        {
            return "Kernel Function = " + KernelFunction.ToString();
        }

        #region Validation Interface
        public virtual void ResetValidation()
        {
            KernelFunction.ResetValidation();
        }

        public virtual bool NextValidation()
        {
            return KernelFunction.NextValidation();
        }

        public virtual void RememberBest()
        {
            KernelFunction.RememberBest();
        }

        public virtual void RestoreBest()
        {
            KernelFunction.RestoreBest();
        }
        #endregion
    }
}