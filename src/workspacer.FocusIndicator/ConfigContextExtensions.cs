﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workspacer.FocusIndicator
{
    public static class ConfigContextExtensions
    {
        public static void AddFocusIndicator(this IConfigContext context, FocusIndicatorPluginConfig config = null)
        {
            context.Plugins.RegisterPlugin(new FocusIndicatorPlugin(config ?? new FocusIndicatorPluginConfig()));
        }

        public static void AddFocusIndicator(this IConfigContext context, Action<FocusIndicatorPluginConfig> onConfig)
        {
            var config = new FocusIndicatorPluginConfig();
            onConfig(config);
            context.AddFocusIndicator(config);
        }
    }
}
