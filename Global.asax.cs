using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Lights
{
    public static class Var
    {
        static int id_e;
        static int id_a;
        static DateTime startTime;
        static bool stop;

        public static int ID_a
        {
            get { return id_a; }
            set { id_a = value; }
        }
        public static int ID_e
        {
            get { return id_e; }
            set { id_e = value; }
        }
        public static DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public static bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }
    }
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}