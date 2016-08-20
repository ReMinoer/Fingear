namespace Fingear
{
    public interface IInputConversionResolver
    {
        T Resolve<T>(IInput input) where T : class, IInput;
    }
}