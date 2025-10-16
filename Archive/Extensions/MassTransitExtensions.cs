using Archive.Infrastructure.RabbitMQ;
using Archive.Infrastructure.RabbitMQ.Consumers;
using MassTransit;

namespace Archive.Extensions
{
    /// <summary>
    /// Настройки и конфигурации MassTransit с использованием RabbitMQ
    /// </summary>
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitRabbitMq(this IServiceCollection services,
      IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {
                config.AddConsumer<ArchiveCreatedConsumer>();

                config.UsingRabbitMq((context, cfg) =>
                {
                    var rabbitMqSettings = configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

                    cfg.Host(rabbitMqSettings.Host, h =>
                    {
                        h.Username(rabbitMqSettings.Username);
                        h.Password(rabbitMqSettings.Password);
                    });

                    cfg.UseJsonSerializer();
                    cfg.UseMessageRetry(r => r.Interval(3, 1000));

                    // Регистрация endpoint
                    cfg.ConfigureEndpoints(context);
                });
            });


            services.AddTransient<IPublishEndpoint>(provider => provider.GetRequiredService<IBus>());

            return services;
        }
    }
}
