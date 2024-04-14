using CleanArquitectureNet.Application.Contracts.Infrastructure;
using CleanArquitectureNet.Application.Contracts.Persistence;
using CleanArquitectureNet.Application.Models;
using CleanArquitectureNet.Infrastructure.Email;
using CleanArquitectureNet.Infrastructure.Persistence;
using CleanArquitectureNet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArquitectureNet.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
                                                                        , IConfiguration configuration) 
        {
            services.AddDbContext<StreamerDbContext>(option => 
                option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }

}
