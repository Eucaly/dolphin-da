using System;
using System.Collections.Generic;
using System.Xml;
using Dolphin.NN.FeedForward;

namespace Dolphin.NN.FeedForward
{
    public class Neuron : NN.Neuron
    {
        private List<Neuron> forwardLinks;
        private List<Neuron> backwardLinks;
        private List<double> weights;
        //TODO: Consider this as obsolete
        private Level level;
        //TODO: Rethink idea of indexes
        private int index;


        public Neuron(ActivationFunction function, Level level, int indexInLevel)
            : base(function) {
            this.level = level;
            index = indexInLevel;
            weights = new List<double>();
            forwardLinks = new List<Neuron>();
            backwardLinks = new List<Neuron>();
            }

        public List<Neuron> ForwardLinks {
            get { return forwardLinks; }
            set { forwardLinks = value; }
        }

        public List<Neuron> BackwardLinks {
            get { return backwardLinks; }
            set { backwardLinks = value; }
        }

        public List<double> Weights {
            get { return weights; }
            set { weights = value; }
        }

        public Level Level {
            get { return level; }
            set { level = value; }
        }

        public int IndexLevel {
            get { return index; }
            set { index = value; }
        }

        public int GetInputIdFromNeuron(Neuron neuron) {
            for (int i = 0; i < backwardLinks.Count; i++)
                if (backwardLinks[i].Equals(neuron)) return i;

            throw new Exception("No such link exists");
        }

        internal static Neuron ParseXML(XmlNode node, Level level) {
            int index = Int32.Parse(node.Attributes["index"].Value);
            ActivationFunction func = (ActivationFunction) FunctionLoader.GetFunction(node.Attributes["function_name"].Value);

            return new Neuron(func, level, index);
        }
    }
}