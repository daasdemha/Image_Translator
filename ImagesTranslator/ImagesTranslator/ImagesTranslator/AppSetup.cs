using Autofac;
using ImagesTranslator.Utility;
using ImagesTranslator.ViewModels;
using System;
using System.Collections.Generic;

using System.Text;

namespace ImagesTranslator
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            //// Register Services
            cb.RegisterType<AzureService>().As<IAzureService>().SingleInstance();

            ////// Register View Models
            cb.RegisterType<HomeViewModel>().AsSelf();
        }
    }
}
