using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChatLib;
//using LogLib;
using AsynchronousNetworkClientLogingLIb;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RyanAmaral_PROG2200_Assignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GameChatForm());

            UnityContainer container = new UnityContainer();
            container.RegisterType<ILoggingService, AsynchronousNetworkClientLogingLIb.FileLogger>();
            Application.Run(container.Resolve<GameChatForm>());

            //var container = new WindsorContainer();
            //container.Register(Component.For<GameChatForm>());
            //container.Register(Component.For<ILoggingService>().ImplementedBy<MyLogThis>());
            //Application.Run(container.Resolve<GameChatForm>());
        }
    }
}
