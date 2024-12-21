using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;

namespace WeatherPlugin
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("Weather Plugin", "Shows weather for St. Petersburg", "1.0")]
    [ProvideToolWindow(typeof(WeatherToolWindow))]
    public sealed class WeatherPluginPackage : AsyncPackage
    {
        protected override async System.Threading.Tasks.Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            WeatherToolWindowCommand.Initialize(this);
        }
    }
}
