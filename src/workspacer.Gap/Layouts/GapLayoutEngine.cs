using System.Collections.Generic;
using System.Linq;

namespace workspacer.Gap
{
    public class GapLayoutEngine : ILayoutEngine
    {
        private GapPluginConfig _config;
        private ILayoutEngine _inner;
        public string Name => _inner.Name;

        public GapLayoutEngine(ILayoutEngine inner, GapPluginConfig config)
        {
            _inner = inner;
            _config = config;
        }

        public IEnumerable<IWindowLocation> CalcLayout(IEnumerable<IWindow> windows, int spaceWidth, int spaceHeight)
        {
            var doubleOuter = _config.OuterGap * 2;
            var halfInner = _config.InnerGap / 2;
            return windows.Zip(_inner.CalcLayout(windows, spaceWidth - doubleOuter, spaceHeight - doubleOuter)).Select(
                win =>
                {
                    var l = win.Second;
                    if (!_config.OnFocused && win.First.IsFocused)
                    {
                        return new WindowLocation(l.X + _config.OuterGap, l.Y + _config.OuterGap,
                            l.Width, l.Height, l.State);
                    }
                    else
                    {
                        return new WindowLocation(l.X + _config.OuterGap + halfInner, l.Y + _config.OuterGap + halfInner,
                            l.Width - _config.InnerGap, l.Height - _config.InnerGap, l.State);
                    }
                }
            );

        }

        public void ShrinkPrimaryArea() { _inner.ShrinkPrimaryArea(); }
        public void ExpandPrimaryArea() { _inner.ExpandPrimaryArea(); }
        public void ResetPrimaryArea() { _inner.ResetPrimaryArea(); }
        public void IncrementNumInPrimary() { _inner.IncrementNumInPrimary(); }
        public void DecrementNumInPrimary() { _inner.DecrementNumInPrimary(); }

        public void IncrementInnerGap()
        {
            _config.InnerGap += _config.Delta;
        }

        public void DecrementInnerGap()
        {
            _config.InnerGap += _config.Delta;
            if (_config.InnerGap < 0)
                _config.InnerGap = 0;
        }

        public void IncrementOuterGap()
        {
            _config.OuterGap += _config.Delta;
        }

        public void DecrementOuterGap()
        {
            _config.OuterGap -= _config.Delta;
            if (_config.OuterGap < 0)
                _config.OuterGap = 0;
        }

        public void ClearGaps()
        {
            _config.InnerGap = 0;
            _config.OuterGap = 0;
        }
    }
}
