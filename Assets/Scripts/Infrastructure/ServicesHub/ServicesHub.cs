namespace Infrastructure.ServicesHub
{
    public class ServicesHub
    {
        private static ServicesHub _instance;
        public static ServicesHub Container => _instance ?? (_instance = new ServicesHub());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}