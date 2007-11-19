using System;
using System.Collections.Generic;

namespace Dolphin.NN.FeedForward
{
    public class Network : List<Level>
    {
        private string fileName;
        private Pattern pattern;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Pattern Pattern
        {
            get { return pattern; }
            set { pattern = value; }
        }

        public List<double> Output
        {
            get
            {
                if (Count == 0)
                {
                    throw  new Exception("Cannot calculate output of an empty network");
                }

                foreach (Level level in this)
                {
                    foreach (Neuron neuron in level)
                    {
                        foreach (Neuron forwardNeuron in neuron.ForwardLinks)
                        {
                            double weight = forwardNeuron.Weights[forwardNeuron.GetInputIdFromNeuron(neuron)];
                            forwardNeuron.Inputs.Add(neuron.Output*weight);
                        }
                    }
                }

                List<double> output = new List<double>();
                foreach (Neuron neuron in this[Count - 1])
                {
                    output.Add(neuron.Output);
                }

                return output;
            }
        }
    }
}