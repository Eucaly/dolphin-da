using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Dolphin;
using Dolphin.Regression;

namespace Dolphin
{
    public partial class FunctionControl : UserControl
    {
        private Dictionary<string, Type> kernelFunctions = new Dictionary<string, Type>();
        private PluginFunction function;
        private PluginFunction newFunction;

        public PluginFunction Function
        {
            get { return function; }
            set
            {
                function = value;
                checkedListBox.Items.Clear();
                foreach (KeyValuePair<string, Type> pair in kernelFunctions)
                {
                    checkedListBox.Items.Add(pair.Key, (function != null && function.GetType() == pair.Value));
                }
            }
        }

        public FunctionControl()
        {
            foreach (String module in Global.FunctionModules)
            {
                foreach (Type ftype in FunctionLoader.ListFunctionsInModule(module, typeof(KernelFunction)))
                {
                    kernelFunctions.Add(ftype.Name, ftype);      
                }    
            }

            InitializeComponent();

            foreach (KeyValuePair<string, Type> pair in kernelFunctions)
            {
                checkedListBox.Items.Add(pair.Key);
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox.SelectedItem == null) return;
            
            String key = checkedListBox.SelectedItem.ToString();
            if (function != null && function.GetType() == kernelFunctions[key])
            {
                newFunction = function;
            }
            else
            {
                newFunction = Activator.CreateInstance(kernelFunctions[key]) as PluginFunction;
            }

            propertyGrid.SelectedObject = newFunction;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            function = newFunction;
            ParentForm.Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            ParentForm.Dispose();
        }
    }
}