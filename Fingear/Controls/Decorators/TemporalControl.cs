using System;
using System.Collections.Generic;
using Diese.Collections;
using Fingear.Controls.Base;

namespace Fingear.Controls.Decorators
{
    public class TemporalControl<TControl, TValue> : ControlDecoratorBase<TControl, TValue>
        where TControl : class, IControl<TValue>
    {
        private Queue<TValue> _samples = new Queue<TValue>();
        public Func<IEnumerable<TValue>, TValue> Filter { get; set; }
        public int SamplesCount { get; set; }

        public TemporalControl()
        {
        }

        public TemporalControl(TControl control, Func<IEnumerable<TValue>, TValue> filter, int samplesCount)
        {
            Component = control;
            Filter = filter;
            SamplesCount = samplesCount;
        }

        public TemporalControl(string name, TControl control, Func<IEnumerable<TValue>, TValue> filter, int samplesCount)
            : this(control, filter, samplesCount)
        {
            Name = name;
        }

        protected override bool UpdateControl(float elapsedTime, out TValue value)
        {
            _samples.Enqueue(Component.IsActive(out TValue sample) ? sample : default(TValue));
            while (_samples.Count > SamplesCount)
                _samples.Dequeue();

            value = Filter(_samples.Take(SamplesCount, _samples.Peek));
            return !value.Equals(default(TValue));
        }
    }
}