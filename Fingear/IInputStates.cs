namespace Fingear
{
    public interface IInputStates
    {
        bool Ignored { get; }
        void Clean();
        void Ignore();
    }
}