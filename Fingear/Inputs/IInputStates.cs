namespace Fingear.Inputs
{
    public interface IInputStates
    {
        bool Ignored { get; }
        void Clean();
        void Reset();
        void Ignore();
    }
}