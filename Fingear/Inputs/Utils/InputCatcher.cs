using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fingear.Inputs.Utils
{
    public class InputCatcher
    {
        public int RefreshDelay { get; set; } = 100;
        public IEnumerable<IInputSource> Sources { get; set; }
        public IInputConverter Converter { get; set; }

        public T CatchInput<T>()
            where T : class, IInput
        {
            return CatchInputAsync<T>(CancellationToken.None).Result;
        }

        public async Task<T> CatchInputAsync<T>(CancellationToken token)
            where T : class, IInput
        {
            IInput[] inputs = Sources.SelectMany(x => x.GetAllInputs()).ToArray();

            T result;
            while (true)
            {
                foreach (IInput input in inputs)
                    input.Update();

                IInput triggeredInput = inputs.FirstOrDefault(x => x.Activity == InputActivity.Triggered);
                if (triggeredInput != null)
                {
                    if (Converter == null || !Converter.TryResolve(triggeredInput, out result))
                        result = triggeredInput as T;

                    break;
                }

                await Task.Delay(RefreshDelay, token);
            }

            //foreach (IInputSource source in Sources)
            //    source.CleanInstances();

            //InputManager.Instance.CleanInstances();

            return result;
        }
    }
}