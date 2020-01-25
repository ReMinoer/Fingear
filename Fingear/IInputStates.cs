namespace Fingear
{
    public interface IInputStates
    {
        bool Ignored { get; }
        void Clean();
        void Reset();
        void Ignore();
    }
}