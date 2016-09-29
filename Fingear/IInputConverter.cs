namespace Fingear
{
    public interface IInputConverter
    {
        T Resolve<T>(IInput input) where T : class, IInput;
    }
}