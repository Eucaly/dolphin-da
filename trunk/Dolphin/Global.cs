using System.Collections.Generic;

namespace Dolphin
{
    public class Global
    {
        private static readonly Dictionary<string, PatternSet> patternSets = new Dictionary<string, PatternSet>();
        private static readonly List<string> functionModules = new List<string>();

        public static Dictionary<string, PatternSet> PatternSets
        {
            get { return patternSets; }
        }

        public static List<string> FunctionModules
        {
            get { return functionModules; }
        }
    }
}