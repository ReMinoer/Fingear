using System.Collections.Generic;

namespace Fingear
{
    public interface IControlLayer : IEnumerable<IControl>
    {
        bool Enabled { get; set; }
        string DisplayName { get; }
    }
}