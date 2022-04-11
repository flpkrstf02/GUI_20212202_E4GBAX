using GUI_20212202_E4GBAX.Logic;
using GUI_20212202_E4GBAX.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_20212202_E4GBAX
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IGameWindowLogic, GameWindowLogic>()
                    .AddSingleton<IGameWindowService, GameWindowViaWindow>()
                    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default).BuildServiceProvider()
                    );
        }
    }
}
