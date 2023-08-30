//using ikvm.runtime;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting.Internal;

//namespace ReadinngLog.Tests.Abstractions
//{
//    public static class ServiceProviderFactory
//    {
//        public static IServiceProvider ServiceProvider { get; }

//        static ServiceProviderFactory()
//        {
//            HostingEnvironment env = new HostingEnvironment();
//            env.ContentRootPath = Directory.GetCurrentDirectory();
//            env.EnvironmentName = "Development";

//            var startup = new Startup(env);
//            ServiceCollection sc = new ServiceCollection();
//            startup.ConfigureServices(sc);
//            ServiceProvider = sc.BuildServiceProvider();
//        }
//    }
//}
