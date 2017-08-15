using Diese.Collections;
using Glyph;

namespace Fingear
{
    public interface IControlLayer : ITracker<IControl>, ITaggable
    {
        bool Enabled { get; set; }
        string Name { get; }
    }
}