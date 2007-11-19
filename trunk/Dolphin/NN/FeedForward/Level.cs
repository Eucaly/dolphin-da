using System;
using System.Collections.Generic;
using System.Xml;

namespace Dolphin.NN.FeedForward
{
    public class Level : List<Neuron>
    {
        public enum Type
        {
            INPUT = 0,
            HIDDEN = 1,
            OUTPUT = 2,
        }

        private int index;
        private Type levelType;

        public int Index {
            get { return index; }
            set { index = value; }
        }

        public Type LevelType {
            get { return levelType; }
            set { levelType = value; }
        }

        public Level(Type levelType, int index) {
            this.levelType = levelType;
            this.index = index;
        }

        internal static Level ParseXML(XmlNode node, Network network) {
            Type type;

            int count = Int32.Parse(node.Attributes["count"].Value);
            int index = Int32.Parse(node.Attributes["index"].Value);

            String s_type = node.Attributes["type"].Value;
            type = (Type) Enum.Parse(typeof (Type), s_type);


            Level level = new Level(type, index);
            foreach (XmlNode child in node.ChildNodes) {
                if (child.NodeType != XmlNodeType.Element) continue;
                level.Add(Neuron.ParseXML(child, level));
            }

            return level;
        }
    }
}