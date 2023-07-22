using Microsoft.Extensions.DependencyInjection;
using Shared.Services;
using Shared.Services.Implementation;

namespace Shared
{
    public static class ServiceExtension
    {
        public static void AddSharedInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IMessageEmailSender, MessageSenderService>();
        }
    }
}
