namespace Dolphin.NN
{
    public abstract class ActivationFunction : PluginFunction
    {
        public abstract double GetOutput(double input);
    }
}