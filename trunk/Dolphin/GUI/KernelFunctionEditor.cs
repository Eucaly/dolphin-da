using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Dolphin;

namespace Dolphin.GUI
{
    internal class KernelFunctionEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value != null && !(value is PluginFunction)) return value;

            FunctionControl functionControl = new FunctionControl();
            functionControl.Function = (PluginFunction) value;
            Form dlg = new Form();
            dlg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            dlg.AutoSize = true;
            dlg.AutoSizeMode = AutoSizeMode.GrowOnly;
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.Controls.Add(functionControl);
            dlg.ShowDialog();

            return functionControl.Function;
        }
    }
}