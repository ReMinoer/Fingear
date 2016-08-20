namespace Fingear
{
    public interface IConversionResolver
    {
        T Resolve<T>(IInput input) where T : class, IInput;
    }
}