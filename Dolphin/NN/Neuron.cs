using System;
using System.Collections.Generic;

namespace Dolphin.NN
{
    public class Neuron
    {
        private List<Double> inputs;
        private ActivationFunction function;
        private double bias = 0;
        private int freeSlot = 0;

        private bool isLocalFieldCashed = false;
        private double localField = 0;

        private bool isOutputCashed = false;
        private double output = 0;

        public Neuron(ActivationFunction function) {
            this.function = function;
            inputs = new List<double>();
        }

        public double Bias {
            get { return bias; }
            set { 
                bias = value;
                isOutputCashed = isLocalFieldCashed = false;
            }
        }

        public List<double> Inputs {
            get {
                isOutputCashed = isLocalFieldCashed = false;
                return inputs;
            }
            set { 
                inputs = value;
                isOutputCashed = isLocalFieldCashed = false;
            }
        }

        public double LocalField {
            get {
                if (isLocalFieldCashed) return localField;

                localField = 0;
                foreach (double d in inputs) {
                    localField += d;
                }
                localField += Bias;
                isLocalFieldCashed = true;
                return localField;
            }
        }

        public ActivationFunction Function {
            get { return function; }
            set { function = value; }
        }

        public double Output {
            get {
                if (isOutputCashed) return output;

                if (Function == null) {
                    throw new Exception("Activation function of neuron is not set");
                }

                output = Function.GetOutput(LocalField);
                isOutputCashed = true;
                return output;
            }
            
        }
        
    }
}