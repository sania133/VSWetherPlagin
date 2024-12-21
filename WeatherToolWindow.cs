using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace WeatherPlugin
{
    [Guid("6ab56f76-3d52-4e09-a04e-2a38b453097e")]
    public class WeatherToolWindow : ToolWindowPane
    {
        public WeatherToolWindow() : base(null)
        {
            this.Caption = "Weather in St. Petersburg";
            this.Content = new WeatherControl();
        }
    }
}
