using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImagesTranslator.Droid
{
    public class Setup: AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);
        }
    }
}