using System.ComponentModel;

namespace Dolphin
{
    public class PatternSetConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(Global.PatternSets.Keys);
        }
    }
}