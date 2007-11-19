using System;
using System.ComponentModel;
using dnAnalytics.LinearAlgebra;
using Dolphin.Regression;

namespace Dolphin.KernelFunctions
{
    public class VPK : KernelFunction
    {
        private ValidatableParameter power = new ValidatableParameter(0, 0, 0);

        [TypeConverter(typeof (ExpandableObjectConverter))]
        public ValidatableParameter Power
        {
            get { return power; }
            set { power = value; }
        }


        public override double GetOutput(Vector x, Vector y)
        {
            return Math.Pow(1 + x.DotProduct(y), Power) / 
                Math.Sqrt(
                    Math.Pow(1 + x.DotProduct(x), Power) + 
                    Math.Pow(1 + y.DotProduct(y), Power)
                );
        }

        public VPK(ValidatableParameter power)
        {
            this.power = power;
        }


        public VPK()
        {
        }

        #region Validation Interface

        public override void ResetValidation()
        {
            Power.ResetValidation();
        }

        public override bool NextValidation()
        {
            return Power.NextValidation();
        }

        public override void RememberBest()
        {
            Power.RememberBest();
        }

        public override void RestoreBest()
        {
            Power.RestoreBest();
        }

        #endregion

        public override string ToString()
        {
            return String.Format("VPK(Power = [{0}])", Power);
        }
    }
}