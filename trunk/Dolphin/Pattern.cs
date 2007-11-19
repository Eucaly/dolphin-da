using System.Collections.Generic;

namespace Dolphin
{
    public class Pattern
    {
        private List<double> input;
        private List<double> output;
        private PatternSet patternSet;

        public List<double> Input {
            get { return input; }
            set { input = value; }
        }

        public List<double> Output {
            get { return output; }
            set { output = value; }
        }

        public PatternSet PatternSet {
            get { return patternSet; }
            set { patternSet = value; }
        }


        public Pattern(int inputSize, int outputSize) {
            input = new List<double>(inputSize);
            output = new List<double>(outputSize);
        }

        public Pattern() : this(0, 0) {}
    }
}