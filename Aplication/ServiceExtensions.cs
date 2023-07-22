using Application.Behaviours;
using Application.Services.Abstraction.FileServices;
using Application.Services.Abstraction.SecurityServices;
using Application.Services.Abstraction.UsersServices;
using Application.Services.Implementation.FileServices;
using Application.Services.Implementation.SecurityServices;
using Application.Services.Implementation.UsersServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;
using Shared.Services.Implementation;
using System.Reflection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserSerivice, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IEncrypPasswordService, EncryptPasswordService>();
            services.AddTransient<IMessageEmailSender, MessageSenderService>();
        }
    }
}
