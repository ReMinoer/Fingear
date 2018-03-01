using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Diese.Graph;
using Diese.Scheduling;

namespace Fingear
{
    public class ControlManager : IScheduler<ControlManager.SchedulerController, ControlLayer>
    {
        private readonly Scheduler _scheduler = new Scheduler();
        public IEnumerable<ControlLayer> Layers => _scheduler.Items;
        public IEnumerable<ControlLayer> Planning => _scheduler.Planning;
        public IGraphData<SchedulerGraph<ControlLayer>.Vertex, SchedulerGraph<ControlLayer>.Edge> GraphData => _scheduler.GraphData;
        public bool IsBatching => _scheduler.IsBatching;
        public int BatchDepth => _scheduler.BatchDepth;

        public SchedulerController Plan(ControlLayer item) => (SchedulerController)_scheduler.Plan(item);
        void IScheduler<ControlLayer>.Plan(ControlLayer item) => _scheduler.Plan(item);
        public void Unplan(ControlLayer item) => _scheduler.Unplan(item);
        public void ApplyProfile(IGraphData<SchedulerGraph<Predicate<object>>.Vertex, SchedulerGraph<Predicate<object>>.Edge> profile) => _scheduler.ApplyProfile(profile);

        public IDisposable Batch() => _scheduler.Batch();
        public void BeginBatch() => _scheduler.BeginBatch();
        public void EndBatch() => _scheduler.EndBatch();

        public void Update(float elapsedTime)
        {
            InputManager.Instance.Update();

            foreach (ControlLayer controlLayer in _scheduler.Planning)
            {
                if (controlLayer.Enabled)
                {
                    foreach (IControl control in controlLayer)
                        control.Update(elapsedTime);
                }
                else
                {
                    foreach (IControl control in controlLayer)
                        control.Reset();
                }
            }
        }

        internal class Scheduler : SchedulerBase<ISchedulerController<ControlLayer>, ControlLayer>
        {
            protected override ISchedulerController<ControlLayer> CreateController(SchedulerGraph<ControlLayer>.Vertex vertex)
            {
                return new SchedulerController(this, vertex);
            }
        }

        public class SchedulerController : SchedulerController<ControlLayer>, IControlLayer
        {
            private readonly ControlLayer _layer;
            public string Name => _layer.Name;
            public ICollection<object> Tags => _layer.Tags;

            public bool Enabled
            {
                get => _layer.Enabled;
                set => _layer.Enabled = value;
            }

            internal SchedulerController(SchedulerBase<ISchedulerController<ControlLayer>, ControlLayer> scheduler, SchedulerGraph<ControlLayer>.Vertex vertex)
                : base(scheduler, vertex)
            {
                _layer = vertex.Items[0];
            }
            
            public int Count => _layer.Count;
            public void Register(IControl item) => _layer.Register(item);
            public bool Unregister(IControl item) => _layer.Unregister(item);
            public void Clear() => _layer.Clear();
            public void ClearDisposed() => _layer.ClearDisposed();
            public bool Contains(IControl item) => _layer.Contains(item);
            public IEnumerator<IControl> GetEnumerator() => _layer.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_layer).GetEnumerator();
        }
    }
}