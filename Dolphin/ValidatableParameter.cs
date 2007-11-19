using System.ComponentModel;

namespace Dolphin
{
    public class ValidatableParameter : Validatable
    {
        private double high, low, step, value, best;

        [Browsable(false)]
        public double Best
        {
            get { return best; }
            set { best = value; }
        }

        [Browsable(false)]
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public double Step
        {
            get { return step == 0 ? 1 : step; }
            set { step = value; }
        }

        public double Low
        {
            get { return low; }
            set
            {   if (value > high)
                low = high;
            else
                low = value;
            }
        }

        public double High
        {
            get { return high; }
            set
            {
                if (value < low)
                    high = low;
                else
                    high = value;
            }
        }


        public ValidatableParameter(double low, double high, double step, double value)
        {
            this.high = high;
            this.low = low;
            this.step = step;
            this.value = value;
        }

        public ValidatableParameter(double low, double high, double step) : this(low, high, step, 0)
        {
        }

        public static implicit operator double(ValidatableParameter m)
        {
            return m.Value;
        }

        public void ResetValidation()
        {
            Value = Low;
        }

        public bool NextValidation()
        {
            if (Value >= High)
            {
                return false;
            }
            else
            {
                Value += Step;
                return true;
            }
        }

        public void RememberBest()
        {
            Best = Value;
        }

        public void RestoreBest()
        {
            Value = Best;
        }


        public override string ToString()
        {
            return string.Format("{0} - {1} @ {2}", low, high, step);
        }
    }
}