using AutoMapper;
using BL;
using DL;

namespace WebApi.Config
{
    public static class Configuration
    {
        public  static void Configurations(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
          
          
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiler());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
