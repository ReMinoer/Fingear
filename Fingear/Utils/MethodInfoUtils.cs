using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Fingear.Utils
{
    static public class MethodInfoUtils
    {
        static public string GetDelegateName(this MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttributes(typeof(CompilerGeneratedAttribute)).Any() ? "" : methodInfo.Name;
        }
    }
}