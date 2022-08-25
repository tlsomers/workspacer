namespace workspacer.Gap
{
    public class GapPluginConfig
    {
        public int InnerGap { get; set; } = 0;
        public int OuterGap { get; set; } = 0;
        public int Delta { get; set; } = 20;

        public bool OnFocused { get; set; } = true;

        public GapPluginConfig()
        {

        }

        public GapPluginConfig(int innerGap, int outerGap, int delta, bool onFocused)
        {
            InnerGap = innerGap;
            OuterGap = outerGap;
            Delta = delta;
            OnFocused = onFocused;
        }
    }
}