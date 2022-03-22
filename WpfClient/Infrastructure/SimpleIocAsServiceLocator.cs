using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_SG1_21_22_2.WpfClient.Infrastructure
{
    public class SimpleIocAsServiceLocator: SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
