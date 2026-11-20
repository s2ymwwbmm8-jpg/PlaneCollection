using Autofac;
using ConfectioneryFactory.IoC;

namespace ConfectioneryFactory;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        using var container = ContainerConfig.Build();
        Application.Run(container.Resolve<MainForm>());
    }
}
