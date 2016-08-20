using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fingear
{
    public class InputSystem : ICollection<IInputSource>
    {
        private readonly List<IInputSource> _sourcesList;
        public int RefreshDelay { get; set; } = 100;
        public IConversionResolver ConversionResolver { get; set; }
        public int Count => _sourcesList.Count;
        bool ICollection<IInputSource>.IsReadOnly => false;

        public InputSystem()
        {
            _sourcesList = new List<IInputSource>();
        }

        public async Task<T> CatchInputAsync<T>(CancellationToken token)
            where T : class, IInput
        {
            IInput[] inputs = _sourcesList.SelectMany(x => x.GetAllInputs()).ToArray();

            while (true)
            {
                foreach (IInput input in inputs)
                    input.Update();

                IInput triggeredInput = inputs.FirstOrDefault(x => x.Activity == InputActivity.Triggered);
                if (triggeredInput != default(IInput))
                    return ConversionResolver != null ? ConversionResolver.Resolve<T>(triggeredInput) : triggeredInput as T;

                await Task.Delay(RefreshDelay, token);
            }
        }

        public void Add(IInputSource item)
        {
            _sourcesList.Add(item);
        }

        public bool Remove(IInputSource item)
        {
            return _sourcesList.Remove(item);
        }

        public void Clear()
        {
            _sourcesList.Clear();
        }

        public bool Contains(IInputSource item)
        {
            return _sourcesList.Contains(item);
        }

        public void CopyTo(IInputSource[] array, int arrayIndex)
        {
            _sourcesList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IInputSource> GetEnumerator()
        {
            return _sourcesList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_sourcesList).GetEnumerator();
        }
    }
}