using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Dolphin;

namespace Dolphin
{
    public class PatternSet : List<Pattern>
    {
        private string name;
        private string fileName;
        private int inputSize;
        private int outputSize;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public string FileName {
            get { return fileName; }
            set { fileName = value; }
        }

        public int InputSize {
            get { return inputSize; }
            set { inputSize = value; }
        }

        public int OutputSize {
            get { return outputSize; }
            set { outputSize = value; }
        }

        public void Normalize() {
            List<Double> average = new List<double>();

            //Step 1 - Calculate the average.
            for (int i = 0; i < InputSize; i++) average.Add(0);

            foreach (Pattern pattern in this) {
                for (int i = 0; i < pattern.Input.Count; i++) {
                    average[i] += pattern.Input[i];
                }
            }

            for (int i = 0; i < InputSize; i++) average[i] /= Count;

            //Step 2 - substract average from all inputs and divide by it.
            double[] max = new double[InputSize];
            for (int i = 0; i < InputSize; i++) max[i] = 0;

            foreach (Pattern pattern in this)
            {
                for (int i = 0; i < pattern.Input.Count; i++)
                {
                    pattern.Input[i] = pattern.Input[i] - average[i];
                    max[i] = Math.Max(max[i], Math.Abs(pattern.Input[i]));
                }
            }
            
            foreach (Pattern pattern in this) {
                for (int i = 0; i < pattern.Input.Count; i++) {
                    pattern.Input[i] /= max[i];
                }
            }
        }

        public void Shuffle() {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < Count; i++) {
                int r = rnd.Next(0, Count);
                Pattern tmp = this[i];
                this[i] = this[r];
                this[r] = tmp;
            }
        }

        public static PatternSet LoadXML(string filename) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlElement root = doc.DocumentElement;
            int inc, outc;

            Int32.TryParse(root.Attributes["input"].Value, out inc);
            Int32.TryParse(root.Attributes["output"].Value, out outc);

            //Create new pattern set object
            PatternSet set = new PatternSet(inc, outc);

            //Get NAME of the Data
            set.Name = root.Attributes["name"].Value;

            foreach (XmlNode node in root.ChildNodes) {
                if (node.NodeType != XmlNodeType.Element || !node.Name.Equals("pattern")) continue;
                set.Add(LoadPattern(node, set));
            }

            set.FileName = filename;
            return set;
        }

        private static Pattern LoadPattern(XmlNode node, PatternSet patternSet) {
            Pattern pat = new Pattern();
            pat.PatternSet = patternSet;
            foreach (XmlNode child in node.ChildNodes) {
                if (child.NodeType != XmlNodeType.Element) continue;

                if (child.Name.Equals("input")) {
                    pat.Input.Add(Double.Parse(child.InnerText));
                }
                else if (child.Name.Equals("output")) {
                    pat.Output.Add(Double.Parse(child.InnerText));
                }
            }

            return pat;
        }

        /// <summary>
        /// This method assumes that last column is output.
        /// </summary>
        /// <param name="filename">Full path to the file.</param>
        /// <param name="separator">Array of possible column delimiters.</param>
        /// <param name="skipHeader">Skip the first line of the file, which usually contains column headers.</param>
        /// <returns>PatternsSet object with loaded data.</returns>
        public static PatternSet LoadCSV(string filename, string[] separator, bool skipHeader) {
            StreamReader reader = new StreamReader(filename);
            PatternSet set = null;

            while (!reader.EndOfStream) {
                String line = reader.ReadLine();
                string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (set == null) {
                    set = new PatternSet(arr.Length-1, 1);
                    if (skipHeader) continue;
                }

                Pattern pattern = new Pattern();

                for (int i = 0; i < arr.Length-2; i++) pattern.Input.Add(Double.Parse(arr[i].Trim()));
                pattern.Output.Add(Double.Parse(arr[arr.Length - 1].Trim()));
                set.Add(pattern);
            }

            set.name = (new FileInfo(filename)).Name;
            return set;
        }

        public PatternSet(int inputSize, int outputSize) {
            this.inputSize = inputSize;
            this.outputSize = outputSize;
        }

        public PatternSet(IList<Pattern> list) {
            foreach (Pattern pattern in list) {
                Add(pattern);
            }

            if (list.Count > 0) {
                inputSize = list[0].Input.Count;
                outputSize = list[0].Output.Count;
            }
        }
    }
}