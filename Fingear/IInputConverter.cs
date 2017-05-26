namespace Fingear
{
    public interface IInputConverter
    {
        T Resolve<T>(IInput input) where T : class, IInput;
        bool TryResolve<T>(IInput input, out T result) where T : class, IInput;
    }
}