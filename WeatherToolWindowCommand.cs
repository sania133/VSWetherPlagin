using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;

namespace WeatherPlugin
{
    internal sealed class WeatherToolWindowCommand
    {
        public static void Initialize(AsyncPackage package)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var commandService = package.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            var menuCommandId = new CommandID(GuidList.guidWeatherPluginCmdSet, PkgCmdIDList.cmdidWeatherToolWindow);
            var menuItem = new MenuCommand((s, e) => package.ShowToolWindow<WeatherToolWindow>(), menuCommandId);
            commandService?.AddCommand(menuItem);
        }
    }
}
