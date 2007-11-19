using System.Collections.Generic;

namespace Dolphin.NN
{
    public abstract class Teacher
    {
        private PatternSet data;
        //FIXME: private FFNetwork network;
        private List<double> errors;


        public PatternSet Data
        {
            get { return data; }
            set { data = value; }
        }

        public List<double> Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public abstract List<double> TeachNetwork();
        public abstract void Reset();

        protected Teacher()
        {
            errors = new List<double>();
        }
    }
}