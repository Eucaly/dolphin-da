namespace Dolphin
{
    internal interface Validatable
    {
        void ResetValidation();
        bool NextValidation();
        void RememberBest();
        void RestoreBest();
    }
}