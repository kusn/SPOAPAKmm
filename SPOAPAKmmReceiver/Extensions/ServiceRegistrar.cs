using Autofac;
using SPOAPAKmmReceiver.Services;

namespace SPOAPAKmmReceiver.Extensions
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<DataProvider>().AsImplementedInterfaces().SingleInstance().AsSelf();

            return builder;
        }
    }
    
}
